using System.Text.Json.Serialization;

namespace WebExtension.Net.Manifest
{
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<OptionalPermissionNoPrompt>))]
    public enum OptionalPermissionNoPrompt
    {
        /// <summary>idle</summary>
        [EnumValue("idle")]
        Idle,
    }
}
