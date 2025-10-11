using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Runtime;

// Type Class
/// <summary>A context hosting extension content</summary>
[BindAllProperties]
public partial class ExtensionContext : BaseObject
{
    /// <summary>An unique identifier associated to this context</summary>
    [JsAccessPath("contextId")]
    [JsonPropertyName("contextId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ContextId { get; set; }

    /// <summary>The type of the context</summary>
    [JsAccessPath("contextType")]
    [JsonPropertyName("contextType")]
    public ContextType ContextType { get; set; }

    /// <summary>The origin of the document associated with this context, or undefined if it is not hosted in a document</summary>
    [JsAccessPath("documentOrigin")]
    [JsonPropertyName("documentOrigin")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string DocumentOrigin { get; set; }

    /// <summary>The URL of the document associated with this context, or undefined if it is not hosted in a document</summary>
    [JsAccessPath("documentUrl")]
    [JsonPropertyName("documentUrl")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string DocumentUrl { get; set; }

    /// <summary>The frame ID for this context, or -1 if it is not hosted in a frame.</summary>
    [JsAccessPath("frameId")]
    [JsonPropertyName("frameId")]
    public int FrameId { get; set; }

    /// <summary>Whether the context is associated with an private browsing context.</summary>
    [JsAccessPath("incognito")]
    [JsonPropertyName("incognito")]
    public bool Incognito { get; set; }

    /// <summary>The tab ID for this context, or -1 if it is not hosted in a tab.</summary>
    [JsAccessPath("tabId")]
    [JsonPropertyName("tabId")]
    public int TabId { get; set; }

    /// <summary>The window ID for this context, or -1 if it is not hosted in a window.</summary>
    [JsAccessPath("windowId")]
    [JsonPropertyName("windowId")]
    public int WindowId { get; set; }
}
