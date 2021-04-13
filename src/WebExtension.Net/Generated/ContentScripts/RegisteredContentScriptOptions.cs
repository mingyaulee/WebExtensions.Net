using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtension.Net.ContentScripts
{
    // Type Class
    /// <summary>Details of a content script registered programmatically</summary>
    public class RegisteredContentScriptOptions : BaseObject
    {
        private IEnumerable<Manifest.MatchPattern> _matches;
        private IEnumerable<Manifest.MatchPattern> _excludeMatches;
        private IEnumerable<string> _includeGlobs;
        private IEnumerable<string> _excludeGlobs;
        private IEnumerable<ExtensionTypes.ExtensionFileOrCode> _css;
        private IEnumerable<ExtensionTypes.ExtensionFileOrCode> _js;
        private bool? _allFrames;
        private bool? _matchAboutBlank;
        private ExtensionTypes.RunAt _runAt;

        /// <summary></summary>
        [JsonPropertyName("matches")]
        public IEnumerable<Manifest.MatchPattern> Matches
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

        /// <summary></summary>
        [JsonPropertyName("excludeMatches")]
        public IEnumerable<Manifest.MatchPattern> ExcludeMatches
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

        /// <summary></summary>
        [JsonPropertyName("excludeGlobs")]
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

        /// <summary>The list of CSS files to inject</summary>
        [JsonPropertyName("css")]
        public IEnumerable<ExtensionTypes.ExtensionFileOrCode> Css
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

        /// <summary>The list of JS files to inject</summary>
        [JsonPropertyName("js")]
        public IEnumerable<ExtensionTypes.ExtensionFileOrCode> Js
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

        /// <summary>If allFrames is <c>true</c>, implies that the JavaScript or CSS should be injected into all frames of current page. By default, it's <c>false</c> and is only injected into the top frame.</summary>
        [JsonPropertyName("allFrames")]
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

        /// <summary>If matchAboutBlank is true, then the code is also injected in about:blank and about:srcdoc frames if your extension has access to its parent document. Code cannot be inserted in top-level about:-frames. By default it is <c>false</c>.</summary>
        [JsonPropertyName("matchAboutBlank")]
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

        /// <summary>The soonest that the JavaScript or CSS will be injected into the tab. Defaults to "document_idle".</summary>
        [JsonPropertyName("runAt")]
        public ExtensionTypes.RunAt RunAt
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
