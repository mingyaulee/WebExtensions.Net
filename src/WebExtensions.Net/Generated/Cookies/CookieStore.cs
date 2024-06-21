using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Cookies
{
    // Type Class
    /// <summary>Represents a cookie store in the browser. An incognito mode window, for instance, uses a separate cookie store from a non-incognito window.</summary>
    [BindAllProperties]
    public partial class CookieStore : BaseObject
    {
        /// <summary>The unique identifier for the cookie store.</summary>
        [JsAccessPath("id")]
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Id { get; set; }

        /// <summary>Indicates if this is an incognito cookie store</summary>
        [JsAccessPath("incognito")]
        [JsonPropertyName("incognito")]
        public bool Incognito { get; set; }

        /// <summary>Identifiers of all the browser tabs that share this cookie store.</summary>
        [JsAccessPath("tabIds")]
        [JsonPropertyName("tabIds")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<int> TabIds { get; set; }
    }
}
