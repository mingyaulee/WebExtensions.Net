using JsBind.Net;
using System;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.UserScripts;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class UserScript : BaseObject
{
    /// <summary>Exports all the properties of a given plain object as userScript globals</summary>
    [JsAccessPath("defineGlobals")]
    [JsonPropertyName("defineGlobals")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Action<object> DefineGlobals { get; set; }

    /// <summary>Convert a given value to make it accessible to the userScript code</summary>
    [JsAccessPath("export")]
    [JsonPropertyName("export")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Func<object, object> Export { get; set; }

    /// <summary>The userScript global</summary>
    [JsAccessPath("global")]
    [JsonPropertyName("global")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object Global { get; set; }

    /// <summary>The userScript metadata (as set in userScripts.register)</summary>
    [JsAccessPath("metadata")]
    [JsonPropertyName("metadata")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object Metadata { get; set; }
}
