using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.DeclarativeNetRequest
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class UpdateRulesetOptions : BaseObject
    {
        /// <summary></summary>
        [JsAccessPath("disableRulesetIds")]
        [JsonPropertyName("disableRulesetIds")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> DisableRulesetIds { get; set; }

        /// <summary></summary>
        [JsAccessPath("enableRulesetIds")]
        [JsonPropertyName("enableRulesetIds")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> EnableRulesetIds { get; set; }
    }
}
