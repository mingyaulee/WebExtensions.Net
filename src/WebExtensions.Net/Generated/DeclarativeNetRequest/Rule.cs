using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.DeclarativeNetRequest
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class Rule : BaseObject
    {
        /// <summary>The action to take if this rule is matched.</summary>
        [JsonPropertyName("action")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Action Action { get; set; }

        /// <summary>The condition under which this rule is triggered.</summary>
        [JsonPropertyName("condition")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Condition Condition { get; set; }

        /// <summary>An id which uniquely identifies a rule. Mandatory and should be >= 1.</summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>Rule priority. Defaults to 1. When specified, should be >= 1</summary>
        [JsonPropertyName("priority")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Priority { get; set; }
    }
}
