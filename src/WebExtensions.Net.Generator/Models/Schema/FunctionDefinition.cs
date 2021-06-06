using System.Text.Json.Serialization;
using WebExtensions.Net.Generator.JsonConverters;

namespace WebExtensions.Net.Generator.Models.Schema
{
    public class FunctionDefinition : TypeReference
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("async")]
        [JsonConverter(typeof(FunctionAsyncConverter))]
        public string? Async { get; set; }
    }
}
