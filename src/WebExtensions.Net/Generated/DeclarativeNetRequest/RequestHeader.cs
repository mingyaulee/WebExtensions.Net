using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.DeclarativeNetRequest
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class RequestHeader : BaseObject
    {
        /// <summary>The name of the request header to be modified.</summary>
        [JsAccessPath("header")]
        [JsonPropertyName("header")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Header { get; set; }

        /// <summary>The operation to be performed on a header.</summary>
        [JsAccessPath("operation")]
        [JsonPropertyName("operation")]
        public RequestHeaderOperation Operation { get; set; }

        /// <summary>The new value for the header. Must be specified for the 'append' and 'set' operations.</summary>
        [JsAccessPath("value")]
        [JsonPropertyName("value")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Value { get; set; }
    }
}
