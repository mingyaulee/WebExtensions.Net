using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.History
{
    // Type Class
    /// <summary>An object encapsulating one visit to a URL.</summary>
    [BindAllProperties]
    public partial class VisitItem : BaseObject
    {
        /// <summary>The unique identifier for the item.</summary>
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Id { get; set; }

        /// <summary>The visit ID of the referrer.</summary>
        [JsonPropertyName("referringVisitId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ReferringVisitId { get; set; }

        /// <summary>The $(topic:transition-types)[transition type] for this visit from its referrer.</summary>
        [JsonPropertyName("transition")]
        public TransitionType Transition { get; set; }

        /// <summary>The unique identifier for this visit.</summary>
        [JsonPropertyName("visitId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string VisitId { get; set; }

        /// <summary>When this visit occurred, represented in milliseconds since the epoch.</summary>
        [JsonPropertyName("visitTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EpochTime? VisitTime { get; set; }
    }
}
