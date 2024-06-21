using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Commands
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class Command : BaseObject
    {
        /// <summary>The Extension Command description</summary>
        [JsAccessPath("description")]
        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Description { get; set; }

        /// <summary>The name of the Extension Command</summary>
        [JsAccessPath("name")]
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Name { get; set; }

        /// <summary>The shortcut active for this command, or blank if not active.</summary>
        [JsAccessPath("shortcut")]
        [JsonPropertyName("shortcut")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Shortcut { get; set; }
    }
}
