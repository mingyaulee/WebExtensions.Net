using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.ActivityLog
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class Data : BaseObject
    {
        /// <summary>A list of arguments passed to the call.</summary>
        [JsAccessPath("args")]
        [JsonPropertyName("args")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<object> Args { get; set; }

        /// <summary>The result of the call.</summary>
        [JsAccessPath("result")]
        [JsonPropertyName("result")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object Result { get; set; }

        /// <summary>The tab associated with this event if it is a tab or content script.</summary>
        [JsAccessPath("tabId")]
        [JsonPropertyName("tabId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TabId { get; set; }

        /// <summary>If the type is content_script, this is the url of the script that was injected.</summary>
        [JsAccessPath("url")]
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Url { get; set; }
    }
}
