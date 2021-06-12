using System.Text.Json.Serialization;

namespace WebExtensions.Net.Sessions
{
    // Type Class
    /// <summary></summary>
    public partial class Filter : BaseObject
    {
        private int? _maxResults;

        /// <summary>The maximum number of entries to be fetched in the requested list. Omit this parameter to fetch the maximum number of entries ($(ref:sessions.MAX_SESSION_RESULTS)).</summary>
        [JsonPropertyName("maxResults")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MaxResults
        {
            get
            {
                InitializeProperty("maxResults", _maxResults);
                return _maxResults;
            }
            set
            {
                _maxResults = value;
            }
        }
    }
}
