using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.DeclarativeNetRequest
{
    // Type Class
    /// <summary>The action to take if this rule is matched.</summary>
    [BindAllProperties]
    public partial class Action : BaseObject
    {
        /// <summary>Describes how the redirect should be performed. Only valid when type is 'redirect'.</summary>
        [JsonPropertyName("redirect")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Redirect Redirect { get; set; }

        /// <summary>The request headers to modify for the request. Only valid when type is 'modifyHeaders'.</summary>
        [JsonPropertyName("requestHeaders")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public RequestHeaders RequestHeaders { get; set; }

        /// <summary>The response headers to modify for the request. Only valid when type is 'modifyHeaders'.</summary>
        [JsonPropertyName("responseHeaders")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ResponseHeaders ResponseHeaders { get; set; }

        /// <summary></summary>
        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Type { get; set; }
    }
}
