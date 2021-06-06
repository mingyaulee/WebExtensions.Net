using System.Text.Json.Serialization;

namespace WebExtension.Net.ExtensionTypes
{
    // Type Class
    /// <summary>The area of the document to capture, in CSS pixels, relative to the page.  If omitted, capture the visible viewport.</summary>
    public class Rect : BaseObject
    {
        private double _height;
        private double _width;
        private double _X;
        private double _Y;

        /// <summary></summary>
        [JsonPropertyName("height")]
        public double Height
        {
            get
            {
                InitializeProperty("height", _height);
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("width")]
        public double Width
        {
            get
            {
                InitializeProperty("width", _width);
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("X")]
        public double X
        {
            get
            {
                InitializeProperty("X", _X);
                return _X;
            }
            set
            {
                _X = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("Y")]
        public double Y
        {
            get
            {
                InitializeProperty("Y", _Y);
                return _Y;
            }
            set
            {
                _Y = value;
            }
        }
    }
}
