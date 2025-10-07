using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebExtensions.Net
{
    /// <summary>
    /// JSON converter for Combined Callback Parameter class object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CombinedCallbackParameterJsonConverter<T> : JsonConverter<T>
        where T : BaseCombinedCallbackParameterObject, new()
    {
        /// <inheritdoc/>
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType is JsonTokenType.Null or JsonTokenType.None)
            {
                reader.Read();
                return null;
            }

            var result = new T();
            var index = 0;
            if (reader.TokenType == JsonTokenType.StartArray)
            {
                while (true)
                {
                    reader.Read();
                    if (reader.TokenType == JsonTokenType.EndArray)
                    {
                        break;
                    }

                    if (index >= result.PropertyNames.Length)
                    {
                        continue;
                    }

                    var propertyName = result.PropertyNames[index];
                    var propertyType = result.PropertyTypes[index];
                    var propertyInfo = typeof(T).GetProperty(propertyName);
                    var propertyValue = JsonSerializer.Deserialize(ref reader, propertyType, options);
                    propertyInfo.SetValue(result, propertyValue);

                    index++;
                }
            }

            return result;
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            IEnumerable<object> values = null;
            if (value is not null)
            {
                values = [.. value.PropertyNames.Select(propertyName=>
                {
                    var propertyInfo = typeof(T).GetProperty(propertyName);
                    return propertyInfo.GetValue(value);
                })];
            }

            JsonSerializer.Serialize(writer, values, options);
        }
    }
}
