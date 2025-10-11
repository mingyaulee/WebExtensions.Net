using System.Diagnostics;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Generator.Models.Schema;

[DebuggerDisplay("{Id}")]
public class TypeDefinition : TypeReference
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }
}
