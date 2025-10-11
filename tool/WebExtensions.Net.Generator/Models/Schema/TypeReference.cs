using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebExtensions.Net.Generator.JsonConverters;

namespace WebExtensions.Net.Generator.Models.Schema;

public class TypeReference
{
    #region Type information

    [JsonPropertyName("type")]
    public ObjectType Type { get; set; }

    [JsonPropertyName("$extend")]
    public string? Extend { get; set; }

    [JsonPropertyName("$ref")]
    public string? Ref { get; set; }

    [JsonPropertyName("choices")]
    public IEnumerable<TypeDefinition>? TypeChoices { get; set; }

    #endregion

    #region Common information

    [JsonPropertyName("unsupported")]
    public bool IsUnsupported { get; set; }

    [JsonPropertyName("deprecated"), JsonConverter(typeof(BooleanStringConverter))]
    public string? Deprecated { get; set; }

    [JsonIgnore]
    public bool IsDeprecated => !string.IsNullOrEmpty(Deprecated);

    #endregion

    #region Integer information

    [JsonPropertyName("minimum")]
    public int? IntegerMinimum { get; set; }

    [JsonPropertyName("maximum")]
    public int? IntegerMaximum { get; set; }

    #endregion

    #region String information

    [JsonPropertyName("enum")]
    public IEnumerable<EnumValueDefinition>? EnumValues { get; set; }

    [JsonPropertyName("format")]
    public string? StringFormat { get; set; }

    [JsonPropertyName("pattern")]
    public string? StringPattern { get; set; }

    #endregion

    #region Array information

    [JsonPropertyName("minItems")]
    public int? ArrayMinumumItems { get; set; }

    [JsonPropertyName("maxItems")]
    public int? ArrayMaximumItems { get; set; }

    [JsonPropertyName("items")]
    public TypeReference? ArrayItems { get; set; }

    #endregion

    #region Object information

    [JsonPropertyName("properties")]
    public IDictionary<string, PropertyDefinition>? ObjectProperties { get; set; }

    [JsonPropertyName("functions")]
    public IEnumerable<FunctionDefinition>? ObjectFunctions { get; set; }

    #endregion

    #region Function information

    [JsonPropertyName("parameters")]
    public IEnumerable<ParameterDefinition>? FunctionParameters { get; set; }

    [JsonPropertyName("returns")]
    public FunctionReturnDefinition? FunctionReturns { get; set; }

    #endregion
}
