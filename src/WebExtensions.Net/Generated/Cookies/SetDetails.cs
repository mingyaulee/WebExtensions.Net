using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Cookies;

// Type Class
/// <summary>Details about the cookie being set.</summary>
[BindAllProperties]
public partial class SetDetails : BaseObject
{
    /// <summary>The domain of the cookie. If omitted, the cookie becomes a host-only cookie.</summary>
    [JsAccessPath("domain")]
    [JsonPropertyName("domain")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Domain { get; set; }

    /// <summary>The expiration date of the cookie as the number of seconds since the UNIX epoch. If omitted, the cookie becomes a session cookie.</summary>
    [JsAccessPath("expirationDate")]
    [JsonPropertyName("expirationDate")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? ExpirationDate { get; set; }

    /// <summary>The first-party domain of the cookie. This attribute is required if First-Party Isolation is enabled.</summary>
    [JsAccessPath("firstPartyDomain")]
    [JsonPropertyName("firstPartyDomain")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string FirstPartyDomain { get; set; }

    /// <summary>Whether the cookie should be marked as HttpOnly. Defaults to false.</summary>
    [JsAccessPath("httpOnly")]
    [JsonPropertyName("httpOnly")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? HttpOnly { get; set; }

    /// <summary>The name of the cookie. Empty by default if omitted.</summary>
    [JsAccessPath("name")]
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Name { get; set; }

    /// <summary>The storage partition, if the cookie is part of partitioned storage. By default, non-partitioned storage is used.</summary>
    [JsAccessPath("partitionKey")]
    [JsonPropertyName("partitionKey")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PartitionKey PartitionKey { get; set; }

    /// <summary>The path of the cookie. Defaults to the path portion of the url parameter.</summary>
    [JsAccessPath("path")]
    [JsonPropertyName("path")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Path { get; set; }

    /// <summary>The cookie's same-site status.</summary>
    [JsAccessPath("sameSite")]
    [JsonPropertyName("sameSite")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SameSiteStatus? SameSite { get; set; }

    /// <summary>Whether the cookie should be marked as Secure. Defaults to false.</summary>
    [JsAccessPath("secure")]
    [JsonPropertyName("secure")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Secure { get; set; }

    /// <summary>The ID of the cookie store in which to set the cookie. By default, the cookie is set in the current execution context's cookie store.</summary>
    [JsAccessPath("storeId")]
    [JsonPropertyName("storeId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string StoreId { get; set; }

    /// <summary>The request-URI to associate with the setting of the cookie. This value can affect the default domain and path values of the created cookie. If host permissions for this URL are not specified in the manifest file, the API call will fail.</summary>
    [JsAccessPath("url")]
    [JsonPropertyName("url")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Url { get; set; }

    /// <summary>The value of the cookie. Empty by default if omitted.</summary>
    [JsAccessPath("value")]
    [JsonPropertyName("value")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Value { get; set; }
}
