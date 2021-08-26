using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary>Tab muted state and the reason for the last state change.</summary>
    [BindAllProperties]
    public partial class MutedInfo : BaseObject
    {
        /// <summary>The ID of the extension that changed the muted state. Not set if an extension was not the reason the muted state last changed.</summary>
        [JsonPropertyName("extensionId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ExtensionId { get; set; }

        /// <summary>Whether the tab is prevented from playing sound (but hasn't necessarily recently produced sound). Equivalent to whether the muted audio indicator is showing.</summary>
        [JsonPropertyName("muted")]
        public bool Muted { get; set; }

        /// <summary>The reason the tab was muted or unmuted. Not set if the tab's mute state has never been changed.</summary>
        [JsonPropertyName("reason")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public MutedInfoReason? Reason { get; set; }
    }
}
