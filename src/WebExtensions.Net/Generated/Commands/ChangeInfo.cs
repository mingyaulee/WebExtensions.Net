using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Commands
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class ChangeInfo : BaseObject
    {
        /// <summary>The name of the shortcut.</summary>
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Name { get; set; }

        /// <summary>The new shortcut active for this command, or blank if not active.</summary>
        [JsonPropertyName("newShortcut")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string NewShortcut { get; set; }

        /// <summary>The old shortcut which is no longer active for this command, or blank if the shortcut was previously inactive.</summary>
        [JsonPropertyName("oldShortcut")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string OldShortcut { get; set; }
    }
}
