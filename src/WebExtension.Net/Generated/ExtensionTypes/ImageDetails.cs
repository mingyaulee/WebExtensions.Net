using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.ExtensionTypes
{
    // Class Definition
    /// <summary>
    /// Details about the format, quality, area and scale of the capture.
    /// </summary>
    public class ImageDetails : BaseObject
    {
        
        // Property Definition
        private ImageFormat _format;
        /// <summary>
        /// The format of the resulting image.  Default is <c>"jpeg"</c>.
        /// </summary>
        [JsonPropertyName("format")]
        public ImageFormat Format
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
        
        // Property Definition
        private int? _quality;
        /// <summary>
        /// When format is <c>"jpeg"</c>, controls the quality of the resulting image.  This value is ignored for PNG images.  As quality is decreased, the resulting image will have more visual artifacts, and the number of bytes needed to store it will decrease.
        /// </summary>
        [JsonPropertyName("quality")]
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
        
        // Property Definition
        private object _rect;
        /// <summary>
        /// The area of the document to capture, in CSS pixels, relative to the page.  If omitted, capture the visible viewport.
        /// </summary>
        [JsonPropertyName("rect")]
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
        
        // Property Definition
        private double? _scale;
        /// <summary>
        /// The scale of the resulting image.  Defaults to <c>devicePixelRatio</c>.
        /// </summary>
        [JsonPropertyName("scale")]
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

