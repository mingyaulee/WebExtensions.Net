using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Runtime
{
    // Type Class
    /// <summary>This will be defined during an API method callback if there was an error</summary>
    [BindAllProperties]
    public partial class LastError : BaseObject
    {
        /// <summary>Details about the error which occurred.</summary>
        [JsAccessPath("message")]
        [JsonPropertyName("message")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Message { get; set; }
    }
}
