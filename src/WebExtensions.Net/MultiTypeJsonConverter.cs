using System;
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
            if (reader.TokenType is JsonTokenType.Null or JsonTokenType.None)
            {
                reader.Read();
                return null;
            }

            var jsonElement = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
            return TypeConstructor.CreateInstance(typeToConvert, jsonElement, options) as T;
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
            => JsonSerializer.Serialize(writer, value?.Value, options);
    }
}
