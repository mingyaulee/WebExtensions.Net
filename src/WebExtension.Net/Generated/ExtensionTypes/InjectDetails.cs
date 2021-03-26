using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.ExtensionTypes
{
    // Class Definition
    /// <summary>
    /// Details of the script or CSS to inject. Either the code or the file property must be set, but both may not be set at the same time.
    /// </summary>
    public class InjectDetails : BaseObject
    {
        
        // Property Definition
        private string _code;
        /// <summary>
        /// JavaScript or CSS code to inject.
        /// 
        /// <b>Warning:</b>
        /// Be careful using the <c>code</c> parameter. Incorrect use of it may open your extension to <a href="https://en.wikipedia.org/wiki/Cross-site_scripting">cross site scripting</a> attacks.
        /// </summary>
        [JsonPropertyName("code")]
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
        
        // Property Definition
        private string _file;
        /// <summary>
        /// JavaScript or CSS file to inject.
        /// </summary>
        [JsonPropertyName("file")]
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
        
        // Property Definition
        private bool? _allFrames;
        /// <summary>
        /// If allFrames is <c>true</c>, implies that the JavaScript or CSS should be injected into all frames of current page. By default, it's <c>false</c> and is only injected into the top frame.
        /// </summary>
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
        
        // Property Definition
        private bool? _matchAboutBlank;
        /// <summary>
        /// If matchAboutBlank is true, then the code is also injected in about:blank and about:srcdoc frames if your extension has access to its parent document. Code cannot be inserted in top-level about:-frames. By default it is <c>false</c>.
        /// </summary>
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
        
        // Property Definition
        private int? _frameId;
        /// <summary>
        /// The ID of the frame to inject the script into. This may not be used in combination with <c>allFrames</c>.
        /// </summary>
        [JsonPropertyName("frameId")]
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
        
        // Property Definition
        private RunAt _runAt;
        /// <summary>
        /// The soonest that the JavaScript or CSS will be injected into the tab. Defaults to "document_idle".
        /// </summary>
        [JsonPropertyName("runAt")]
        public RunAt RunAt
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
        
        // Property Definition
        private CSSOrigin _cssOrigin;
        /// <summary>
        /// The css origin of the stylesheet to inject. Defaults to "author".
        /// </summary>
        [JsonPropertyName("cssOrigin")]
        public CSSOrigin CssOrigin
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
    }
}

