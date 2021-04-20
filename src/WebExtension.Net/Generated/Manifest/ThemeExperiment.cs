using System.Text.Json.Serialization;

namespace WebExtension.Net.Manifest
{
    // Type Class
    /// <summary></summary>
    public class ThemeExperiment : BaseObject
    {
        private object _colors;
        private object _images;
        private object _properties;
        private ExtensionURL _stylesheet;

        /// <summary></summary>
        [JsonPropertyName("colors")]
        public object Colors
        {
            get
            {
                InitializeProperty("colors", _colors);
                return _colors;
            }
            set
            {
                _colors = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("images")]
        public object Images
        {
            get
            {
                InitializeProperty("images", _images);
                return _images;
            }
            set
            {
                _images = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("properties")]
        public object Properties
        {
            get
            {
                InitializeProperty("properties", _properties);
                return _properties;
            }
            set
            {
                _properties = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("stylesheet")]
        public ExtensionURL Stylesheet
        {
            get
            {
                InitializeProperty("stylesheet", _stylesheet);
                return _stylesheet;
            }
            set
            {
                _stylesheet = value;
            }
        }
    }
}
