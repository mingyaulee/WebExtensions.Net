using System.Text.Json;
using WebExtensions.Net.Generator.JsonConverters;

namespace WebExtensions.Net.Generator;

public static class JsonSerializerConstant
{
    public static readonly JsonSerializerOptions Options = new()
    {
        ReadCommentHandling = JsonCommentHandling.Skip
    };

    static JsonSerializerConstant()
    {
        Options.Converters.Add(new EnumValueDefinitionConverter());
    }
}
