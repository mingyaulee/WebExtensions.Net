using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.UserScripts
{
    // Type Class
    /// <summary>Optional filter to use with getScripts() and unregister().</summary>
    [BindAllProperties]
    public partial class UserScriptFilter : BaseObject
    {
        /// <summary></summary>
        [JsAccessPath("ids")]
        [JsonPropertyName("ids")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> Ids { get; set; }
    }
}
