using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.UserScripts
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class Script : BaseObject
    {
        /// <summary></summary>
        [JsAccessPath("js")]
        [JsonPropertyName("js")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<ScriptSource> Js { get; set; }
    }
}
