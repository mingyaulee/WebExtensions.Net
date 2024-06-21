using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Cookies
{
    // Type Class
    /// <summary>The description of the storage partition of a cookie. This object may be omitted (null) if a cookie is not partitioned.</summary>
    [BindAllProperties]
    public partial class PartitionKey : BaseObject
    {
        /// <summary>The first-party URL of the cookie, if the cookie is in storage partitioned by the top-level site.</summary>
        [JsAccessPath("topLevelSite")]
        [JsonPropertyName("topLevelSite")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string TopLevelSite { get; set; }
    }
}
