using System.Text.Json;
using WebExtension.Net.Generator.JsonConverters;

namespace WebExtension.Net.Generator
{
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
}
