using System.Text.Json.Serialization;

namespace WebExtension.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    public class AddListenerCallbackMoveInfo : BaseObject
    {
        private int _fromIndex;
        private int _toIndex;
        private int _windowId;

        /// <summary></summary>
        [JsonPropertyName("fromIndex")]
        public int FromIndex
        {
            get
            {
                InitializeProperty("fromIndex", _fromIndex);
                return _fromIndex;
            }
            set
            {
                _fromIndex = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("toIndex")]
        public int ToIndex
        {
            get
            {
                InitializeProperty("toIndex", _toIndex);
                return _toIndex;
            }
            set
            {
                _toIndex = value;
            }
        }

        /// <summary></summary>
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
