using System.Text.Json.Serialization;

namespace WebExtensions.Net.ActivityLog;

/// <summary>The type of view where the activity occurred.  Content scripts will not have a viewType.</summary>
[JsonConverter(typeof(EnumStringConverter<ViewType>))]
public enum ViewType
{
    /// <summary>background</summary>
    [EnumValue("background")]
    Background,

    /// <summary>popup</summary>
    [EnumValue("popup")]
    Popup,

    /// <summary>sidebar</summary>
    [EnumValue("sidebar")]
    Sidebar,

    /// <summary>tab</summary>
    [EnumValue("tab")]
    Tab,

    /// <summary>devtools_page</summary>
    [EnumValue("devtools_page")]
    DevtoolsPage,

    /// <summary>devtools_panel</summary>
    [EnumValue("devtools_panel")]
    DevtoolsPanel,
}
