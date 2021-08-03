using System.Text.Json.Serialization;

namespace WebExtensions.Net.Search
{
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<Disposition>))]
    public enum Disposition
    {
        /// <summary>Current Tab</summary>
        [EnumValue("CURRENT_TAB")]
        CurrentTab,

        /// <summary>New Tab</summary>
        [EnumValue("NEW_TAB")]
        NewTab,

        /// <summary>New Window</summary>
        [EnumValue("NEW_WINDOW")]
        NewWindow

    }
}
