using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Cookies
{
    // Type Class
    /// <summary>Details to identify the cookie being retrieved.</summary>
    [BindAllProperties]
    public partial class GetDetails : BaseObject
    {
        /// <summary>The first-party domain which the cookie to retrieve is associated. This attribute is required if First-Party Isolation is enabled.</summary>
        [JsAccessPath("firstPartyDomain")]
        [JsonPropertyName("firstPartyDomain")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string FirstPartyDomain { get; set; }

        /// <summary>The name of the cookie to retrieve.</summary>
        [JsAccessPath("name")]
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Name { get; set; }

        /// <summary>The storage partition, if the cookie is part of partitioned storage. By default, only non-partitioned cookies are returned.</summary>
        [JsAccessPath("partitionKey")]
        [JsonPropertyName("partitionKey")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public PartitionKey PartitionKey { get; set; }

        /// <summary>The ID of the cookie store in which to look for the cookie. By default, the current execution context's cookie store will be used.</summary>
        [JsAccessPath("storeId")]
        [JsonPropertyName("storeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string StoreId { get; set; }

        /// <summary>The URL with which the cookie to retrieve is associated. This argument may be a full URL, in which case any data following the URL path (e.g. the query string) is simply ignored. If host permissions for this URL are not specified in the manifest file, the API call will fail.</summary>
        [JsAccessPath("url")]
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Url { get; set; }
    }
}
