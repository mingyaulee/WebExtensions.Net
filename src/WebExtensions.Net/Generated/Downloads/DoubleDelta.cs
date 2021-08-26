using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Downloads
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class DoubleDelta : BaseObject
    {
        /// <summary></summary>
        [JsonPropertyName("current")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Current { get; set; }

        /// <summary></summary>
        [JsonPropertyName("previous")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Previous { get; set; }
    }
}
