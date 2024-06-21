using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.ActionNs
{
    // Type Class
    /// <summary>An object with information about the popup to open.</summary>
    [BindAllProperties]
    public partial class Options : BaseObject
    {
        /// <summary>Defaults to the $(topic:current-window)[current window].</summary>
        [JsAccessPath("windowId")]
        [JsonPropertyName("windowId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? WindowId { get; set; }
    }
}
