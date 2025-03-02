using System.Text.Json.Serialization;

namespace WebExtensions.Net.Menus
{
    /// <summary>ContextType to override, to allow menu items from other extensions in the menu. Currently only 'bookmark' and 'tab' are supported. showDefaults cannot be used with this option.</summary>
    [JsonConverter(typeof(EnumStringConverter<Context>))]
    public enum Context
    {
        /// <summary>bookmark</summary>
        [EnumValue("bookmark")]
        Bookmark,

        /// <summary>tab</summary>
        [EnumValue("tab")]
        Tab,
    }
}
