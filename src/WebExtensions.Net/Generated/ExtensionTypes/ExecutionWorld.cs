using System.Text.Json.Serialization;

namespace WebExtensions.Net.ExtensionTypes;

/// <summary>The JavaScript world for a script to execute within. <c>ISOLATED</c> is the default execution environment of content scripts, <c>MAIN</c> is the web page's execution environment.</summary>
[JsonConverter(typeof(EnumStringConverter<ExecutionWorld>))]
public enum ExecutionWorld
{
    /// <summary>ISOLATED</summary>
    [EnumValue("ISOLATED")]
    ISOLATED,

    /// <summary>MAIN</summary>
    [EnumValue("MAIN")]
    MAIN,
}
