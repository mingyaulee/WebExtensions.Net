using System.Text.Json.Serialization;

namespace WebExtension.Net.Tabs
{
    /// <summary>Whether the tabs have completed loading.</summary>
    [JsonConverter(typeof(EnumStringConverter<TabStatus>))]
    public enum TabStatus
    {
        /// <summary>loading</summary>
        [EnumValue("loading")]
        Loading,

        /// <summary>complete</summary>
        [EnumValue("complete")]
        Complete,
    }
}
