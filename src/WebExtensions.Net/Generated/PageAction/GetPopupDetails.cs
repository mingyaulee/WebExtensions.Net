using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.PageAction
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class GetPopupDetails : BaseObject
    {
        /// <summary>Specify the tab to get the popup from.</summary>
        [JsonPropertyName("tabId")]
        public int TabId { get; set; }
    }
}
