/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Windows
{
    /// Class Definition
    /// <summary>Specifies whether the $(ref:windows.Window) returned should contain a list of the $(ref:tabs.Tab) objects.</summary>
    public class GetInfo
    {
        
        /// Property Definition
        /// <summary>If true, the $(ref:windows.Window) returned will have a <var>tabs</var> property that contains a list of the $(ref:tabs.Tab) objects. The <code>Tab</code> objects only contain the <code>url</code>, <code>title</code> and <code>favIconUrl</code> properties if the extension's manifest file includes the <code>"tabs"</code> permission.</summary>
        [JsonPropertyName("populate")]
        public bool? Populate { get; set; }
        
        /// Property Definition
        /// <summary><code>windowTypes</code> is deprecated and ignored on Firefox.</summary>
        [Obsolete("")]
        [JsonPropertyName("windowTypes")]
        public IEnumerable<WindowType> WindowTypes { get; set; }
    }
}

