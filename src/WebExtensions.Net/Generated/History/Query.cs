using System.Text.Json.Serialization;
using WebExtensions.Net.ExtensionTypes;

namespace WebExtensions.Net.History
{
    // Type Class
    /// <summary></summary>
    public partial class Query : BaseObject
    {
        private Date _endTime;
        private int? _maxResults;
        private Date _startTime;
        private string _text;

        /// <summary>Limit results to those visited before this date.</summary>
        [JsonPropertyName("endTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Date EndTime
        {
            get
            {
                InitializeProperty("endTime", _endTime);
                return _endTime;
            }
            set
            {
                _endTime = value;
            }
        }

        /// <summary>The maximum number of results to retrieve.  Defaults to 100.</summary>
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

        /// <summary>Limit results to those visited after this date. If not specified, this defaults to 24 hours in the past.</summary>
        [JsonPropertyName("startTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Date StartTime
        {
            get
            {
                InitializeProperty("startTime", _startTime);
                return _startTime;
            }
            set
            {
                _startTime = value;
            }
        }

        /// <summary>A free-text query to the history service.  Leave empty to retrieve all pages.</summary>
        [JsonPropertyName("text")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Text
        {
            get
            {
                InitializeProperty("text", _text);
                return _text;
            }
            set
            {
                _text = value;
            }
        }
    }
}
