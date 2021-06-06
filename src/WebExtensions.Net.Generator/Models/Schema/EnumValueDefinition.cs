using System.Text.Json.Serialization;

namespace WebExtension.Net.Generator.Models.Schema
{
    public class EnumValueDefinition
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonIgnore]
        public bool IsBoolean { get; set; }
    }
}
