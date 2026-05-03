using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.ActionNs;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class Change : BaseObject
{
    /// <summary>Whether the extension's action icon is visible on browser windows' top-level toolbar (i.e., whether the extension has been 'pinned' by the user).</summary>
    [JsAccessPath("isOnToolbar")]
    [JsonPropertyName("isOnToolbar")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IsOnToolbar { get; set; }
}
