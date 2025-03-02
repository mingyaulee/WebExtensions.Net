using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest
{
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<PermissionType3>))]
    public enum PermissionType3
    {
        /// <summary>declarativeNetRequest</summary>
        [EnumValue("declarativeNetRequest")]
        DeclarativeNetRequest,
    }
}
