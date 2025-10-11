using System.Text.Json.Serialization;

namespace WebExtensions.Net.Menus;

/// <summary>Manifest V2 supports internal commands _execute_page_action, _execute_browser_action and _execute_sidebar_action.</summary>
[JsonConverter(typeof(EnumStringConverter<CommandType2>))]
public enum CommandType2
{
    /// <summary>_execute_browser_action</summary>
    [EnumValue("_execute_browser_action")]
    ExecuteBrowserAction,

    /// <summary>_execute_page_action</summary>
    [EnumValue("_execute_page_action")]
    ExecutePageAction,

    /// <summary>_execute_sidebar_action</summary>
    [EnumValue("_execute_sidebar_action")]
    ExecuteSidebarAction,
}
