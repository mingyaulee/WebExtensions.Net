using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebExtension.Net.ExtensionTypes;
using WebExtension.Net.Manifest;

namespace WebExtension.Net.ContentScripts
{
    // Type Class
    /// <summary>Details of a content script registered programmatically</summary>
    public class RegisteredContentScriptOptions : BaseObject
    {
        private bool? _allFrames;
        private IEnumerable<ExtensionFileOrCode> _css;
        private IEnumerable<string> _excludeGlobs;
        private IEnumerable<MatchPattern> _excludeMatches;
        private IEnumerable<string> _includeGlobs;
        private IEnumerable<ExtensionFileOrCode> _js;
        private bool? _matchAboutBlank;
        private IEnumerable<MatchPattern> _matches;
        private RunAt? _runAt;

        /// <summary>If allFrames is <c>true</c>, implies that the JavaScript or CSS should be injected into all frames of current page. By default, it's <c>false</c> and is only injected into the top frame.</summary>
        [JsonPropertyName("allFrames")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AllFrames
        {
            get
            {
                InitializeProperty("allFrames", _allFrames);
                return _allFrames;
            }
            set
            {
                _allFrames = value;
            }
        }

        /// <summary>The list of CSS files to inject</summary>
        [JsonPropertyName("css")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<ExtensionFileOrCode> Css
        {
            get
            {
                InitializeProperty("css", _css);
                return _css;
            }
            set
            {
                _css = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("excludeGlobs")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> ExcludeGlobs
        {
            get
            {
                InitializeProperty("excludeGlobs", _excludeGlobs);
                return _excludeGlobs;
            }
            set
            {
                _excludeGlobs = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("excludeMatches")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<MatchPattern> ExcludeMatches
        {
            get
            {
                InitializeProperty("excludeMatches", _excludeMatches);
                return _excludeMatches;
            }
            set
            {
                _excludeMatches = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("includeGlobs")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> IncludeGlobs
        {
            get
            {
                InitializeProperty("includeGlobs", _includeGlobs);
                return _includeGlobs;
            }
            set
            {
                _includeGlobs = value;
            }
        }

        /// <summary>The list of JS files to inject</summary>
        [JsonPropertyName("js")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<ExtensionFileOrCode> Js
        {
            get
            {
                InitializeProperty("js", _js);
                return _js;
            }
            set
            {
                _js = value;
            }
        }

        /// <summary>If matchAboutBlank is true, then the code is also injected in about:blank and about:srcdoc frames if your extension has access to its parent document. Code cannot be inserted in top-level about:-frames. By default it is <c>false</c>.</summary>
        [JsonPropertyName("matchAboutBlank")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? MatchAboutBlank
        {
            get
            {
                InitializeProperty("matchAboutBlank", _matchAboutBlank);
                return _matchAboutBlank;
            }
            set
            {
                _matchAboutBlank = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("matches")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<MatchPattern> Matches
        {
            get
            {
                InitializeProperty("matches", _matches);
                return _matches;
            }
            set
            {
                _matches = value;
            }
        }

        /// <summary>The soonest that the JavaScript or CSS will be injected into the tab. Defaults to "document_idle".</summary>
        [JsonPropertyName("runAt")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public RunAt? RunAt
        {
            get
            {
                InitializeProperty("runAt", _runAt);
                return _runAt;
            }
            set
            {
                _runAt = value;
            }
        }
    }
}
