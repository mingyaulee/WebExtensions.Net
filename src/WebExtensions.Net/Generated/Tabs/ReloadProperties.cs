using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    public partial class ReloadProperties : BaseObject
    {
        private bool? _bypassCache;

        /// <summary>Whether using any local cache. Default is false.</summary>
        [JsonPropertyName("bypassCache")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? BypassCache
        {
            get
            {
                InitializeProperty("bypassCache", _bypassCache);
                return _bypassCache;
            }
            set
            {
                _bypassCache = value;
            }
        }
    }
}
