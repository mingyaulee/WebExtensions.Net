using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebNavigation;

// Type Class
/// <summary>Information about the tab to retrieve all frames from.</summary>
[BindAllProperties]
public partial class GetAllFramesDetails : BaseObject
{
    /// <summary>The ID of the tab.</summary>
    [JsAccessPath("tabId")]
    [JsonPropertyName("tabId")]
    public int TabId { get; set; }
}
