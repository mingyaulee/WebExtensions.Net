using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Types
{
    // Type Class
    /// <summary>Which setting to consider.</summary>
    [BindAllProperties]
    public partial class GetDetails : BaseObject
    {
        /// <summary>Whether to return the value that applies to the incognito session (default false).</summary>
        [JsAccessPath("incognito")]
        [JsonPropertyName("incognito")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Incognito { get; set; }
    }
}
