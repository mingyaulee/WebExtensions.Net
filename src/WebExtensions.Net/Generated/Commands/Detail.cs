using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Commands
{
    // Type Class
    /// <summary>The new description for the command.</summary>
    [BindAllProperties]
    public partial class Detail : BaseObject
    {
        /// <summary>The new description for the command.</summary>
        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Description { get; set; }

        /// <summary>The name of the command.</summary>
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Name { get; set; }

        /// <summary></summary>
        [JsonPropertyName("shortcut")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Shortcut { get; set; }
    }
}
