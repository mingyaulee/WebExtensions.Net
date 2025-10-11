using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Generator.JsonConverters;

public class BooleanStringConverter : JsonConverter<string?>
{
    public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => reader.TokenType is JsonTokenType.True or JsonTokenType.False
            ? reader.GetBoolean().ToString()
            : reader.GetString();

    public override void Write(Utf8JsonWriter writer, string? value, JsonSerializerOptions options)
    {
        if (bool.TryParse(value, out var booleanValue))
        {
            writer.WriteBooleanValue(booleanValue);
        }
        else
        {
            writer.WriteStringValue(value);
        }
    }
}
