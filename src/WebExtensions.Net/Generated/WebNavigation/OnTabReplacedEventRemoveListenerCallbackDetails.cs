using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebNavigation
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class OnTabReplacedEventRemoveListenerCallbackDetails : BaseObject
    {
        /// <summary>The ID of the tab that was replaced.</summary>
        [JsonPropertyName("replacedTabId")]
        public int ReplacedTabId { get; set; }

        /// <summary>The ID of the tab that replaced the old tab.</summary>
        [JsonPropertyName("tabId")]
        public int TabId { get; set; }

        /// <summary>The time when the replacement happened, in milliseconds since the epoch.</summary>
        [JsonPropertyName("timeStamp")]
        public EpochTime TimeStamp { get; set; }
    }
}
