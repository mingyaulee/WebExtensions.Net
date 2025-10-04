using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebExtensions.Net.Generator.Models.Schema;

namespace WebExtensions.Net.Generator.JsonConverters
{
    public class EnumValueDefinitionConverter : JsonConverter<EnumValueDefinition>
    {
        public override EnumValueDefinition? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                return new EnumValueDefinition()
                {
                    Name = reader.GetString()
                };
            }
            else if (reader.TokenType == JsonTokenType.True || reader.TokenType == JsonTokenType.False)
            {
                return new EnumValueDefinition()
                {
                    Name = reader.GetBoolean().ToString(),
                    IsBoolean = true
                };
            }
            else
            {
                var jsonElement = JsonDocument.ParseValue(ref reader).RootElement;
                return JsonSerializer.Deserialize<EnumValueDefinition>(jsonElement.GetRawText());
            }
        }

        public override void Write(Utf8JsonWriter writer, EnumValueDefinition value, JsonSerializerOptions options)
        {
            if (string.IsNullOrEmpty(value.Description) && value.Name is not null)
            {
                if (value.IsBoolean)
                {
                    writer.WriteBooleanValue(bool.Parse(value.Name));
                }
                else
                {
                    writer.WriteStringValue(value.Name);
                }
            }
            else
            {
                JsonSerializer.Serialize(writer, value);
            }
        }
    }
}
