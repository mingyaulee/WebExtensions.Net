using System.Text.Json.Serialization;

namespace WebExtension.Net.Notifications
{
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<PermissionLevel>))]
    public enum PermissionLevel
    {
        /// <summary>granted</summary>
        [EnumValue("granted")]
        Granted,

        /// <summary>denied</summary>
        [EnumValue("denied")]
        Denied,
    }
}
