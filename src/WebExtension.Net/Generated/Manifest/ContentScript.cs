using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebExtension.Net.ExtensionTypes;

namespace WebExtension.Net.Manifest
{
    // Type Class
    /// <summary>Details of the script or CSS to inject. Either the code or the file property must be set, but both may not be set at the same time. Based on InjectDetails, but using underscore rather than camel case naming conventions.</summary>
    public class ContentScript : BaseObject
    {
        private bool? _all_frames;
        private IEnumerable<ExtensionURL> _css;
        private IEnumerable<string> _exclude_globs;
        private IEnumerable<MatchPattern> _exclude_matches;
        private IEnumerable<string> _include_globs;
        private IEnumerable<ExtensionURL> _js;
        private bool? _match_about_blank;
        private IEnumerable<MatchPattern> _matches;
        private RunAt _run_at;

        /// <summary>If allFrames is <c>true</c>, implies that the JavaScript or CSS should be injected into all frames of current page. By default, it's <c>false</c> and is only injected into the top frame.</summary>
        [JsonPropertyName("all_frames")]
        public bool? All_frames
        {
            get
            {
                InitializeProperty("all_frames", _all_frames);
                return _all_frames;
            }
            set
            {
                _all_frames = value;
            }
        }

        /// <summary>The list of CSS files to inject</summary>
        [JsonPropertyName("css")]
        public IEnumerable<ExtensionURL> Css
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
        [JsonPropertyName("exclude_globs")]
        public IEnumerable<string> Exclude_globs
        {
            get
            {
                InitializeProperty("exclude_globs", _exclude_globs);
                return _exclude_globs;
            }
            set
            {
                _exclude_globs = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("exclude_matches")]
        public IEnumerable<MatchPattern> Exclude_matches
        {
            get
            {
                InitializeProperty("exclude_matches", _exclude_matches);
                return _exclude_matches;
            }
            set
            {
                _exclude_matches = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("include_globs")]
        public IEnumerable<string> Include_globs
        {
            get
            {
                InitializeProperty("include_globs", _include_globs);
                return _include_globs;
            }
            set
            {
                _include_globs = value;
            }
        }

        /// <summary>The list of JS files to inject</summary>
        [JsonPropertyName("js")]
        public IEnumerable<ExtensionURL> Js
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
        [JsonPropertyName("match_about_blank")]
        public bool? Match_about_blank
        {
            get
            {
                InitializeProperty("match_about_blank", _match_about_blank);
                return _match_about_blank;
            }
            set
            {
                _match_about_blank = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("matches")]
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
        [JsonPropertyName("run_at")]
        public RunAt Run_at
        {
            get
            {
                InitializeProperty("run_at", _run_at);
                return _run_at;
            }
            set
            {
                _run_at = value;
            }
        }
    }
}
