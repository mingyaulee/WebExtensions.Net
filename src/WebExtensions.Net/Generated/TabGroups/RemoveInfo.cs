using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.TabGroups;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class RemoveInfo : BaseObject
{
    /// <summary>True when the tab group is being closed because its window is being closed.</summary>
    [JsAccessPath("isWindowClosing")]
    [JsonPropertyName("isWindowClosing")]
    public bool IsWindowClosing { get; set; }
}
