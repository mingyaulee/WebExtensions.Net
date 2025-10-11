using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Generator.JsonConverters;

public class FunctionAsyncConverter : JsonConverter<string?>
{
    public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => reader.TokenType == JsonTokenType.True ? "void" : reader.GetString();

    public override void Write(Utf8JsonWriter writer, string? value, JsonSerializerOptions options)
    {
        if (value == "void")
        {
            writer.WriteBooleanValue(true);
        }
        else
        {
            writer.WriteStringValue(value);
        }
    }
}
