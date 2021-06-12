using System.Text.Json.Serialization;

namespace WebExtensions.Net.History
{
    // Type Class
    /// <summary></summary>
    public partial class HasListenerCallbackChanged : BaseObject
    {
        private string _title;
        private string _url;

        /// <summary>The new title for the URL.</summary>
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Title
        {
            get
            {
                InitializeProperty("title", _title);
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        /// <summary>The URL for which the title has changed</summary>
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
