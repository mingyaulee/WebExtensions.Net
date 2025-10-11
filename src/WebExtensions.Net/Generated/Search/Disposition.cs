using System.Text.Json.Serialization;

namespace WebExtensions.Net.Search;

/// <summary>Location where search results should be displayed.</summary>
[JsonConverter(typeof(EnumStringConverter<Disposition>))]
public enum Disposition
{
    /// <summary>CURRENT_TAB</summary>
    [EnumValue("CURRENT_TAB")]
    CURRENTTAB,

    /// <summary>NEW_TAB</summary>
    [EnumValue("NEW_TAB")]
    NEWTAB,

    /// <summary>NEW_WINDOW</summary>
    [EnumValue("NEW_WINDOW")]
    NEWWINDOW,
}
