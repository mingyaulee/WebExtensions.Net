using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebExtensions.Net.ExtensionTypes;
using WebExtensions.Net.Manifest;

namespace WebExtensions.Net.UserScripts;

// Type Class
/// <summary>An object that represents a user script registered programmatically</summary>
[BindAllProperties]
public partial class RegisteredUserScript : BaseObject
{
    /// <summary>If allFrames is <c>true</c>, implies that the JavaScript should be injected into all frames of current page. By default, it's <c>false</c> and is only injected into the top frame.</summary>
    [JsAccessPath("allFrames")]
    [JsonPropertyName("allFrames")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? AllFrames { get; set; }

    /// <summary></summary>
    [JsAccessPath("excludeGlobs")]
    [JsonPropertyName("excludeGlobs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<string> ExcludeGlobs { get; set; }

    /// <summary></summary>
    [JsAccessPath("excludeMatches")]
    [JsonPropertyName("excludeMatches")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<MatchPattern> ExcludeMatches { get; set; }

    /// <summary>The ID of the user script specified in the API call. This property must not start with a '_' as it's reserved as a prefix for generated script IDs.</summary>
    [JsAccessPath("id")]
    [JsonPropertyName("id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Id { get; set; }

    /// <summary>At least one of matches or includeGlobs should be non-empty. The script runs in documents whose URL match either pattern.</summary>
    [JsAccessPath("includeGlobs")]
    [JsonPropertyName("includeGlobs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<string> IncludeGlobs { get; set; }

    /// <summary>The list of ScriptSource objects defining sources of scripts to be injected into matching pages.</summary>
    [JsAccessPath("js")]
    [JsonPropertyName("js")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<ScriptSource> Js { get; set; }

    /// <summary>At least one of matches or includeGlobs should be non-empty. The script runs in documents whose URL match either pattern.</summary>
    [JsAccessPath("matches")]
    [JsonPropertyName("matches")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<MatchPattern> Matches { get; set; }

    /// <summary>The soonest that the JavaScript will be injected into the tab. Defaults to "document_idle".</summary>
    [JsAccessPath("runAt")]
    [JsonPropertyName("runAt")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public RunAt? RunAt { get; set; }

    /// <summary>The JavaScript script for a script to execute within. Defaults to "USER_SCRIPT".</summary>
    [JsAccessPath("world")]
    [JsonPropertyName("world")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ExecutionWorld? World { get; set; }

    /// <summary>If specified, specifies a specific user script world ID to execute in. Only valid if `world` is omitted or is `USER_SCRIPT`. If `worldId` is omitted, the script will execute in the default user script world (""). Values with leading underscores (`_`) are reserved. The maximum length is 256.</summary>
    [JsAccessPath("worldId")]
    [JsonPropertyName("worldId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string WorldId { get; set; }
}
