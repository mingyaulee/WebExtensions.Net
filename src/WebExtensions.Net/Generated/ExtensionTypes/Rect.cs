﻿using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.ExtensionTypes;

// Type Class
/// <summary>The area of the document to capture, in CSS pixels, relative to the page.  If omitted, capture the visible viewport.</summary>
[BindAllProperties]
public partial class Rect : BaseObject
{
    /// <summary></summary>
    [JsAccessPath("height")]
    [JsonPropertyName("height")]
    public double Height { get; set; }

    /// <summary></summary>
    [JsAccessPath("width")]
    [JsonPropertyName("width")]
    public double Width { get; set; }

    /// <summary></summary>
    [JsAccessPath("x")]
    [JsonPropertyName("x")]
    public double X { get; set; }

    /// <summary></summary>
    [JsAccessPath("y")]
    [JsonPropertyName("y")]
    public double Y { get; set; }
}
