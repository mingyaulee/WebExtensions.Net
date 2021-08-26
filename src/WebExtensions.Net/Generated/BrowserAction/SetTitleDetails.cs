using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.BrowserAction
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class SetTitleDetails : BaseObject
    {
        /// <summary>The string the browser action should display when moused over.</summary>
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Title Title { get; set; }
    }
}
