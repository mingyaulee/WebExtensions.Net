using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Cookies;

// Type Class
/// <summary>Information to filter the cookies being retrieved.</summary>
[BindAllProperties]
public partial class GetAllDetails : BaseObject
{
    /// <summary>Restricts the retrieved cookies to those whose domains match or are subdomains of this one.</summary>
    [JsAccessPath("domain")]
    [JsonPropertyName("domain")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Domain { get; set; }

    /// <summary>Restricts the retrieved cookies to those whose first-party domains match this one. This attribute is required if First-Party Isolation is enabled. To not filter by a specific first-party domain, use `null` or `undefined`.</summary>
    [JsAccessPath("firstPartyDomain")]
    [JsonPropertyName("firstPartyDomain")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string FirstPartyDomain { get; set; }

    /// <summary>Filters the cookies by name.</summary>
    [JsAccessPath("name")]
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Name { get; set; }

    /// <summary>Selects a specific storage partition to look up cookies. Defaults to null, in which case only non-partitioned cookies are retrieved. If an object iis passed, partitioned cookies are also included, and filtered based on the keys present in the given PartitionKey description. An empty object ({}) returns all cookies (partitioned + unpartitioned), a non-empty object (e.g. {topLevelSite: '...'}) only returns cookies whose partition match all given attributes.</summary>
    [JsAccessPath("partitionKey")]
    [JsonPropertyName("partitionKey")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PartitionKey PartitionKey { get; set; }

    /// <summary>Restricts the retrieved cookies to those whose path exactly matches this string.</summary>
    [JsAccessPath("path")]
    [JsonPropertyName("path")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Path { get; set; }

    /// <summary>Filters the cookies by their Secure property.</summary>
    [JsAccessPath("secure")]
    [JsonPropertyName("secure")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Secure { get; set; }

    /// <summary>Filters out session vs. persistent cookies.</summary>
    [JsAccessPath("session")]
    [JsonPropertyName("session")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Session { get; set; }

    /// <summary>The cookie store to retrieve cookies from. If omitted, the current execution context's cookie store will be used.</summary>
    [JsAccessPath("storeId")]
    [JsonPropertyName("storeId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string StoreId { get; set; }

    /// <summary>Restricts the retrieved cookies to those that would match the given URL.</summary>
    [JsAccessPath("url")]
    [JsonPropertyName("url")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Url { get; set; }
}
