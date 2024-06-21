using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Runtime
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class OnInstalledEventCallbackDetails : BaseObject
    {
        /// <summary>Indicates the previous version of the extension, which has just been updated. This is present only if 'reason' is 'update'.</summary>
        [JsAccessPath("previousVersion")]
        [JsonPropertyName("previousVersion")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string PreviousVersion { get; set; }

        /// <summary>The reason that this event is being dispatched.</summary>
        [JsAccessPath("reason")]
        [JsonPropertyName("reason")]
        public OnInstalledReason Reason { get; set; }

        /// <summary>Indicates whether the addon is installed as a temporary extension.</summary>
        [JsAccessPath("temporary")]
        [JsonPropertyName("temporary")]
        public bool Temporary { get; set; }
    }
}
