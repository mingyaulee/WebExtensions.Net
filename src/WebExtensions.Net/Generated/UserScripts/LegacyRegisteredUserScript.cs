using JsBind.Net;
using System;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.UserScripts;

// Type Class
/// <summary>An object that represents a user script registered programmatically</summary>
[BindAllProperties]
public partial class LegacyRegisteredUserScript : BaseObject
{
    /// <summary>Unregister a user script registered programmatically</summary>
    [JsAccessPath("unregister")]
    [JsonPropertyName("unregister")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Action Unregister { get; set; }
}
