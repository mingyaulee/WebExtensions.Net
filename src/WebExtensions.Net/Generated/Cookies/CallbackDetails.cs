using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Cookies
{
    // Type Class
    /// <summary>Contains details about the cookie that's been removed.  If removal failed for any reason, this will be "null", and $(ref:runtime.lastError) will be set.</summary>
    [BindAllProperties]
    public partial class CallbackDetails : BaseObject
    {
        /// <summary>The first-party domain associated with the cookie that's been removed.</summary>
        [JsonPropertyName("firstPartyDomain")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string FirstPartyDomain { get; set; }

        /// <summary>The name of the cookie that's been removed.</summary>
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Name { get; set; }

        /// <summary>The storage partition, if the cookie is part of partitioned storage. null if not partitioned.</summary>
        [JsonPropertyName("partitionKey")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public PartitionKey PartitionKey { get; set; }

        /// <summary>The ID of the cookie store from which the cookie was removed.</summary>
        [JsonPropertyName("storeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string StoreId { get; set; }

        /// <summary>The URL associated with the cookie that's been removed.</summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Url { get; set; }
    }
}
