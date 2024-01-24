using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebNavigation
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class OnReferenceFragmentUpdatedEventCallbackDetails : BaseObject
    {
        /// <summary>0 indicates the navigation happens in the tab content window; a positive value indicates navigation in a subframe. Frame IDs are unique within a tab.</summary>
        [JsonPropertyName("frameId")]
        public int FrameId { get; set; }

        /// <summary>The ID of the tab in which the navigation occurs.</summary>
        [JsonPropertyName("tabId")]
        public int TabId { get; set; }

        /// <summary>The time when the navigation was committed, in milliseconds since the epoch.</summary>
        [JsonPropertyName("timeStamp")]
        public EpochTime TimeStamp { get; set; }

        /// <summary>A list of transition qualifiers.</summary>
        [JsonPropertyName("transitionQualifiers")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<TransitionQualifier> TransitionQualifiers { get; set; }

        /// <summary>Cause of the navigation.</summary>
        [JsonPropertyName("transitionType")]
        public TransitionType TransitionType { get; set; }

        /// <summary></summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Url { get; set; }
    }
}
