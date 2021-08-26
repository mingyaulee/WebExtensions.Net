using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebRequest
{
    // Type Class
    /// <summary>Only used as a response to the onAuthRequired event. If set, the request is made using the supplied credentials.</summary>
    [BindAllProperties]
    public partial class AuthCredentials : BaseObject
    {
        /// <summary></summary>
        [JsonPropertyName("password")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Password { get; set; }

        /// <summary></summary>
        [JsonPropertyName("username")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Username { get; set; }
    }
}
