using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Types
{
    // Type Class
    /// <summary>Which setting to change.</summary>
    [BindAllProperties]
    public partial class SetDetails : BaseObject
    {
        /// <summary>Where to set the setting (default: regular).</summary>
        [JsonPropertyName("scope")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public SettingScope? Scope { get; set; }

        /// <summary>The value of the setting. <br/>Note that every setting has a specific value type, which is described together with the setting. An extension should <em>not</em> set a value of a different type.</summary>
        [JsonPropertyName("value")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object Value { get; set; }
    }
}
