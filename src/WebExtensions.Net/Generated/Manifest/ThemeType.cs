using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class ThemeType : BaseObject
    {
        /// <summary></summary>
        [JsAccessPath("colors")]
        [JsonPropertyName("colors")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Colors Colors { get; set; }

        /// <summary></summary>
        [JsAccessPath("images")]
        [JsonPropertyName("images")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Images Images { get; set; }

        /// <summary></summary>
        [JsAccessPath("properties")]
        [JsonPropertyName("properties")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Properties Properties { get; set; }
    }
}
