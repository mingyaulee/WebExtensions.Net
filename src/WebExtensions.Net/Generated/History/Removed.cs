using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.History
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class Removed : BaseObject
    {
        /// <summary>True if all history was removed.  If true, then urls will be empty.</summary>
        [JsAccessPath("allHistory")]
        [JsonPropertyName("allHistory")]
        public bool AllHistory { get; set; }

        /// <summary></summary>
        [JsAccessPath("urls")]
        [JsonPropertyName("urls")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> Urls { get; set; }
    }
}
