﻿using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs;

// Type Class
/// <summary>An object describing filters to apply to tabs.onUpdated events.</summary>
[BindAllProperties]
public partial class UpdateFilter : BaseObject
{
    /// <summary></summary>
    [JsAccessPath("cookieStoreId")]
    [JsonPropertyName("cookieStoreId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string CookieStoreId { get; set; }

    /// <summary>A list of property names. Events that do not match any of the names will be filtered out.</summary>
    [JsAccessPath("properties")]
    [JsonPropertyName("properties")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<UpdatePropertyName> Properties { get; set; }

    /// <summary></summary>
    [JsAccessPath("tabId")]
    [JsonPropertyName("tabId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? TabId { get; set; }

    /// <summary>A list of URLs or URL patterns. Events that cannot match any of the URLs will be filtered out.  Filtering with urls requires the <c>"tabs"</c> or  <c>"activeTab"</c> permission.</summary>
    [JsAccessPath("urls")]
    [JsonPropertyName("urls")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<string> Urls { get; set; }

    /// <summary></summary>
    [JsAccessPath("windowId")]
    [JsonPropertyName("windowId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? WindowId { get; set; }
}
