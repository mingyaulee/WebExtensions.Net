using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class AddListenerCallbackHighlightInfo : BaseObject
    {
        /// <summary>All highlighted tabs in the window.</summary>
        [JsonPropertyName("tabIds")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<int> TabIds { get; set; }

        /// <summary>The window whose tabs changed.</summary>
        [JsonPropertyName("windowId")]
        public int WindowId { get; set; }
    }
}
