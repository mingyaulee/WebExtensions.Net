using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.DeclarativeNetRequest
{
    // Type Class
    /// <summary>The request headers to modify for the request. Only valid when type is 'modifyHeaders'.</summary>
    [BindAllProperties]
    public partial class RequestHeaders : BaseObject
    {
        /// <summary>The name of the request header to be modified.</summary>
        [JsonPropertyName("header")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Header { get; set; }

        /// <summary>The operation to be performed on a header. The 'append' operation is not supported for request headers.</summary>
        [JsonPropertyName("operation")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Operation { get; set; }

        /// <summary>The new value for the header. Must be specified for the 'set' operation.</summary>
        [JsonPropertyName("value")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Value { get; set; }
    }
}
