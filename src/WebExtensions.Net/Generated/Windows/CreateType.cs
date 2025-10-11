using System.Text.Json.Serialization;

namespace WebExtensions.Net.Windows;

/// <summary>Specifies what type of browser window to create. The 'panel' and 'detached_panel' types create a popup unless the '--enable-panels' flag is set.</summary>
[JsonConverter(typeof(EnumStringConverter<CreateType>))]
public enum CreateType
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

    /// <summary>detached_panel</summary>
    [EnumValue("detached_panel")]
    DetachedPanel,
}
