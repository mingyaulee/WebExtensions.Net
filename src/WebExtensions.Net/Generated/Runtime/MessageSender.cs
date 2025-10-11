using JsBind.Net;
using System.Text.Json.Serialization;
using WebExtensions.Net.Tabs;

namespace WebExtensions.Net.Runtime;

// Type Class
/// <summary>An object containing information about the script context that sent a message or request.</summary>
[BindAllProperties]
public partial class MessageSender : BaseObject
{
    /// <summary>The $(topic:frame_ids)[frame] that opened the connection. 0 for top-level frames, positive for child frames. This will only be set when <c>tab</c> is set.</summary>
    [JsAccessPath("frameId")]
    [JsonPropertyName("frameId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? FrameId { get; set; }

    /// <summary>The ID of the extension or app that opened the connection, if any.</summary>
    [JsAccessPath("id")]
    [JsonPropertyName("id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Id { get; set; }

    /// <summary>The $(ref:tabs.Tab) which opened the connection, if any. This property will 'strong'only'/strong' be present when the connection was opened from a tab (including content scripts), and 'strong'only'/strong' if the receiver is an extension, not an app.</summary>
    [JsAccessPath("tab")]
    [JsonPropertyName("tab")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Tab Tab { get; set; }

    /// <summary>The URL of the page or frame that opened the connection. If the sender is in an iframe, it will be iframe's URL not the URL of the page which hosts it.</summary>
    [JsAccessPath("url")]
    [JsonPropertyName("url")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Url { get; set; }

    /// <summary>The worldId of the USER_SCRIPT world that sent the message. Only present on onUserScriptMessage and onUserScriptConnect (in port.sender) events.</summary>
    [JsAccessPath("userScriptWorldId")]
    [JsonPropertyName("userScriptWorldId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string UserScriptWorldId { get; set; }
}
