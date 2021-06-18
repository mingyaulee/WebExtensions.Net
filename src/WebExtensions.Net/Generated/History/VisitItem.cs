using System.Text.Json.Serialization;

namespace WebExtensions.Net.History
{
    // Type Class
    /// <summary>An object encapsulating one visit to a URL.</summary>
    public partial class VisitItem : BaseObject
    {
        private string _id;
        private string _referringVisitId;
        private TransitionType _transition;
        private string _visitId;
        private long? _visitTime;

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

        /// <summary>The visit ID of the referrer.</summary>
        [JsonPropertyName("referringVisitId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ReferringVisitId
        {
            get
            {
                InitializeProperty("referringVisitId", _referringVisitId);
                return _referringVisitId;
            }
            set
            {
                _referringVisitId = value;
            }
        }

        /// <summary>The $(topic:transition-types)[transition type] for this visit from its referrer.</summary>
        [JsonPropertyName("transition")]
        public TransitionType Transition
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

        /// <summary>The unique identifier for this visit.</summary>
        [JsonPropertyName("visitId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string VisitId
        {
            get
            {
                InitializeProperty("visitId", _visitId);
                return _visitId;
            }
            set
            {
                _visitId = value;
            }
        }

        /// <summary>When this visit occurred, represented in milliseconds since the epoch.</summary>
        [JsonPropertyName("visitTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? VisitTime
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
