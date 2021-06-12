using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    public partial class AddListenerCallbackRemoveInfo : BaseObject
    {
        private bool _isWindowClosing;
        private int _windowId;

        /// <summary>True when the tab is being closed because its window is being closed.</summary>
        [JsonPropertyName("isWindowClosing")]
        public bool IsWindowClosing
        {
            get
            {
                InitializeProperty("isWindowClosing", _isWindowClosing);
                return _isWindowClosing;
            }
            set
            {
                _isWindowClosing = value;
            }
        }

        /// <summary>The window whose tab is closed.</summary>
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
