using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.PageAction;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class SetTitleDetails : BaseObject
{
    /// <summary>The id of the tab for which you want to modify the page action.</summary>
    [JsAccessPath("tabId")]
    [JsonPropertyName("tabId")]
    public int TabId { get; set; }

    /// <summary>The tooltip string.</summary>
    [JsAccessPath("title")]
    [JsonPropertyName("title")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Title Title { get; set; }
}
