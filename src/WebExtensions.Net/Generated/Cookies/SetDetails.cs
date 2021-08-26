using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Cookies
{
    // Type Class
    /// <summary>Details about the cookie being set.</summary>
    [BindAllProperties]
    public partial class SetDetails : BaseObject
    {
        /// <summary>The domain of the cookie. If omitted, the cookie becomes a host-only cookie.</summary>
        [JsonPropertyName("domain")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Domain { get; set; }

        /// <summary>The expiration date of the cookie as the number of seconds since the UNIX epoch. If omitted, the cookie becomes a session cookie.</summary>
        [JsonPropertyName("expirationDate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? ExpirationDate { get; set; }

        /// <summary>The first-party domain of the cookie. This attribute is required if First-Party Isolation is enabled.</summary>
        [JsonPropertyName("firstPartyDomain")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string FirstPartyDomain { get; set; }

        /// <summary>Whether the cookie should be marked as HttpOnly. Defaults to false.</summary>
        [JsonPropertyName("httpOnly")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? HttpOnly { get; set; }

        /// <summary>The name of the cookie. Empty by default if omitted.</summary>
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Name { get; set; }

        /// <summary>The path of the cookie. Defaults to the path portion of the url parameter.</summary>
        [JsonPropertyName("path")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Path { get; set; }

        /// <summary>The cookie's same-site status.</summary>
        [JsonPropertyName("sameSite")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public SameSiteStatus? SameSite { get; set; }

        /// <summary>Whether the cookie should be marked as Secure. Defaults to false.</summary>
        [JsonPropertyName("secure")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Secure { get; set; }

        /// <summary>The ID of the cookie store in which to set the cookie. By default, the cookie is set in the current execution context's cookie store.</summary>
        [JsonPropertyName("storeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string StoreId { get; set; }

        /// <summary>The request-URI to associate with the setting of the cookie. This value can affect the default domain and path values of the created cookie. If host permissions for this URL are not specified in the manifest file, the API call will fail.</summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Url { get; set; }

        /// <summary>The value of the cookie. Empty by default if omitted.</summary>
        [JsonPropertyName("value")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Value { get; set; }
    }
}
