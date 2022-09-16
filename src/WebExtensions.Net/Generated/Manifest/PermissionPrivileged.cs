using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest
{
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<PermissionPrivileged>))]
    public enum PermissionPrivileged
    {
        /// <summary>mozillaAddons</summary>
        [EnumValue("mozillaAddons")]
        MozillaAddons,
    }
}
