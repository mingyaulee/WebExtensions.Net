using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebExtensions.Net.Manifest;

namespace WebExtensions.Net.Permissions
{
    // Type Class
    /// <summary></summary>
    public partial class AnyPermissions : BaseObject
    {
        private IEnumerable<MatchPattern> _origins;
        private IEnumerable<Permission> _permissions;

        /// <summary></summary>
        [JsonPropertyName("origins")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<MatchPattern> Origins
        {
            get
            {
                InitializeProperty("origins", _origins);
                return _origins;
            }
            set
            {
                _origins = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("permissions")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<Permission> Permissions
        {
            get
            {
                InitializeProperty("permissions", _permissions);
                return _permissions;
            }
            set
            {
                _permissions = value;
            }
        }
    }
}
