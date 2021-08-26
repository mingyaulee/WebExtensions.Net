using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Types
{
    // Type Class
    /// <summary>Which setting to clear.</summary>
    [BindAllProperties]
    public partial class ClearDetails : BaseObject
    {
        /// <summary>Where to clear the setting (default: regular).</summary>
        [JsonPropertyName("scope")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public SettingScope? Scope { get; set; }
    }
}
