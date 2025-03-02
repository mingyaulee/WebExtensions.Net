using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest
{
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<PermissionNoPromptType3>))]
    public enum PermissionNoPromptType3
    {
        /// <summary>alarms</summary>
        [EnumValue("alarms")]
        Alarms,

        /// <summary>storage</summary>
        [EnumValue("storage")]
        Storage,

        /// <summary>unlimitedStorage</summary>
        [EnumValue("unlimitedStorage")]
        UnlimitedStorage,
    }
}
