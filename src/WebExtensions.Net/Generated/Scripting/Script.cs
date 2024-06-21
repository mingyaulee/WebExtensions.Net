using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Scripting
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class Script : BaseObject
    {
        /// <summary>Specifies if this content script will persist into future sessions.</summary>
        [JsAccessPath("persistAcrossSessions")]
        [JsonPropertyName("persistAcrossSessions")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? PersistAcrossSessions { get; set; }
    }
}
