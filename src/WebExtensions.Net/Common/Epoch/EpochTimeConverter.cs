using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebExtensions.Net
{
    /// <summary>
    /// JSON converter between <see cref="EpochTime"/> and string.
    /// </summary>
    public class EpochTimeConverter : JsonConverter<EpochTime>
    {
        /// <inheritdoc/>
        public override EpochTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number)
            {
                return reader.GetDouble();
            }

            return default;
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, EpochTime value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value);
        }
    }
}
