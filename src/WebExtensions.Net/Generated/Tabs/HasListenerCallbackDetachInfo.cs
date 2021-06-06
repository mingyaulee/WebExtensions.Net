using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    public class HasListenerCallbackDetachInfo : BaseObject
    {
        private int _oldPosition;
        private int _oldWindowId;

        /// <summary></summary>
        [JsonPropertyName("oldPosition")]
        public int OldPosition
        {
            get
            {
                InitializeProperty("oldPosition", _oldPosition);
                return _oldPosition;
            }
            set
            {
                _oldPosition = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("oldWindowId")]
        public int OldWindowId
        {
            get
            {
                InitializeProperty("oldWindowId", _oldWindowId);
                return _oldWindowId;
            }
            set
            {
                _oldWindowId = value;
            }
        }
    }
}
