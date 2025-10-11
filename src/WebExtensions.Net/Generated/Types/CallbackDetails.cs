using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Types;

// Type Class
/// <summary>Details of the currently effective value.</summary>
[BindAllProperties]
public partial class CallbackDetails : BaseObject
{
    /// <summary>Whether the effective value is specific to the incognito session.<br/>This property will <em>only</em> be present if the <c>incognito</c> property in the <c>details</c> parameter of <c>get()</c> was true.</summary>
    [JsAccessPath("incognitoSpecific")]
    [JsonPropertyName("incognitoSpecific")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IncognitoSpecific { get; set; }

    /// <summary>The level of control of the setting.</summary>
    [JsAccessPath("levelOfControl")]
    [JsonPropertyName("levelOfControl")]
    public LevelOfControl LevelOfControl { get; set; }

    /// <summary>The value of the setting.</summary>
    [JsAccessPath("value")]
    [JsonPropertyName("value")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object Value { get; set; }
}
