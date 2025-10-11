using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class Properties : BaseObject
{
    /// <summary></summary>
    [JsAccessPath("additional_backgrounds_alignment")]
    [JsonPropertyName("additional_backgrounds_alignment")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<AdditionalBackgroundsAlignmentArrayItem> Additional_backgrounds_alignment { get; set; }

    /// <summary></summary>
    [JsAccessPath("additional_backgrounds_tiling")]
    [JsonPropertyName("additional_backgrounds_tiling")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<AdditionalBackgroundsTilingArrayItem> Additional_backgrounds_tiling { get; set; }

    /// <summary></summary>
    [JsAccessPath("color_scheme")]
    [JsonPropertyName("color_scheme")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ColorScheme? Color_scheme { get; set; }

    /// <summary></summary>
    [JsAccessPath("content_color_scheme")]
    [JsonPropertyName("content_color_scheme")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ContentColorScheme? Content_color_scheme { get; set; }
}
