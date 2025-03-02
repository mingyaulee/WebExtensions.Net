using System.Text.Json.Serialization;

namespace WebExtensions.Net.DeclarativeNetRequest
{
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<ActionType>))]
    public enum ActionType
    {
        /// <summary>block</summary>
        [EnumValue("block")]
        Block,

        /// <summary>redirect</summary>
        [EnumValue("redirect")]
        Redirect,

        /// <summary>allow</summary>
        [EnumValue("allow")]
        Allow,

        /// <summary>upgradeScheme</summary>
        [EnumValue("upgradeScheme")]
        UpgradeScheme,

        /// <summary>modifyHeaders</summary>
        [EnumValue("modifyHeaders")]
        ModifyHeaders,

        /// <summary>allowAllRequests</summary>
        [EnumValue("allowAllRequests")]
        AllowAllRequests,
    }
}
