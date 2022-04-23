using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebExtensions.Net.ExtensionTypes;
using WebExtensions.Net.Manifest;

namespace WebExtensions.Net.Scripting
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class RegisteredContentScript : BaseObject
    {
        /// <summary>If specified true, it will inject into all frames, even if the frame is not the top-most frame in the tab. Each frame is checked independently for URL requirements; it will not inject into child frames if the URL requirements are not met. Defaults to false, meaning that only the top frame is matched.</summary>
        [JsonPropertyName("allFrames")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AllFrames { get; set; }

        /// <summary>The list of CSS files to be injected into matching pages. These are injected in the order they appear in this array.</summary>
        [JsonPropertyName("css")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<ExtensionUrl> Css { get; set; }

        /// <summary>Excludes pages that this content script would otherwise be injected into.</summary>
        [JsonPropertyName("excludeMatches")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> ExcludeMatches { get; set; }

        /// <summary>The id of the content script, specified in the API call.</summary>
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Id { get; set; }

        /// <summary>The list of JavaScript files to be injected into matching pages. These are injected in the order they appear in this array.</summary>
        [JsonPropertyName("js")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<ExtensionUrl> Js { get; set; }

        /// <summary>Specifies which pages this content script will be injected into. Must be specified for <c>registerContentScripts()</c>.</summary>
        [JsonPropertyName("matches")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> Matches { get; set; }

        /// <summary>Specifies if this content script will persist into future sessions. This is currently NOT supported.</summary>
        [JsonPropertyName("persistAcrossSessions")]
        public bool PersistAcrossSessions { get; set; }

        /// <summary>Specifies when JavaScript files are injected into the web page. The preferred and default value is <c>document_idle</c>.</summary>
        [JsonPropertyName("runAt")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public RunAt? RunAt { get; set; }
    }
}
