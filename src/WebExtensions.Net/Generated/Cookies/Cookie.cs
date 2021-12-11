using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Cookies
{
    // Type Class
    /// <summary>Represents information about an HTTP cookie.</summary>
    [BindAllProperties]
    public partial class Cookie : BaseObject
    {
        /// <summary>The domain of the cookie (e.g. "www.google.com", "example.com").</summary>
        [JsonPropertyName("domain")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Domain { get; set; }

        /// <summary>The expiration date of the cookie as the number of seconds since the UNIX epoch. Not provided for session cookies.</summary>
        [JsonPropertyName("expirationDate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? ExpirationDate { get; set; }

        /// <summary>The first-party domain of the cookie.</summary>
        [JsonPropertyName("firstPartyDomain")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string FirstPartyDomain { get; set; }

        /// <summary>True if the cookie is a host-only cookie (i.e. a request's host must exactly match the domain of the cookie).</summary>
        [JsonPropertyName("hostOnly")]
        public bool HostOnly { get; set; }

        /// <summary>True if the cookie is marked as HttpOnly (i.e. the cookie is inaccessible to client-side scripts).</summary>
        [JsonPropertyName("httpOnly")]
        public bool HttpOnly { get; set; }

        /// <summary>The name of the cookie.</summary>
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Name { get; set; }

        /// <summary>The cookie's storage partition, if any. null if not partitioned.</summary>
        [JsonPropertyName("partitionKey")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public PartitionKey PartitionKey { get; set; }

        /// <summary>The path of the cookie.</summary>
        [JsonPropertyName("path")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Path { get; set; }

        /// <summary>The cookie's same-site status (i.e. whether the cookie is sent with cross-site requests).</summary>
        [JsonPropertyName("sameSite")]
        public SameSiteStatus SameSite { get; set; }

        /// <summary>True if the cookie is marked as Secure (i.e. its scope is limited to secure channels, typically HTTPS).</summary>
        [JsonPropertyName("secure")]
        public bool Secure { get; set; }

        /// <summary>True if the cookie is a session cookie, as opposed to a persistent cookie with an expiration date.</summary>
        [JsonPropertyName("session")]
        public bool Session { get; set; }

        /// <summary>The ID of the cookie store containing this cookie, as provided in getAllCookieStores().</summary>
        [JsonPropertyName("storeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string StoreId { get; set; }

        /// <summary>The value of the cookie.</summary>
        [JsonPropertyName("value")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Value { get; set; }
    }
}
