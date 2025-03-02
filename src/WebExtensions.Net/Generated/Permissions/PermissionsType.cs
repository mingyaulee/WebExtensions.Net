using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebExtensions.Net.Manifest;

namespace WebExtensions.Net.Permissions
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class PermissionsType : BaseObject
    {
        /// <summary></summary>
        [JsAccessPath("origins")]
        [JsonPropertyName("origins")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<MatchPattern> Origins { get; set; }

        /// <summary></summary>
        [JsAccessPath("permissions")]
        [JsonPropertyName("permissions")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<OptionalPermissionOrOptionalOnlyPermission> Permissions { get; set; }
    }
}
