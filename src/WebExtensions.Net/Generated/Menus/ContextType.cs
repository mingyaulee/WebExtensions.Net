using System.Text.Json.Serialization;

namespace WebExtensions.Net.Menus;

/// <summary>The different contexts a menu can appear in. Specifying 'all' is equivalent to the combination of all other contexts except for 'tab' and 'tools_menu'.</summary>
[JsonConverter(typeof(EnumStringConverter<ContextType>))]
public enum ContextType
{
    /// <summary>all</summary>
    [EnumValue("all")]
    All,

    /// <summary>page</summary>
    [EnumValue("page")]
    Page,

    /// <summary>frame</summary>
    [EnumValue("frame")]
    Frame,

    /// <summary>selection</summary>
    [EnumValue("selection")]
    Selection,

    /// <summary>link</summary>
    [EnumValue("link")]
    Link,

    /// <summary>editable</summary>
    [EnumValue("editable")]
    Editable,

    /// <summary>password</summary>
    [EnumValue("password")]
    Password,

    /// <summary>image</summary>
    [EnumValue("image")]
    Image,

    /// <summary>video</summary>
    [EnumValue("video")]
    Video,

    /// <summary>audio</summary>
    [EnumValue("audio")]
    Audio,

    /// <summary>launcher</summary>
    [EnumValue("launcher")]
    Launcher,

    /// <summary>bookmark</summary>
    [EnumValue("bookmark")]
    Bookmark,

    /// <summary>page_action</summary>
    [EnumValue("page_action")]
    PageAction,

    /// <summary>tab</summary>
    [EnumValue("tab")]
    Tab,

    /// <summary>tools_menu</summary>
    [EnumValue("tools_menu")]
    ToolsMenu,

    /// <summary>browser_action</summary>
    [EnumValue("browser_action")]
    BrowserAction,

    /// <summary>action</summary>
    [EnumValue("action")]
    Action,
}
