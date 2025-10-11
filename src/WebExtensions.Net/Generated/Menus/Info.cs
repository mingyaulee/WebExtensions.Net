﻿using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebExtensions.Net.Extension;

namespace WebExtensions.Net.Menus;

// Type Class
/// <summary>Information about the context of the menu action and the created menu items. For more information about each property, see OnClickData. The following properties are only set if the extension has host permissions for the given context: linkUrl, linkText, srcUrl, pageUrl, frameUrl, selectionText.</summary>
[BindAllProperties]
public partial class Info : BaseObject
{
    /// <summary>A list of all contexts that apply to the menu.</summary>
    [JsAccessPath("contexts")]
    [JsonPropertyName("contexts")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<ContextType> Contexts { get; set; }

    /// <summary></summary>
    [JsAccessPath("editable")]
    [JsonPropertyName("editable")]
    public bool Editable { get; set; }

    /// <summary></summary>
    [JsAccessPath("frameUrl")]
    [JsonPropertyName("frameUrl")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string FrameUrl { get; set; }

    /// <summary></summary>
    [JsAccessPath("linkText")]
    [JsonPropertyName("linkText")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string LinkText { get; set; }

    /// <summary></summary>
    [JsAccessPath("linkUrl")]
    [JsonPropertyName("linkUrl")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string LinkUrl { get; set; }

    /// <summary></summary>
    [JsAccessPath("mediaType")]
    [JsonPropertyName("mediaType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string MediaType { get; set; }

    /// <summary>A list of IDs of the menu items that were shown.</summary>
    [JsAccessPath("menuIds")]
    [JsonPropertyName("menuIds")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<MenuId> MenuIds { get; set; }

    /// <summary></summary>
    [JsAccessPath("pageUrl")]
    [JsonPropertyName("pageUrl")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string PageUrl { get; set; }

    /// <summary></summary>
    [JsAccessPath("selectionText")]
    [JsonPropertyName("selectionText")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string SelectionText { get; set; }

    /// <summary></summary>
    [JsAccessPath("srcUrl")]
    [JsonPropertyName("srcUrl")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string SrcUrl { get; set; }

    /// <summary></summary>
    [JsAccessPath("targetElementId")]
    [JsonPropertyName("targetElementId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? TargetElementId { get; set; }

    /// <summary></summary>
    [JsAccessPath("viewType")]
    [JsonPropertyName("viewType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ViewType? ViewType { get; set; }
}
