using System.Text.Json.Serialization;

namespace WebExtensions.Net.History
{
    // Type Class
    /// <summary>An object encapsulating one result of a history query.</summary>
    public partial class HistoryItem : BaseObject
    {
        private string _id;
        private double? _lastVisitTime;
        private string _title;
        private int? _typedCount;
        private string _url;
        private int? _visitCount;

        /// <summary>The unique identifier for the item.</summary>
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

        /// <summary>When this page was last loaded, represented in milliseconds since the epoch.</summary>
        [JsonPropertyName("lastVisitTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? LastVisitTime
        {
            get
            {
                InitializeProperty("lastVisitTime", _lastVisitTime);
                return _lastVisitTime;
            }
            set
            {
                _lastVisitTime = value;
            }
        }

        /// <summary>The title of the page when it was last loaded.</summary>
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

        /// <summary>The number of times the user has navigated to this page by typing in the address.</summary>
        [JsonPropertyName("typedCount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TypedCount
        {
            get
            {
                InitializeProperty("typedCount", _typedCount);
                return _typedCount;
            }
            set
            {
                _typedCount = value;
            }
        }

        /// <summary>The URL navigated to by a user.</summary>
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

        /// <summary>The number of times the user has navigated to this page.</summary>
        [JsonPropertyName("visitCount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? VisitCount
        {
            get
            {
                InitializeProperty("visitCount", _visitCount);
                return _visitCount;
            }
            set
            {
                _visitCount = value;
            }
        }
    }
}
