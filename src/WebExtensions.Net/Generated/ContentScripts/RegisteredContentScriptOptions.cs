using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebExtensions.Net.ExtensionTypes;
using WebExtensions.Net.Manifest;

namespace WebExtensions.Net.ContentScripts
{
    // Type Class
    /// <summary>Details of a content script registered programmatically</summary>
    [BindAllProperties]
    public partial class RegisteredContentScriptOptions : BaseObject
    {
        /// <summary>If allFrames is <c>true</c>, implies that the JavaScript or CSS should be injected into all frames of current page. By default, it's <c>false</c> and is only injected into the top frame.</summary>
        [JsonPropertyName("allFrames")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AllFrames { get; set; }

        /// <summary>The list of CSS files to inject</summary>
        [JsonPropertyName("css")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<ExtensionFileOrCode> Css { get; set; }

        /// <summary></summary>
        [JsonPropertyName("excludeGlobs")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> ExcludeGlobs { get; set; }

        /// <summary></summary>
        [JsonPropertyName("excludeMatches")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<MatchPattern> ExcludeMatches { get; set; }

        /// <summary></summary>
        [JsonPropertyName("includeGlobs")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> IncludeGlobs { get; set; }

        /// <summary>The list of JS files to inject</summary>
        [JsonPropertyName("js")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<ExtensionFileOrCode> Js { get; set; }

        /// <summary>If matchAboutBlank is true, then the code is also injected in about:blank and about:srcdoc frames if your extension has access to its parent document. Code cannot be inserted in top-level about:-frames. By default it is <c>false</c>.</summary>
        [JsonPropertyName("matchAboutBlank")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? MatchAboutBlank { get; set; }

        /// <summary></summary>
        [JsonPropertyName("matches")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<MatchPattern> Matches { get; set; }

        /// <summary>The soonest that the JavaScript or CSS will be injected into the tab. Defaults to "document_idle".</summary>
        [JsonPropertyName("runAt")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public RunAt? RunAt { get; set; }
    }
}
