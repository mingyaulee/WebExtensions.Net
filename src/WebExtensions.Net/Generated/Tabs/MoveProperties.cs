using System.Text.Json.Serialization;

namespace WebExtension.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    public class MoveProperties : BaseObject
    {
        private int _index;
        private int? _windowId;

        /// <summary>The position to move the window to. -1 will place the tab at the end of the window.</summary>
        [JsonPropertyName("index")]
        public int Index
        {
            get
            {
                InitializeProperty("index", _index);
                return _index;
            }
            set
            {
                _index = value;
            }
        }

        /// <summary>Defaults to the window the tab is currently in.</summary>
        [JsonPropertyName("windowId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? WindowId
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
