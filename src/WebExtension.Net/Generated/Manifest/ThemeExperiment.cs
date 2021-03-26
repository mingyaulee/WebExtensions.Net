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
    public class ThemeExperiment : BaseObject
    {
        
        // Property Definition
        private ExtensionURL _stylesheet;
        /// <summary>
        /// 
        /// </summary>
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
        
        // Property Definition
        private object _images;
        /// <summary>
        /// 
        /// </summary>
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
        
        // Property Definition
        private object _colors;
        /// <summary>
        /// 
        /// </summary>
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
        
        // Property Definition
        private object _properties;
        /// <summary>
        /// 
        /// </summary>
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
    }
}

