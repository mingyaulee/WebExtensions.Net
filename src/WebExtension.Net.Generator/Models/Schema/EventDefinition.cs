using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtension.Net.Generator.Models.Schema
{
    public class EventDefinition : TypeReference
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("extraParameters")]
        public IEnumerable<ParameterDefinition>? ExtraParameters { get; set; }
    }
}
