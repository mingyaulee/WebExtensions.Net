using System;
using System.Linq;
using System.Reflection;
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
        private readonly EnumValueMapping[] enumValueMappings = GetEnumValueMappings();

        /// <inheritdoc/>
        public override EnumType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var stringValue = reader.GetString();
            var enumValue = enumValueMappings.SingleOrDefault(mapping => mapping.StringValue.Equals(stringValue))?.EnumValue;
            if (Enum.TryParse(typeof(EnumType), enumValue, true, out var result))
            {
                return (EnumType)result;
            }
            throw new JsonException($"Invalid enum value of '{stringValue}' for type '{typeof(EnumType).Name}'.");
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, EnumType value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(enumValueMappings.SingleOrDefault(mapping => mapping.EnumValue.Equals(value?.ToString()))?.StringValue);
        }

        private static EnumValueMapping[] GetEnumValueMappings()
        {
            return typeof(EnumType).GetMembers().Select(member => new EnumValueMapping(member.Name, member.GetCustomAttribute<EnumValueAttribute>()?.Value ?? member.Name)).ToArray();
        }
    }
}
