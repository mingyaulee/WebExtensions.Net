using System.Text.Json.Serialization;

namespace WebExtensions.Net.History
{
    // Type Class
    /// <summary></summary>
    public partial class GetVisitsDetails : BaseObject
    {
        private string _url;

        /// <summary>The URL for which to retrieve visit information.  It must be in the format as returned from a call to history.search.</summary>
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
