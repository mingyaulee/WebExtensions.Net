using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    public partial class RemoveListenerCallbackHighlightInfo : BaseObject
    {
        private IEnumerable<int> _tabIds;
        private int _windowId;

        /// <summary>All highlighted tabs in the window.</summary>
        [JsonPropertyName("tabIds")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<int> TabIds
        {
            get
            {
                InitializeProperty("tabIds", _tabIds);
                return _tabIds;
            }
            set
            {
                _tabIds = value;
            }
        }

        /// <summary>The window whose tabs changed.</summary>
        [JsonPropertyName("windowId")]
        public int WindowId
        {
            get
            {
                InitializeProperty("windowId", _windowId);
                return _windowId;
            }
            set
            {
                _windowId = value;
            }
        }
    }
}
