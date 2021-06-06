using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebExtensions.Net
{
    /// <summary>
    /// JSON converter for MultiType class object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MultiTypeJsonConverter<T> : JsonConverter<T>
        where T : BaseMultiTypeObject
    {
        /// <inheritdoc/>
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null || reader.TokenType == JsonTokenType.None)
            {
                reader.Read();
                return null;
            }

            var typeChoices = GetTypeChoices(typeToConvert);
            var jsonElement = JsonSerializer.Deserialize<JsonElement>(ref reader, options);

            foreach (var typeChoice in typeChoices)
            {
                if (IsMatchingType(typeChoice.Key, jsonElement, options, out var value))
                {
                    return CreateFromConstructor(typeChoice.Value, value);
                }
            }

            return null;
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value?.Value, options);
        }

        private static IEnumerable<KeyValuePair<Type, ConstructorInfo>> GetTypeChoices(Type type)
        {
            return type
                .GetConstructors(BindingFlags.Public | BindingFlags.Instance)
                .Select(constructor =>
                {
                    var parameterInfo = constructor.GetParameters().SingleOrDefault();
                    return KeyValuePair.Create(parameterInfo.ParameterType, constructor);
                })
                .Where(typeChoice => typeChoice.Key is not null)
                .OrderBy(typeChoice => GetOrderForType(typeChoice.Key))
                .ToArray();
        }

        private static int GetOrderForType(Type type)
        {
            if (type.IsPrimitive)
            {
                return 0;
            }

            if (IsBoolType(type) || IsIntType(type) || IsDoubleType(type))
            {
                return 1;
            }

            if (IsStringType(type))
            {
                return 2;
            }

            if (IsObjectType(type))
            {
                return 10;
            }

            if (IsArrayType(type))
            {
                var arrayItemType = type.GenericTypeArguments.First();
                return 20 + GetOrderForType(arrayItemType);
            }

            return 2;
        }

        private static bool IsBoolType(Type type)
        {
            return type == typeof(bool);
        }

        private static bool IsIntType(Type type)
        {
            return type == typeof(int);
        }

        private static bool IsDoubleType(Type type)
        {
            return type == typeof(double);
        }

        private static bool IsStringType(Type type)
        {
            return type == typeof(string) || typeof(BaseStringFormat).IsAssignableFrom(type);
        }

        private static bool IsObjectType(Type type)
        {
            return !IsBoolType(type) && !IsIntType(type) && !IsDoubleType(type) && !IsStringType(type) && !IsArrayType(type);
        }

        private static bool IsArrayType(Type type)
        {
            return type.IsGenericType && typeof(IEnumerable<>).IsAssignableFrom(type.GetGenericTypeDefinition());
        }

        private static bool IsMatchingType(Type type, JsonElement jsonElement, JsonSerializerOptions jsonSerializerOptions, out object value)
        {
            if ((jsonElement.ValueKind == JsonValueKind.True || jsonElement.ValueKind == JsonValueKind.False) && IsBoolType(type))
            {
                value = jsonElement.GetBoolean();
                return true;
            }

            if (jsonElement.ValueKind == JsonValueKind.Number)
            {
                if (IsIntType(type))
                {
                    value = jsonElement.GetInt32();
                    return true;
                }

                if (IsDoubleType(type))
                {
                    value = jsonElement.GetDouble();
                    return true;
                }
            }

            if (jsonElement.ValueKind == JsonValueKind.String && IsStringType(type))
            {
                value = jsonElement.GetString();
                return true;
            }

            if (jsonElement.ValueKind == JsonValueKind.Object && IsObjectType(type))
            {
                try
                {
                    value = JsonSerializer.Deserialize(jsonElement.GetRawText(), type, jsonSerializerOptions);
                    return true;
                }
                catch (JsonException)
                {
                    // Ignore if there is an error deserializing into this object type
                }
            }

            if (jsonElement.ValueKind == JsonValueKind.Array && IsArrayType(type))
            {
                try
                {
                    value = JsonSerializer.Deserialize(jsonElement.GetRawText(), type, jsonSerializerOptions);
                    return true;
                }
                catch (JsonException)
                {
                    // Ignore if there is an error deserializing into this array type
                }
            }

            value = null;
            return false;
        }

        private static T CreateFromConstructor(ConstructorInfo constructorInfo, object value)
        {
            return (T)constructorInfo.Invoke(new[] { value });
        }
    }
}
