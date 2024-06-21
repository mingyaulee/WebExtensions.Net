using JsBind.Net;
using System.Text.Json.Serialization;
using WebExtensions.Net.ExtensionTypes;

namespace WebExtensions.Net.History
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class Range : BaseObject
    {
        /// <summary>Items added to history before this date.</summary>
        [JsAccessPath("endTime")]
        [JsonPropertyName("endTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Date EndTime { get; set; }

        /// <summary>Items added to history after this date.</summary>
        [JsAccessPath("startTime")]
        [JsonPropertyName("startTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Date StartTime { get; set; }
    }
}
