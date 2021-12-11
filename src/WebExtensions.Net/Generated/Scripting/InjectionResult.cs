using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Scripting
{
    // Type Class
    /// <summary>Result of a script injection.</summary>
    [BindAllProperties]
    public partial class InjectionResult : BaseObject
    {
        /// <summary>The frame ID associated with the injection.</summary>
        [JsonPropertyName("frameId")]
        public double FrameId { get; set; }

        /// <summary>The result of the script execution.</summary>
        [JsonPropertyName("result")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object Result { get; set; }
    }
}
