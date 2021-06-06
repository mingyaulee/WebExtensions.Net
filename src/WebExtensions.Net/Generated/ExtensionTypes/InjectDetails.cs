using System.Text.Json.Serialization;

namespace WebExtensions.Net.ExtensionTypes
{
    // Type Class
    /// <summary>Details of the script or CSS to inject. Either the code or the file property must be set, but both may not be set at the same time.</summary>
    public class InjectDetails : BaseObject
    {
        private bool? _allFrames;
        private string _code;
        private CSSOrigin? _cssOrigin;
        private string _file;
        private int? _frameId;
        private bool? _matchAboutBlank;
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

        /// <summary>JavaScript or CSS code to inject.<br /><br />'b'Warning:'/b'<br />Be careful using the <c>code</c> parameter. Incorrect use of it may open your extension to <see href="https://en.wikipedia.org/wiki/Cross-site_scripting">cross site scripting</see> attacks.</summary>
        [JsonPropertyName("code")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Code
        {
            get
            {
                InitializeProperty("code", _code);
                return _code;
            }
            set
            {
                _code = value;
            }
        }

        /// <summary>The css origin of the stylesheet to inject. Defaults to "author".</summary>
        [JsonPropertyName("cssOrigin")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CSSOrigin? CssOrigin
        {
            get
            {
                InitializeProperty("cssOrigin", _cssOrigin);
                return _cssOrigin;
            }
            set
            {
                _cssOrigin = value;
            }
        }

        /// <summary>JavaScript or CSS file to inject.</summary>
        [JsonPropertyName("file")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string File
        {
            get
            {
                InitializeProperty("file", _file);
                return _file;
            }
            set
            {
                _file = value;
            }
        }

        /// <summary>The ID of the frame to inject the script into. This may not be used in combination with <c>allFrames</c>.</summary>
        [JsonPropertyName("frameId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? FrameId
        {
            get
            {
                InitializeProperty("frameId", _frameId);
                return _frameId;
            }
            set
            {
                _frameId = value;
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
