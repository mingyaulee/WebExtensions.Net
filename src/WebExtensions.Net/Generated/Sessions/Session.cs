using JsBind.Net;
using System.Text.Json.Serialization;
using WebExtensions.Net.Tabs;
using WebExtensions.Net.Windows;

namespace WebExtensions.Net.Sessions
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class Session : BaseObject
    {
        /// <summary>The time when the window or tab was closed or modified, represented in milliseconds since the epoch.</summary>
        [JsAccessPath("lastModified")]
        [JsonPropertyName("lastModified")]
        public EpochTime LastModified { get; set; }

        /// <summary>The $(ref:tabs.Tab), if this entry describes a tab. Either this or $(ref:sessions.Session.window) will be set.</summary>
        [JsAccessPath("tab")]
        [JsonPropertyName("tab")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Tab Tab { get; set; }

        /// <summary>The $(ref:windows.Window), if this entry describes a window. Either this or $(ref:sessions.Session.tab) will be set.</summary>
        [JsAccessPath("window")]
        [JsonPropertyName("window")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Window Window { get; set; }
    }
}
