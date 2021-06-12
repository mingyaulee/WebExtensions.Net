using System.Text.Json.Serialization;
using WebExtensions.Net.ExtensionTypes;

namespace WebExtensions.Net.History
{
    // Type Class
    /// <summary></summary>
    public partial class AddUrlDetails : BaseObject
    {
        private string _title;
        private TransitionType? _transition;
        private string _url;
        private Date _visitTime;

        /// <summary>The title of the page.</summary>
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

        /// <summary>The $(topic:transition-types)[transition type] for this visit from its referrer.</summary>
        [JsonPropertyName("transition")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TransitionType? Transition
        {
            get
            {
                InitializeProperty("transition", _transition);
                return _transition;
            }
            set
            {
                _transition = value;
            }
        }

        /// <summary>The URL to add. Must be a valid URL that can be added to history.</summary>
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

        /// <summary>The date when this visit occurred.</summary>
        [JsonPropertyName("visitTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Date VisitTime
        {
            get
            {
                InitializeProperty("visitTime", _visitTime);
                return _visitTime;
            }
            set
            {
                _visitTime = value;
            }
        }
    }
}
