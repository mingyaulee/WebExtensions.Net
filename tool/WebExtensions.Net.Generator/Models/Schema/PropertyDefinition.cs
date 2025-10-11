using System.Text.Json;
using System.Text.Json.Serialization;
using WebExtensions.Net.Generator.JsonConverters;

namespace WebExtensions.Net.Generator.Models.Schema;

public class PropertyDefinition : TypeReference
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("optional"), JsonConverter(typeof(BooleanStringConverter))]
    public string? Optional { get; set; }

    [JsonIgnore]
    public bool IsOptional => !string.IsNullOrEmpty(Optional);

    [JsonPropertyName("value")]
    public JsonElement? ConstantValue { get; set; }

    [JsonIgnore]
    public bool IsConstant => ConstantValue is not null;
}
