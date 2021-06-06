using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    /// <summary>An event that caused a muted state change.</summary>
    [JsonConverter(typeof(EnumStringConverter<MutedInfoReason>))]
    public enum MutedInfoReason
    {
        /// <summary>A user input action has set/overridden the muted state.</summary>
        [EnumValue("user")]
        User,

        /// <summary>Tab capture started, forcing a muted state change.</summary>
        [EnumValue("capture")]
        Capture,

        /// <summary>An extension, identified by the extensionId field, set the muted state.</summary>
        [EnumValue("extension")]
        Extension,
    }
}
