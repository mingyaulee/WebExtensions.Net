using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Scripting
{
    // Type Class
    /// <summary>Result of a script injection.</summary>
    [BindAllProperties]
    public partial class InjectionResult : BaseObject
    {
        /// <summary>The error property is set when the script execution failed. The value is typically an (Error) object with a message property, but could be any value (including primitives and undefined) if the script threw or rejected with such a value.</summary>
        [JsAccessPath("error")]
        [JsonPropertyName("error")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object Error { get; set; }

        /// <summary>The frame ID associated with the injection.</summary>
        [JsAccessPath("frameId")]
        [JsonPropertyName("frameId")]
        public int FrameId { get; set; }

        /// <summary>The result of the script execution.</summary>
        [JsAccessPath("result")]
        [JsonPropertyName("result")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object Result { get; set; }
    }
}
