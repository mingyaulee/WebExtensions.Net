using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs;

/// <summary></summary>
[JsonConverter(typeof(EnumStringConverter<ScreenType1>))]
public enum ScreenType1
{
    /// <summary>Screen</summary>
    [EnumValue("Screen")]
    Screen,

    /// <summary>Window</summary>
    [EnumValue("Window")]
    Window,

    /// <summary>Application</summary>
    [EnumValue("Application")]
    Application,
}
