using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.ExtensionTypes
{
    // Type Class
    /// <summary>Details about the format, quality, area and scale of the capture.</summary>
    [BindAllProperties]
    public partial class ImageDetails : BaseObject
    {
        /// <summary>The format of the resulting image.  Default is <c>"jpeg"</c>.</summary>
        [JsAccessPath("format")]
        [JsonPropertyName("format")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ImageFormat? Format { get; set; }

        /// <summary>When format is <c>"jpeg"</c>, controls the quality of the resulting image.  This value is ignored for PNG images.  As quality is decreased, the resulting image will have more visual artifacts, and the number of bytes needed to store it will decrease.</summary>
        [JsAccessPath("quality")]
        [JsonPropertyName("quality")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Quality { get; set; }

        /// <summary>The area of the document to capture, in CSS pixels, relative to the page.  If omitted, capture the visible viewport.</summary>
        [JsAccessPath("rect")]
        [JsonPropertyName("rect")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Rect Rect { get; set; }

        /// <summary>If true, temporarily resets the scroll position of the document to 0. Only takes effect if rect is also specified.</summary>
        [JsAccessPath("resetScrollPosition")]
        [JsonPropertyName("resetScrollPosition")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ResetScrollPosition { get; set; }

        /// <summary>The scale of the resulting image.  Defaults to <c>devicePixelRatio</c>.</summary>
        [JsAccessPath("scale")]
        [JsonPropertyName("scale")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Scale { get; set; }
    }
}
