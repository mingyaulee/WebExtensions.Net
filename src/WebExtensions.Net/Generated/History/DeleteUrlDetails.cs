using System.Text.Json.Serialization;

namespace WebExtensions.Net.History
{
    // Type Class
    /// <summary></summary>
    public partial class DeleteUrlDetails : BaseObject
    {
        private string _url;

        /// <summary>The URL to remove.</summary>
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
