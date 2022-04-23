using System.Text.Json.Serialization;

namespace WebExtensions.Net.Scripting
{
    /// <summary>The JavaScript world for a script to execute within. We currently only support the <c>'ISOLATED'</c> world.</summary>
    [JsonConverter(typeof(EnumStringConverter<ExecutionWorld>))]
    public enum ExecutionWorld
    {
        /// <summary>ISOLATED</summary>
        [EnumValue("ISOLATED")]
        ISOLATED,
    }
}
