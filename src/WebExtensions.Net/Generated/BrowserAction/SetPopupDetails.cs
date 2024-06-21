using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.BrowserAction
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class SetPopupDetails : BaseObject
    {
        /// <summary>The html file to show in a popup.  If set to the empty string (''), no popup is shown.</summary>
        [JsAccessPath("popup")]
        [JsonPropertyName("popup")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Popup Popup { get; set; }
    }
}
