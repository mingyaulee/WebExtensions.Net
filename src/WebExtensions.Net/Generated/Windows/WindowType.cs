using System.Text.Json.Serialization;

namespace WebExtensions.Net.Windows
{
    /// <summary>The type of browser window this is. Under some circumstances a Window may not be assigned type property, for example when querying closed windows from the $(ref:sessions) API.</summary>
    [JsonConverter(typeof(EnumStringConverter<WindowType>))]
    public enum WindowType
    {
        /// <summary>normal</summary>
        [EnumValue("normal")]
        Normal,

        /// <summary>popup</summary>
        [EnumValue("popup")]
        Popup,

        /// <summary>panel</summary>
        [EnumValue("panel")]
        Panel,

        /// <summary>app</summary>
        [EnumValue("app")]
        App,

        /// <summary>devtools</summary>
        [EnumValue("devtools")]
        Devtools,
    }
}
