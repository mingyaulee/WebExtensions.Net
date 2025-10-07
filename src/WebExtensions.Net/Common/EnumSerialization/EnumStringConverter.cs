using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebExtensions.Net
{
    /// <summary>
    /// JSON converter between enum and string
    /// </summary>
    /// <typeparam name="EnumType"></typeparam>
    public class EnumStringConverter<EnumType> : JsonConverter<EnumType>
    {
        /// <inheritdoc/>
        public override EnumType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var stringValue = reader.GetString();
            return stringValue is not null && EnumValueAttribute.GetEnumValues(typeof(EnumType)).TryGetValue(stringValue, out var enumValue)
                ? (EnumType)enumValue
                : throw new JsonException($"Invalid enum value of '{stringValue}' for type '{typeof(EnumType).Name}'.");
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, EnumType value, JsonSerializerOptions options)
            => writer.WriteStringValue(EnumValueAttribute.GetEnumValues(typeof(EnumType)).SingleOrDefault(mapping => mapping.Value.Equals(value)).Key);
    }
}
