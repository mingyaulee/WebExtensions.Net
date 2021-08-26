using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Cookies
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class AddListenerCallbackChangeInfo : BaseObject
    {
        /// <summary>The underlying reason behind the cookie's change.</summary>
        [JsonPropertyName("cause")]
        public OnChangedCause Cause { get; set; }

        /// <summary>Information about the cookie that was set or removed.</summary>
        [JsonPropertyName("cookie")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Cookie Cookie { get; set; }

        /// <summary>True if a cookie was removed.</summary>
        [JsonPropertyName("removed")]
        public bool Removed { get; set; }
    }
}
