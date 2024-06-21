using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.DeclarativeNetRequest
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class AddOrReplaceParam : BaseObject
    {
        /// <summary></summary>
        [JsAccessPath("key")]
        [JsonPropertyName("key")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Key { get; set; }

        /// <summary>If true, the query key is replaced only if it's already present. Otherwise, the key is also added if it's missing.</summary>
        [JsAccessPath("replaceOnly")]
        [JsonPropertyName("replaceOnly")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ReplaceOnly { get; set; }

        /// <summary></summary>
        [JsAccessPath("value")]
        [JsonPropertyName("value")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Value { get; set; }
    }
}
