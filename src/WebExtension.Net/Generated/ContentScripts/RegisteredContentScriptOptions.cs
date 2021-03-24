// This file is auto generated at 2021-03-24T04:51:22

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.ContentScripts
{
    // Class Definition
    /// <summary>
    /// Details of a content script registered programmatically
    /// </summary>
    public class RegisteredContentScriptOptions
    {
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("matches")]
        public IEnumerable<Manifest.MatchPattern> Matches { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("excludeMatches")]
        public IEnumerable<Manifest.MatchPattern> ExcludeMatches { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("includeGlobs")]
        public IEnumerable<string> IncludeGlobs { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("excludeGlobs")]
        public IEnumerable<string> ExcludeGlobs { get; set; }
        
        // Property Definition
        /// <summary>
        /// The list of CSS files to inject
        /// </summary>
        [JsonPropertyName("css")]
        public IEnumerable<ExtensionTypes.ExtensionFileOrCode> Css { get; set; }
        
        // Property Definition
        /// <summary>
        /// The list of JS files to inject
        /// </summary>
        [JsonPropertyName("js")]
        public IEnumerable<ExtensionTypes.ExtensionFileOrCode> Js { get; set; }
        
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
        /// The soonest that the JavaScript or CSS will be injected into the tab. Defaults to "document_idle".
        /// </summary>
        [JsonPropertyName("runAt")]
        public ExtensionTypes.RunAt RunAt { get; set; }
    }
}

