using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class AddListenerCallbackRemoveInfo : BaseObject
    {
        /// <summary>True when the tab is being closed because its window is being closed.</summary>
        [JsonPropertyName("isWindowClosing")]
        public bool IsWindowClosing { get; set; }

        /// <summary>The window whose tab is closed.</summary>
        [JsonPropertyName("windowId")]
        public int WindowId { get; set; }
    }
}
