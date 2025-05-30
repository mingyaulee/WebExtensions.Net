using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace WebExtensions.Net
{
    internal sealed class TypeConstructor
    {
        private readonly List<(Type Type, TypeConstructor TypeConstructor)> multiTypeConstructors;
        private readonly Type primitiveType;
        private readonly Type primitiveTypeNotNullable;
        private readonly Type objectType;
        private readonly ConstructorInfo parentConstructor;
        private readonly TypeConstructor childTypeConstructor;
        private static readonly Dictionary<Type, TypeConstructor> cachedConstructors = new();

        private TypeConstructor(Type type)
        {
            if (IsPrimitive(type) || IsStringFormat(type))
            {
                primitiveType = type;
            }
            else if (IsNullablePrimitive(type))
            {
                primitiveType = type;
                primitiveTypeNotNullable = type.GenericTypeArguments[0];
            }
            else if (typeof(BaseMultiTypeObject).IsAssignableFrom(type))
            {
                multiTypeConstructors = type
                    .GetConstructors(BindingFlags.Public | BindingFlags.Instance)
                    .SelectMany(constructor =>
                    {
                        var parameterInfo = constructor.GetParameters().SingleOrDefault();
                        if (parameterInfo is null)
                        {
                            return [];
                        }

                        var typeContructor = GetOrCreateTypeContructor(parameterInfo.ParameterType);
                        if (typeContructor.multiTypeConstructors is not null)
                        {
                            return typeContructor.multiTypeConstructors.Select(typeChoice => (typeChoice.Type, new TypeConstructor(constructor, typeChoice.TypeConstructor)));
                        }

                        return [(parameterInfo.ParameterType, new TypeConstructor(constructor, typeContructor))];
                    })
                    .OrderBy(OrderTypeChoice)
                    .ToList();
            }
            else
            {
                objectType = type;
            }
        }

        private TypeConstructor(ConstructorInfo parentConstructor, TypeConstructor typeConstructor)
        {
            this.parentConstructor = parentConstructor;
            childTypeConstructor = typeConstructor;
        }

        private bool IsCompatible(JsonElement value)
        {
            if (childTypeConstructor is not null)
            {
                return childTypeConstructor.IsCompatible(value);
            }

            if (primitiveType is not null)
            {
                if (value.ValueKind == JsonValueKind.Null)
                {
                    return primitiveTypeNotNullable is not null;
                }

                var typeToCheck = primitiveTypeNotNullable ?? primitiveType;
                if (value.ValueKind == JsonValueKind.True || value.ValueKind == JsonValueKind.False)
                {
                    return typeToCheck == typeof(bool);
                }

                if (value.ValueKind == JsonValueKind.Number)
                {
                    return GetNumericValue(value, typeToCheck) is not null;
                }

                if (value.ValueKind == JsonValueKind.String)
                {
                    if (IsStringFormat(typeToCheck))
                    {
                        return BaseStringFormat.IsValid(value.GetString(), typeToCheck);
                    }

                    if (typeToCheck.IsEnum)
                    {
                        return EnumValueAttribute.GetEnumValues(typeToCheck).ContainsKey(value.GetString());
                    }

                    return IsStringJsonType(typeToCheck);
                }

                return false;
            }

            if (multiTypeConstructors is not null)
            {
                return multiTypeConstructors.Exists(typeChoice => typeChoice.TypeConstructor.IsCompatible(value));
            }

            return true;
        }

        private object CreateInstance(JsonElement value, JsonSerializerOptions options)
        {
            if (parentConstructor is not null && childTypeConstructor is not null)
            {
                var childValue = childTypeConstructor.CreateInstance(value, options);
                return childValue is not null ? parentConstructor.Invoke([childValue]) : null;
            }

            if (primitiveType is not null)
            {
                return CreatePrimitive(value, primitiveTypeNotNullable ?? primitiveType, options);
            }

            if (multiTypeConstructors is not null)
            {
                return CreateMultiType(value, options);
            }

            if (objectType == typeof(object))
            {
                return CreatePrimitive(value, null, options);
            }

            return JsonSerializer.Deserialize(value, objectType, options);
        }

        private static object CreatePrimitive(JsonElement value, Type type, JsonSerializerOptions options)
        {
            if (value.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            if (value.ValueKind == JsonValueKind.True || value.ValueKind == JsonValueKind.False)
            {
                return value.ValueKind == JsonValueKind.True;
            }

            if (value.ValueKind == JsonValueKind.Number)
            {
                return GetNumericValue(value, type);
            }

            if (value.ValueKind == JsonValueKind.String)
            {
                var valueString = value.GetString();
                if (type is null)
                {
                    return valueString;
                }

                if (type is { IsEnum: true })
                {
                    return EnumValueAttribute.GetEnumValues(type).TryGetValue(valueString, out var enumValue) ? enumValue : null;
                }

                if (IsStringFormat(type) && IsValidStringFormat(valueString, type, out var stringFormat))
                {
                    return stringFormat;
                }

                if (IsStringJsonType(type))
                {
                    return JsonSerializer.Deserialize(value, type, options);
                }
            }

            return null;
        }

        private static object GetNumericValue(JsonElement value, Type type)
        {
            if ((type == typeof(short) || type is null) && value.TryGetInt16(out var shortValue))
            {
                return shortValue;
            }
            else if ((type == typeof(int) || type is null) && value.TryGetInt32(out var intValue))
            {
                return intValue;
            }
            else if ((type == typeof(long) || type is null) && value.TryGetInt64(out var longValue))
            {
                return longValue;
            }
            else if ((type == typeof(float) || type is null) && value.TryGetSingle(out var floatValue))
            {
                return floatValue;
            }
            else if ((type == typeof(decimal) || type is null) && value.TryGetDecimal(out var decimalValue))
            {
                return decimalValue;
            }
            else if ((type == typeof(double) || type is null) && value.TryGetDouble(out var doubleValue))
            {
                return doubleValue;
            }

            return null;
        }

        private object CreateMultiType(JsonElement value, JsonSerializerOptions options)
        {
            foreach (var typeChoice in multiTypeConstructors.Where(typeChoice => typeChoice.TypeConstructor.IsCompatible(value)))
            {
                var instance = typeChoice.TypeConstructor.CreateInstance(value, options);
                if (instance is not null)
                {
                    return instance;
                }
            }

            return null;
        }

        private static bool IsPrimitive(Type type)
        {
            return type.IsPrimitive ||
                IsStringJsonType(type);
        }

        private static bool IsStringFormat(Type type)
            => typeof(BaseStringFormat).IsAssignableFrom(type);

        private static bool IsNullablePrimitive(Type type)
        {
            return type.IsGenericType &&
                type.GetGenericTypeDefinition() == typeof(Nullable<>) &&
                IsPrimitive(type.GenericTypeArguments[0]);
        }

        private static bool IsStringJsonType(Type type)
        {
            return
                type.IsEnum ||
                type == typeof(string) ||
                type == typeof(Guid) ||
                type == typeof(DateTime);
        }

        private static bool IsValidStringFormat(string valueString, Type type, out object value)
        {
            value = BaseStringFormat.TryCreate(valueString, type);
            return value is not null;
        }

        private static int OrderTypeChoice((Type Type, TypeConstructor TypeConstructor) typeChoice)
        {
            // Primitive type like bool, numeric, enum, etc are restrictive in the value kind or limited possible string value
            if ((IsPrimitive(typeChoice.Type) && typeChoice.Type != typeof(string)) || IsNullablePrimitive(typeChoice.Type))
            {
                return 0;
            }

            // String with format or patterns are more restrictive than string type
            if (IsStringFormat(typeChoice.Type))
            {
                return 1;
            }

            if (typeChoice.Type == typeof(string))
            {
                return 2;
            }

            // Other types like object and array is least restrictive and should be handled by JsonSerializer
            return 3;
        }

        public static object CreateInstance(Type type, JsonElement value, JsonSerializerOptions options)
        {
            return GetOrCreateTypeContructor(type).CreateInstance(value, options);
        }

        private static TypeConstructor GetOrCreateTypeContructor(Type type)
        {
            if (!cachedConstructors.TryGetValue(type, out var constructor))
            {
                constructor = new TypeConstructor(type);
                cachedConstructors.Add(type, constructor);
            }

            return constructor;
        }
    }
}
