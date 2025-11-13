using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace WebExtensions.Net;

internal sealed class TypeConstructor
{
    private readonly List<(Type Type, TypeConstructor TypeConstructor)> multiTypeConstructors;
    private readonly Type primitiveType;
    private readonly Type primitiveTypeNotNullable;
    private readonly Type objectType;
    private readonly ConstructorInfo parentConstructor;
    private readonly TypeConstructor childTypeConstructor;
    private static readonly Dictionary<Type, TypeConstructor> cachedConstructors = [];

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
            multiTypeConstructors = [.. type
                .GetConstructors(BindingFlags.Public | BindingFlags.Instance)
                .SelectMany(constructor =>
                {
                    var parameterInfo = constructor.GetParameters().SingleOrDefault();
                    if (parameterInfo is null)
                    {
                        return [];
                    }

                    var typeContructor = GetOrCreateTypeContructor(parameterInfo.ParameterType);
                    return typeContructor.multiTypeConstructors is not null
                        ? typeContructor.multiTypeConstructors.Select(typeChoice => (typeChoice.Type, new TypeConstructor(constructor, typeChoice.TypeConstructor)))
                        : [(parameterInfo.ParameterType, new TypeConstructor(constructor, typeContructor))]; })
                .OrderBy(OrderTypeChoice)];
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
            return value.ValueKind switch
            {
                JsonValueKind.True or JsonValueKind.False => typeToCheck == typeof(bool),
                JsonValueKind.Number => GetNumericValue(value, typeToCheck) is not null,
                JsonValueKind.String when IsStringFormat(typeToCheck) => BaseStringFormat.IsValid(value.GetString(), typeToCheck),
                JsonValueKind.String when typeToCheck.IsEnum => EnumValueAttribute.GetEnumValues(typeToCheck).ContainsKey(value.GetString()),
                JsonValueKind.String => IsStringJsonType(typeToCheck),
                _ => false
            };
        }

        return multiTypeConstructors is null || multiTypeConstructors.Exists(typeChoice => typeChoice.TypeConstructor.IsCompatible(value));
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

        return objectType == typeof(object) ? CreatePrimitive(value, null, options) : JsonSerializer.Deserialize(value, objectType, options);
    }

    private static object CreatePrimitive(JsonElement value, Type type, JsonSerializerOptions options)
    {
        if (value.ValueKind == JsonValueKind.Null)
        {
            return null;
        }

        if (value.ValueKind is JsonValueKind.True or JsonValueKind.False)
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
            return type switch
            {
                null => valueString,
                { IsEnum: true } => EnumValueAttribute.GetEnumValues(type).TryGetValue(valueString, out var enumValue) ? enumValue : null,
                _ when IsStringFormat(type) && IsValidStringFormat(valueString, type, out var stringFormat) => stringFormat,
                _ when IsStringJsonType(type) => JsonSerializer.Deserialize(value, type, options),
                _ => null
            };
        }

        return null;
    }

    private static object GetNumericValue(JsonElement value, Type type)
        => TryParseNumeric<short>(type, value.TryGetInt16, out var numericValue) ||
            TryParseNumeric<int>(type, value.TryGetInt32, out numericValue) ||
            TryParseNumeric<long>(type, value.TryGetInt64, out numericValue) ||
            TryParseNumeric<float>(type, value.TryGetSingle, out numericValue) ||
            TryParseNumeric<decimal>(type, value.TryGetDecimal, out numericValue) ||
            TryParseNumeric<double>(type, value.TryGetDouble, out numericValue)
            ? numericValue
            : null;

    private delegate bool TryGetNumericValue<T>(out T value);

    private static bool TryParseNumeric<T>(Type type, TryGetNumericValue<T> tryGetNumericValue, out object value)
    {
        if ((type == typeof(T) || type is null) && tryGetNumericValue(out var numericValue))
        {
            value = numericValue;
            return true;
        }

        value = null;
        return false;
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
        => type.IsPrimitive ||
            IsStringJsonType(type);

    private static bool IsStringFormat(Type type)
        => typeof(BaseStringFormat).IsAssignableFrom(type);

    private static bool IsNullablePrimitive(Type type)
        => type.IsGenericType &&
            type.GetGenericTypeDefinition() == typeof(Nullable<>) &&
            IsPrimitive(type.GenericTypeArguments[0]);

    private static bool IsStringJsonType(Type type)
        => type.IsEnum ||
            type == typeof(string) ||
            type == typeof(Guid) ||
            type == typeof(DateTime);

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
        => GetOrCreateTypeContructor(type).CreateInstance(value, options);

    private static TypeConstructor GetOrCreateTypeContructor(Type type)
    {
        lock (cachedConstructors)
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
