using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebExtensions.Net.Manifest;

namespace WebExtensions.Net.Permissions
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class AnyPermissions : BaseObject
    {
        /// <summary></summary>
        [JsAccessPath("data_collection")]
        [JsonPropertyName("data_collection")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<OptionalDataCollectionPermission> Data_collection { get; set; }

        /// <summary></summary>
        [JsAccessPath("origins")]
        [JsonPropertyName("origins")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<MatchPattern> Origins { get; set; }

        /// <summary></summary>
        [JsAccessPath("permissions")]
        [JsonPropertyName("permissions")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<PermissionOrOptionalOnlyPermission> Permissions { get; set; }
    }
}
