using System.Text.Json.Serialization;

namespace WebExtension.Net.Manifest
{
    // Type Class
    /// <summary></summary>
    public class ThemeIcons : BaseObject
    {
        private ExtensionURL _light;
        private ExtensionURL _dark;
        private int _size;

        /// <summary>A light icon to use for dark themes</summary>
        [JsonPropertyName("light")]
        public ExtensionURL Light
        {
            get
            {
                InitializeProperty("light", _light);
                return _light;
            }
            set
            {
                _light = value;
            }
        }

        /// <summary>The dark icon to use for light themes</summary>
        [JsonPropertyName("dark")]
        public ExtensionURL Dark
        {
            get
            {
                InitializeProperty("dark", _dark);
                return _dark;
            }
            set
            {
                _dark = value;
            }
        }

        /// <summary>The size of the icons</summary>
        [JsonPropertyName("size")]
        public int Size
        {
            get
            {
                InitializeProperty("size", _size);
                return _size;
            }
            set
            {
                _size = value;
            }
        }
    }
}
