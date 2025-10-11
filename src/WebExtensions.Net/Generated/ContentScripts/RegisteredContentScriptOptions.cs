using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebExtensions.Net.ExtensionTypes;
using WebExtensions.Net.Manifest;

namespace WebExtensions.Net.ContentScripts;

// Type Class
/// <summary>Details of a content script registered programmatically</summary>
[BindAllProperties]
public partial class RegisteredContentScriptOptions : BaseObject
{
    /// <summary>If allFrames is <c>true</c>, implies that the JavaScript or CSS should be injected into all frames of current page. By default, it's <c>false</c> and is only injected into the top frame.</summary>
    [JsAccessPath("allFrames")]
    [JsonPropertyName("allFrames")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? AllFrames { get; set; }

    /// <summary>limit the set of matched tabs to those that belong to the given cookie store id</summary>
    [JsAccessPath("cookieStoreId")]
    [JsonPropertyName("cookieStoreId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public CookieStoreId CookieStoreId { get; set; }

    /// <summary>The list of CSS files to inject</summary>
    [JsAccessPath("css")]
    [JsonPropertyName("css")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<ExtensionFileOrCode> Css { get; set; }

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

    /// <summary></summary>
    [JsAccessPath("includeGlobs")]
    [JsonPropertyName("includeGlobs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<string> IncludeGlobs { get; set; }

    /// <summary>The list of JS files to inject</summary>
    [JsAccessPath("js")]
    [JsonPropertyName("js")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<ExtensionFileOrCode> Js { get; set; }

    /// <summary>If matchAboutBlank is true, then the code is also injected in about:blank and about:srcdoc frames if your extension has access to its parent document. Ignored if matchOriginAsFallback is specified. By default it is <c>false</c>.</summary>
    [JsAccessPath("matchAboutBlank")]
    [JsonPropertyName("matchAboutBlank")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? MatchAboutBlank { get; set; }

    /// <summary></summary>
    [JsAccessPath("matches")]
    [JsonPropertyName("matches")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<MatchPattern> Matches { get; set; }

    /// <summary>If matchOriginAsFallback is true, then the code is also injected in about:, data:, blob: when their origin matches the pattern in 'matches', even if the actual document origin is opaque (due to the use of CSP sandbox or iframe sandbox). Match patterns in 'matches' must specify a wildcard path glob. By default it is <c>false</c>.</summary>
    [JsAccessPath("matchOriginAsFallback")]
    [JsonPropertyName("matchOriginAsFallback")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? MatchOriginAsFallback { get; set; }

    /// <summary>The soonest that the JavaScript or CSS will be injected into the tab. Defaults to "document_idle".</summary>
    [JsAccessPath("runAt")]
    [JsonPropertyName("runAt")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public RunAt? RunAt { get; set; }

    /// <summary>The JavaScript world for a script to execute within. Defaults to "ISOLATED".</summary>
    [JsAccessPath("world")]
    [JsonPropertyName("world")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ExecutionWorld? World { get; set; }
}
