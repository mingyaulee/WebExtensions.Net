using System.Text.Json.Serialization;

namespace WebExtensions.Net.UserScripts;

/// <summary>The JavaScript world for a script to execute within. <c>USER_SCRIPT</c> is the default execution environment of user scripts, <c>MAIN</c> is the web page's execution environment.</summary>
[JsonConverter(typeof(EnumStringConverter<ExecutionWorld>))]
public enum ExecutionWorld
{
    /// <summary>MAIN</summary>
    [EnumValue("MAIN")]
    MAIN,

    /// <summary>USER_SCRIPT</summary>
    [EnumValue("USER_SCRIPT")]
    USERSCRIPT,
}
