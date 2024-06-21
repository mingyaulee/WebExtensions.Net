using JsBind.Net;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Windows
{
    // Type Class
    /// <summary>Specifies whether the $(ref:windows.Window) returned should contain a list of the $(ref:tabs.Tab) objects.</summary>
    [BindAllProperties]
    public partial class GetInfo : BaseObject
    {
        /// <summary>If true, the $(ref:windows.Window) returned will have a <c>tabs</c> property that contains a list of the $(ref:tabs.Tab) objects. The <c>Tab</c> objects only contain the <c>url</c>, <c>title</c> and <c>favIconUrl</c> properties if the extension's manifest file includes the <c>"tabs"</c> permission.</summary>
        [JsAccessPath("populate")]
        [JsonPropertyName("populate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Populate { get; set; }

        /// <summary><c>windowTypes</c> is deprecated and ignored on Firefox.</summary>
        [Obsolete("This has been marked as deprecated without a description message. Please refer to the summary comment or the official API documentation.")]
        [JsAccessPath("windowTypes")]
        [JsonPropertyName("windowTypes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<WindowType> WindowTypes { get; set; }
    }
}
