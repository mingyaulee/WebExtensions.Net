using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.History
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class HasListenerCallbackRemoved : BaseObject
    {
        /// <summary>True if all history was removed.  If true, then urls will be empty.</summary>
        [JsonPropertyName("allHistory")]
        public bool AllHistory { get; set; }

        /// <summary></summary>
        [JsonPropertyName("urls")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> Urls { get; set; }
    }
}
