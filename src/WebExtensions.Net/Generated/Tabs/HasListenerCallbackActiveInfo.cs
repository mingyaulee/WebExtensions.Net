using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class HasListenerCallbackActiveInfo : BaseObject
    {
        /// <summary>The ID of the tab that was previously active, if that tab is still open.</summary>
        [JsonPropertyName("previousTabId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? PreviousTabId { get; set; }

        /// <summary>The ID of the tab that has become active.</summary>
        [JsonPropertyName("tabId")]
        public int TabId { get; set; }

        /// <summary>The ID of the window the active tab changed inside of.</summary>
        [JsonPropertyName("windowId")]
        public int WindowId { get; set; }
    }
}
