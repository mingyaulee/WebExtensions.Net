using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest
{
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<OptionalPermissionType2>))]
    public enum OptionalPermissionType2
    {
        /// <summary>clipboardRead</summary>
        [EnumValue("clipboardRead")]
        ClipboardRead,

        /// <summary>clipboardWrite</summary>
        [EnumValue("clipboardWrite")]
        ClipboardWrite,

        /// <summary>geolocation</summary>
        [EnumValue("geolocation")]
        Geolocation,

        /// <summary>notifications</summary>
        [EnumValue("notifications")]
        Notifications,
    }
}
