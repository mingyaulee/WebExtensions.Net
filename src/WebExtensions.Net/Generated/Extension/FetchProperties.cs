using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Extension
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class FetchProperties : BaseObject
    {
        /// <summary>Find a view according to a tab id. If this field is omitted, returns all views.</summary>
        [JsonPropertyName("tabId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TabId { get; set; }

        /// <summary>The type of view to get. If omitted, returns all views (including background pages and tabs). Valid values: 'tab', 'popup', 'sidebar'.</summary>
        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ViewType? Type { get; set; }

        /// <summary>The window to restrict the search to. If omitted, returns all views.</summary>
        [JsonPropertyName("windowId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? WindowId { get; set; }
    }
}
