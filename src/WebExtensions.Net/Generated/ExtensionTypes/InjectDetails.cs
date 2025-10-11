using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.ExtensionTypes;

// Type Class
/// <summary>Details of the script or CSS to inject. Either the code or the file property must be set, but both may not be set at the same time.</summary>
[BindAllProperties]
public partial class InjectDetails : BaseObject
{
    /// <summary>If allFrames is <c>true</c>, implies that the JavaScript or CSS should be injected into all frames of current page. By default, it's <c>false</c> and is only injected into the top frame.</summary>
    [JsAccessPath("allFrames")]
    [JsonPropertyName("allFrames")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? AllFrames { get; set; }

    /// <summary>JavaScript or CSS code to inject.<br /><br />'b'Warning:'/b'<br />Be careful using the <c>code</c> parameter. Incorrect use of it may open your extension to <see href="https://en.wikipedia.org/wiki/Cross-site_scripting">cross site scripting</see> attacks.</summary>
    [JsAccessPath("code")]
    [JsonPropertyName("code")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Code { get; set; }

    /// <summary>The css origin of the stylesheet to inject. Defaults to "author".</summary>
    [JsAccessPath("cssOrigin")]
    [JsonPropertyName("cssOrigin")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public CSSOrigin? CssOrigin { get; set; }

    /// <summary>JavaScript or CSS file to inject.</summary>
    [JsAccessPath("file")]
    [JsonPropertyName("file")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string File { get; set; }

    /// <summary>The ID of the frame to inject the script into. This may not be used in combination with <c>allFrames</c>.</summary>
    [JsAccessPath("frameId")]
    [JsonPropertyName("frameId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? FrameId { get; set; }

    /// <summary>If matchAboutBlank is true, then the code is also injected in about:blank and about:srcdoc frames if your extension has access to its parent document. Code cannot be inserted in top-level about:-frames. By default it is <c>false</c>.</summary>
    [JsAccessPath("matchAboutBlank")]
    [JsonPropertyName("matchAboutBlank")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? MatchAboutBlank { get; set; }

    /// <summary>The soonest that the JavaScript or CSS will be injected into the tab. Defaults to "document_idle".</summary>
    [JsAccessPath("runAt")]
    [JsonPropertyName("runAt")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public RunAt? RunAt { get; set; }
}
