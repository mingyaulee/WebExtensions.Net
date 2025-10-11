using System.Text.Json.Serialization;

namespace WebExtensions.Net.Runtime;

/// <summary>The type of extension view.</summary>
[JsonConverter(typeof(EnumStringConverter<ContextType>))]
public enum ContextType
{
    /// <summary>BACKGROUND</summary>
    [EnumValue("BACKGROUND")]
    BACKGROUND,

    /// <summary>POPUP</summary>
    [EnumValue("POPUP")]
    POPUP,

    /// <summary>SIDE_PANEL</summary>
    [EnumValue("SIDE_PANEL")]
    SIDEPANEL,

    /// <summary>TAB</summary>
    [EnumValue("TAB")]
    TAB,
}
