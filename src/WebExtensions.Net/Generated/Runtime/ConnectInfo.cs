using System.Text.Json.Serialization;

namespace WebExtensions.Net.Runtime
{
    // Type Class
    /// <summary></summary>
    public partial class ConnectInfo : BaseObject
    {
        private bool? _includeTlsChannelId;
        private string _name;

        /// <summary>Whether the TLS channel ID will be passed into onConnectExternal for processes that are listening for the connection event.</summary>
        [JsonPropertyName("includeTlsChannelId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IncludeTlsChannelId
        {
            get
            {
                InitializeProperty("includeTlsChannelId", _includeTlsChannelId);
                return _includeTlsChannelId;
            }
            set
            {
                _includeTlsChannelId = value;
            }
        }

        /// <summary>Will be passed into onConnect for processes that are listening for the connection event.</summary>
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Name
        {
            get
            {
                InitializeProperty("name", _name);
                return _name;
            }
            set
            {
                _name = value;
            }
        }
    }
}
