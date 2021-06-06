using System.Text.Json.Serialization;

namespace WebExtension.Net.Generator.Models.Schema
{
    public class FunctionReturnDefinition : TypeReference
    {
        [JsonPropertyName("description")]
        public string? Description { get; set; }
    }
}
