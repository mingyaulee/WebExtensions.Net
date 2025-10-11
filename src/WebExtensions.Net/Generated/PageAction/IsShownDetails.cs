using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.PageAction;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class IsShownDetails : BaseObject
{
    /// <summary>Specify the tab to get the shownness from.</summary>
    [JsAccessPath("tabId")]
    [JsonPropertyName("tabId")]
    public int TabId { get; set; }
}
