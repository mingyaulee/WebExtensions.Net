using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class ReloadProperties : BaseObject
    {
        /// <summary>Whether using any local cache. Default is false.</summary>
        [JsAccessPath("bypassCache")]
        [JsonPropertyName("bypassCache")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? BypassCache { get; set; }
    }
}
