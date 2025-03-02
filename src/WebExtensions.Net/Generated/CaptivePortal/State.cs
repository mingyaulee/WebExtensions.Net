using System.Text.Json.Serialization;

namespace WebExtensions.Net.CaptivePortal
{
    /// <summary>The current captive portal state.</summary>
    [JsonConverter(typeof(EnumStringConverter<State>))]
    public enum State
    {
        /// <summary>unknown</summary>
        [EnumValue("unknown")]
        Unknown,

        /// <summary>not_captive</summary>
        [EnumValue("not_captive")]
        NotCaptive,

        /// <summary>unlocked_portal</summary>
        [EnumValue("unlocked_portal")]
        UnlockedPortal,

        /// <summary>locked_portal</summary>
        [EnumValue("locked_portal")]
        LockedPortal,
    }
}
