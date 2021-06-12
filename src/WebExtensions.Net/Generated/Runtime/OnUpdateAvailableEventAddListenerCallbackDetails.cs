using System.Text.Json.Serialization;

namespace WebExtensions.Net.Runtime
{
    // Type Class
    /// <summary>The manifest details of the available update.</summary>
    public partial class OnUpdateAvailableEventAddListenerCallbackDetails : BaseObject
    {
        private string _version;

        /// <summary>The version number of the available update.</summary>
        [JsonPropertyName("version")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Version
        {
            get
            {
                InitializeProperty("version", _version);
                return _version;
            }
            set
            {
                _version = value;
            }
        }
    }
}
