﻿using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebNavigation;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class OnBeforeNavigateEventCallbackDetails : BaseObject
{
    /// <summary>0 indicates the navigation happens in the tab content window; a positive value indicates navigation in a subframe. Frame IDs are unique for a given tab and process.</summary>
    [JsAccessPath("frameId")]
    [JsonPropertyName("frameId")]
    public int FrameId { get; set; }

    /// <summary>ID of frame that wraps the frame. Set to -1 of no parent frame exists.</summary>
    [JsAccessPath("parentFrameId")]
    [JsonPropertyName("parentFrameId")]
    public int ParentFrameId { get; set; }

    /// <summary>The ID of the tab in which the navigation is about to occur.</summary>
    [JsAccessPath("tabId")]
    [JsonPropertyName("tabId")]
    public int TabId { get; set; }

    /// <summary>The time when the browser was about to start the navigation, in milliseconds since the epoch.</summary>
    [JsAccessPath("timeStamp")]
    [JsonPropertyName("timeStamp")]
    public EpochTime TimeStamp { get; set; }

    /// <summary></summary>
    [JsAccessPath("url")]
    [JsonPropertyName("url")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Url { get; set; }
}
