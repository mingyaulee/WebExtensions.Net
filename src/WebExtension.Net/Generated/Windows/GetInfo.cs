using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Windows
{
    // Class Definition
    /// <summary>
    /// Specifies whether the $(ref:windows.Window) returned should contain a list of the $(ref:tabs.Tab) objects.
    /// </summary>
    public class GetInfo : BaseObject
    {
        
        // Property Definition
        private bool? _populate;
        /// <summary>
        /// If true, the $(ref:windows.Window) returned will have a <var>tabs</var> property that contains a list of the $(ref:tabs.Tab) objects. The <c>Tab</c> objects only contain the <c>url</c>, <c>title</c> and <c>favIconUrl</c> properties if the extension's manifest file includes the <c>"tabs"</c> permission.
        /// </summary>
        [JsonPropertyName("populate")]
        public bool? Populate
        {
            get
            {
                InitializeProperty("populate", _populate);
                return _populate;
            }
            set
            {
                _populate = value;
            }
        }
        
        // Property Definition
        private IEnumerable<WindowType> _windowTypes;
        /// <summary>
        /// <c>windowTypes</c> is deprecated and ignored on Firefox.
        /// </summary>
        [Obsolete("")]
        [JsonPropertyName("windowTypes")]
        public IEnumerable<WindowType> WindowTypes
        {
            get
            {
                InitializeProperty("windowTypes", _windowTypes);
                return _windowTypes;
            }
            set
            {
                _windowTypes = value;
            }
        }
    }
}

