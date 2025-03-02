using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest
{
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<OptionalOnlyPermission>))]
    public enum OptionalOnlyPermission
    {
        /// <summary>trialML</summary>
        [EnumValue("trialML")]
        TrialML,

        /// <summary>userScripts</summary>
        [EnumValue("userScripts")]
        UserScripts,
    }
}
