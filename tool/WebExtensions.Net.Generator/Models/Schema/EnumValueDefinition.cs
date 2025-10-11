using System.Diagnostics;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Generator.Models.Schema;

[DebuggerDisplay("{Name}")]
public class EnumValueDefinition
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonIgnore]
    public bool IsBoolean { get; set; }
}
