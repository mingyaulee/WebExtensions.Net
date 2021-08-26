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
        [JsonPropertyName("origins")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<MatchPattern> Origins { get; set; }

        /// <summary></summary>
        [JsonPropertyName("permissions")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<Permission> Permissions { get; set; }
    }
}
