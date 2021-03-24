// This file is auto generated at 2021-03-24T04:51:22

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Manifest
{
    // Class Definition
    /// <summary>
    /// Details of the script or CSS to inject. Either the code or the file property must be set, but both may not be set at the same time. Based on InjectDetails, but using underscore rather than camel case naming conventions.
    /// </summary>
    public class ContentScript
    {
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("matches")]
        public IEnumerable<MatchPattern> Matches { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("exclude_matches")]
        public IEnumerable<MatchPattern> Exclude_matches { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("include_globs")]
        public IEnumerable<string> Include_globs { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("exclude_globs")]
        public IEnumerable<string> Exclude_globs { get; set; }
        
        // Property Definition
        /// <summary>
        /// The list of CSS files to inject
        /// </summary>
        [JsonPropertyName("css")]
        public IEnumerable<ExtensionURL> Css { get; set; }
        
        // Property Definition
        /// <summary>
        /// The list of JS files to inject
        /// </summary>
        [JsonPropertyName("js")]
        public IEnumerable<ExtensionURL> Js { get; set; }
        
        // Property Definition
        /// <summary>
        /// If allFrames is <c>true</c>, implies that the JavaScript or CSS should be injected into all frames of current page. By default, it's <c>false</c> and is only injected into the top frame.
        /// </summary>
        [JsonPropertyName("all_frames")]
        public bool? All_frames { get; set; }
        
        // Property Definition
        /// <summary>
        /// If matchAboutBlank is true, then the code is also injected in about:blank and about:srcdoc frames if your extension has access to its parent document. Code cannot be inserted in top-level about:-frames. By default it is <c>false</c>.
        /// </summary>
        [JsonPropertyName("match_about_blank")]
        public bool? Match_about_blank { get; set; }
        
        // Property Definition
        /// <summary>
        /// The soonest that the JavaScript or CSS will be injected into the tab. Defaults to "document_idle".
        /// </summary>
        [JsonPropertyName("run_at")]
        public ExtensionTypes.RunAt Run_at { get; set; }
    }
}

