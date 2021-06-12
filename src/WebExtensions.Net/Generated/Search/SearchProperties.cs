using System.Text.Json.Serialization;

namespace WebExtensions.Net.Search
{
    // Type Class
    /// <summary></summary>
    public partial class SearchProperties : BaseObject
    {
        private string _engine;
        private string _query;
        private int? _tabId;

        /// <summary>Search engine to use. Uses the default if not specified.</summary>
        [JsonPropertyName("engine")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Engine
        {
            get
            {
                InitializeProperty("engine", _engine);
                return _engine;
            }
            set
            {
                _engine = value;
            }
        }

        /// <summary>Terms to search for.</summary>
        [JsonPropertyName("query")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Query
        {
            get
            {
                InitializeProperty("query", _query);
                return _query;
            }
            set
            {
                _query = value;
            }
        }

        /// <summary>The ID of the tab for the search results. If not specified, a new tab is created.</summary>
        [JsonPropertyName("tabId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TabId
        {
            get
            {
                InitializeProperty("tabId", _tabId);
                return _tabId;
            }
            set
            {
                _tabId = value;
            }
        }
    }
}
