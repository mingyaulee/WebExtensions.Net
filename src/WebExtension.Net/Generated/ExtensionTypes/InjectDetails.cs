// This file is auto generated at 2021-03-24T04:51:22

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
    public class InjectDetails
    {
        
        // Property Definition
        /// <summary>
        /// JavaScript or CSS code to inject.
        /// 
        /// <b>Warning:</b>
        /// Be careful using the <c>code</c> parameter. Incorrect use of it may open your extension to <a href="https://en.wikipedia.org/wiki/Cross-site_scripting">cross site scripting</a> attacks.
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }
        
        // Property Definition
        /// <summary>
        /// JavaScript or CSS file to inject.
        /// </summary>
        [JsonPropertyName("file")]
        public string File { get; set; }
        
        // Property Definition
        /// <summary>
        /// If allFrames is <c>true</c>, implies that the JavaScript or CSS should be injected into all frames of current page. By default, it's <c>false</c> and is only injected into the top frame.
        /// </summary>
        [JsonPropertyName("allFrames")]
        public bool? AllFrames { get; set; }
        
        // Property Definition
        /// <summary>
        /// If matchAboutBlank is true, then the code is also injected in about:blank and about:srcdoc frames if your extension has access to its parent document. Code cannot be inserted in top-level about:-frames. By default it is <c>false</c>.
        /// </summary>
        [JsonPropertyName("matchAboutBlank")]
        public bool? MatchAboutBlank { get; set; }
        
        // Property Definition
        /// <summary>
        /// The ID of the frame to inject the script into. This may not be used in combination with <c>allFrames</c>.
        /// </summary>
        [JsonPropertyName("frameId")]
        public int? FrameId { get; set; }
        
        // Property Definition
        /// <summary>
        /// The soonest that the JavaScript or CSS will be injected into the tab. Defaults to "document_idle".
        /// </summary>
        [JsonPropertyName("runAt")]
        public RunAt RunAt { get; set; }
        
        // Property Definition
        /// <summary>
        /// The css origin of the stylesheet to inject. Defaults to "author".
        /// </summary>
        [JsonPropertyName("cssOrigin")]
        public CSSOrigin CssOrigin { get; set; }
    }
}

