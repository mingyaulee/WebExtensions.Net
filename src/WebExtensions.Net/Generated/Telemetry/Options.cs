using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Telemetry
{
    // Type Class
    /// <summary>Options object.</summary>
    [BindAllProperties]
    public partial class Options : BaseObject
    {
        /// <summary>True if the ping should contain the client id.</summary>
        [JsAccessPath("addClientId")]
        [JsonPropertyName("addClientId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AddClientId { get; set; }

        /// <summary>True if the ping should contain the environment data.</summary>
        [JsAccessPath("addEnvironment")]
        [JsonPropertyName("addEnvironment")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AddEnvironment { get; set; }

        /// <summary>Set to override the environment data.</summary>
        [JsAccessPath("overrideEnvironment")]
        [JsonPropertyName("overrideEnvironment")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object OverrideEnvironment { get; set; }

        /// <summary>If true, send the ping using the PingSender.</summary>
        [JsAccessPath("usePingSender")]
        [JsonPropertyName("usePingSender")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? UsePingSender { get; set; }
    }
}
