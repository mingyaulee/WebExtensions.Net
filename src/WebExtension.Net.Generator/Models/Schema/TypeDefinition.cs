using System.Text.Json.Serialization;

namespace WebExtension.Net.Generator.Models.Schema
{
    public class TypeDefinition : TypeReference
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }
    }
}
