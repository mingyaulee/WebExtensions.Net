using System.Text.Json.Serialization;

namespace WebExtensions.Net.Menus
{
    /// <summary>Manifest V3 supports internal commands _execute_page_action, _execute_action and _execute_sidebar_action.</summary>
    [JsonConverter(typeof(EnumStringConverter<CommandType3>))]
    public enum CommandType3
    {
        /// <summary>_execute_action</summary>
        [EnumValue("_execute_action")]
        ExecuteAction,

        /// <summary>_execute_page_action</summary>
        [EnumValue("_execute_page_action")]
        ExecutePageAction,

        /// <summary>_execute_sidebar_action</summary>
        [EnumValue("_execute_sidebar_action")]
        ExecuteSidebarAction,
    }
}
