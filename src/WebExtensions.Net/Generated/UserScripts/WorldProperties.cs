using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.UserScripts
{
    // Type Class
    /// <summary>The configuration of a USER_SCRIPT world.</summary>
    [BindAllProperties]
    public partial class WorldProperties : BaseObject
    {
        /// <summary>The world's Content Security Policy. Defaults to the CSP of regular content scripts, which prohibits dynamic code execution such as eval.</summary>
        [JsAccessPath("csp")]
        [JsonPropertyName("csp")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Csp { get; set; }

        /// <summary>Whether the runtime.sendMessage and runtime.connect methods are exposed. Defaults to not exposing these messaging APIs.</summary>
        [JsAccessPath("messaging")]
        [JsonPropertyName("messaging")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Messaging { get; set; }

        /// <summary>The identifier of the world. Values with leading underscores (`_`) are reserved. The maximum length is 256. Defaults to the default USER_SCRIPT world ("").</summary>
        [JsAccessPath("worldId")]
        [JsonPropertyName("worldId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string WorldId { get; set; }
    }
}
