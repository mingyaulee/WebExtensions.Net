using System.Text.Json;
using WebExtension.Net.Generator.JsonConverters;

namespace WebExtension.Net.Generator
{
    public static class JsonSerializerConstant
    {
        public static readonly JsonSerializerOptions Options;

        static JsonSerializerConstant()
        {
            Options = new JsonSerializerOptions()
            {
                ReadCommentHandling = JsonCommentHandling.Skip
            };
            Options.Converters.Add(new EnumValueDefinitionConverter());
        }
    }
}
