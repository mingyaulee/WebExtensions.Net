using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Generator.Models.Schema
{
    public class NamespaceSourceDefinition
    {
        [JsonIgnore]
        public string? Namespace { get; set; }

        [JsonIgnore]
        public string? HttpUrl { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("schema")]
        public string? Schema { get; set; }

        [JsonPropertyName("scopes")]
        public IEnumerable<Scope>? Scopes { get; set; }

        [JsonPropertyName("events")]
        public IEnumerable<string>? Events { get; set; }

        [JsonPropertyName("permissions")]
        public IEnumerable<string>? Permissions { get; set; }

        [JsonPropertyName("paths")]
        public IEnumerable<IEnumerable<string>>? Paths { get; set; }

        [JsonPropertyName("manifest")]
        public IEnumerable<string>? Manifest { get; set; }
    }
}
