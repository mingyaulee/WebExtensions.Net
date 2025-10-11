using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebNavigation;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class OnTabReplacedEventCallbackDetails : BaseObject
{
    /// <summary>The ID of the tab that was replaced.</summary>
    [JsAccessPath("replacedTabId")]
    [JsonPropertyName("replacedTabId")]
    public int ReplacedTabId { get; set; }

    /// <summary>The ID of the tab that replaced the old tab.</summary>
    [JsAccessPath("tabId")]
    [JsonPropertyName("tabId")]
    public int TabId { get; set; }

    /// <summary>The time when the replacement happened, in milliseconds since the epoch.</summary>
    [JsAccessPath("timeStamp")]
    [JsonPropertyName("timeStamp")]
    public EpochTime TimeStamp { get; set; }
}
