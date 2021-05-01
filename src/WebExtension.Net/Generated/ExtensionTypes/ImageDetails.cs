using System.Text.Json.Serialization;

namespace WebExtension.Net.ExtensionTypes
{
    // Type Class
    /// <summary>Details about the format, quality, area and scale of the capture.</summary>
    public class ImageDetails : BaseObject
    {
        private ImageFormat? _format;
        private int? _quality;
        private object _rect;
        private double? _scale;

        /// <summary>The format of the resulting image.  Default is <c>"jpeg"</c>.</summary>
        [JsonPropertyName("format")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ImageFormat? Format
        {
            get
            {
                InitializeProperty("format", _format);
                return _format;
            }
            set
            {
                _format = value;
            }
        }

        /// <summary>When format is <c>"jpeg"</c>, controls the quality of the resulting image.  This value is ignored for PNG images.  As quality is decreased, the resulting image will have more visual artifacts, and the number of bytes needed to store it will decrease.</summary>
        [JsonPropertyName("quality")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Quality
        {
            get
            {
                InitializeProperty("quality", _quality);
                return _quality;
            }
            set
            {
                _quality = value;
            }
        }

        /// <summary>The area of the document to capture, in CSS pixels, relative to the page.  If omitted, capture the visible viewport.</summary>
        [JsonPropertyName("rect")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object Rect
        {
            get
            {
                InitializeProperty("rect", _rect);
                return _rect;
            }
            set
            {
                _rect = value;
            }
        }

        /// <summary>The scale of the resulting image.  Defaults to <c>devicePixelRatio</c>.</summary>
        [JsonPropertyName("scale")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Scale
        {
            get
            {
                InitializeProperty("scale", _scale);
                return _scale;
            }
            set
            {
                _scale = value;
            }
        }
    }
}
