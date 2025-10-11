using System.Text.Json.Serialization;

namespace WebExtensions.Net.Extension;

/// <summary>The type of extension view.</summary>
[JsonConverter(typeof(EnumStringConverter<ViewType>))]
public enum ViewType
{
    /// <summary>tab</summary>
    [EnumValue("tab")]
    Tab,

    /// <summary>popup</summary>
    [EnumValue("popup")]
    Popup,

    /// <summary>sidebar</summary>
    [EnumValue("sidebar")]
    Sidebar,
}
