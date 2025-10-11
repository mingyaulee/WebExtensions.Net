using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.BrowserAction;

// Type Class
/// <summary>Information sent when a browser action is clicked.</summary>
[BindAllProperties]
public partial class OnClickData : BaseObject
{
    /// <summary>An integer value of button by which menu item was clicked.</summary>
    [JsAccessPath("button")]
    [JsonPropertyName("button")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Button { get; set; }

    /// <summary>An array of keyboard modifiers that were held while the menu item was clicked.</summary>
    [JsAccessPath("modifiers")]
    [JsonPropertyName("modifiers")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<Modifier> Modifiers { get; set; }
}
