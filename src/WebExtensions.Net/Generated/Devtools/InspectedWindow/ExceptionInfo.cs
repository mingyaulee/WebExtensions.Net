using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Devtools.InspectedWindow;

// Type Class
/// <summary>An object providing details if an exception occurred while evaluating the expression.</summary>
[BindAllProperties]
public partial class ExceptionInfo : BaseObject
{
    /// <summary>Set if the error occurred on the DevTools side before the expression is evaluated.</summary>
    [JsAccessPath("code")]
    [JsonPropertyName("code")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Code { get; set; }

    /// <summary>Set if the error occurred on the DevTools side before the expression is evaluated.</summary>
    [JsAccessPath("description")]
    [JsonPropertyName("description")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Description { get; set; }

    /// <summary>Set if the error occurred on the DevTools side before the expression is evaluated, contains the array of the values that may be substituted into the description string to provide more information about the cause of the error.</summary>
    [JsAccessPath("details")]
    [JsonPropertyName("details")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<object> Details { get; set; }

    /// <summary>Set if the error occurred on the DevTools side before the expression is evaluated.</summary>
    [JsAccessPath("isError")]
    [JsonPropertyName("isError")]
    public bool IsError { get; set; }

    /// <summary>Set if the evaluated code produces an unhandled exception.</summary>
    [JsAccessPath("isException")]
    [JsonPropertyName("isException")]
    public bool IsException { get; set; }

    /// <summary>Set if the evaluated code produces an unhandled exception.</summary>
    [JsAccessPath("value")]
    [JsonPropertyName("value")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Value { get; set; }
}
