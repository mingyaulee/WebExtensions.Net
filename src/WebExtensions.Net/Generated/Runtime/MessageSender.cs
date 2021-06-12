using System.Text.Json.Serialization;
using WebExtensions.Net.Tabs;

namespace WebExtensions.Net.Runtime
{
    // Type Class
    /// <summary>An object containing information about the script context that sent a message or request.</summary>
    public partial class MessageSender : BaseObject
    {
        private int? _frameId;
        private string _id;
        private Tab _tab;
        private string _url;

        /// <summary>The $(topic:frame_ids)[frame] that opened the connection. 0 for top-level frames, positive for child frames. This will only be set when <c>tab</c> is set.</summary>
        [JsonPropertyName("frameId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? FrameId
        {
            get
            {
                InitializeProperty("frameId", _frameId);
                return _frameId;
            }
            set
            {
                _frameId = value;
            }
        }

        /// <summary>The ID of the extension or app that opened the connection, if any.</summary>
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Id
        {
            get
            {
                InitializeProperty("id", _id);
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        /// <summary>The $(ref:tabs.Tab) which opened the connection, if any. This property will 'strong'only'/strong' be present when the connection was opened from a tab (including content scripts), and 'strong'only'/strong' if the receiver is an extension, not an app.</summary>
        [JsonPropertyName("tab")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Tab Tab
        {
            get
            {
                InitializeProperty("tab", _tab);
                return _tab;
            }
            set
            {
                _tab = value;
            }
        }

        /// <summary>The URL of the page or frame that opened the connection. If the sender is in an iframe, it will be iframe's URL not the URL of the page which hosts it.</summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Url
        {
            get
            {
                InitializeProperty("url", _url);
                return _url;
            }
            set
            {
                _url = value;
            }
        }
    }
}
