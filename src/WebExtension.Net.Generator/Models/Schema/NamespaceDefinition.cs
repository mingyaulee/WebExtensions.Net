using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtension.Net.Generator.Models.Schema
{
    public class NamespaceDefinition
    {
        [JsonIgnore]
        public NamespaceSourceDefinition? Source { get; set; }

        [JsonPropertyName("namespace")]
        public string? Namespace { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("permissions")]
        public IEnumerable<string>? Permissions { get; set; }

        [JsonPropertyName("types")]
        public IEnumerable<TypeDefinition>? Types { get; set; }

        [JsonPropertyName("properties")]
        public IDictionary<string, PropertyDefinition>? Properties { get; set; }

        [JsonPropertyName("functions")]
        public IEnumerable<FunctionDefinition>? Functions { get; set; }

        [JsonPropertyName("events")]
        public IEnumerable<EventDefinition>? Events { get; set; }
    }
}
