using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Manifest
{
    // Class Definition
    /// <summary>
    /// 
    /// </summary>
    public class ThemeIcons : BaseObject
    {
        
        // Property Definition
        private ExtensionURL _light;
        /// <summary>
        /// A light icon to use for dark themes
        /// </summary>
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
        
        // Property Definition
        private ExtensionURL _dark;
        /// <summary>
        /// The dark icon to use for light themes
        /// </summary>
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
        
        // Property Definition
        private int _size;
        /// <summary>
        /// The size of the icons
        /// </summary>
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

