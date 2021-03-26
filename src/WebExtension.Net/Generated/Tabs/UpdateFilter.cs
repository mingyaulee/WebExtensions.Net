using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Tabs
{
    // Class Definition
    /// <summary>
    /// An object describing filters to apply to tabs.onUpdated events.
    /// </summary>
    public class UpdateFilter : BaseObject
    {
        
        // Property Definition
        private IEnumerable<string> _urls;
        /// <summary>
        /// A list of URLs or URL patterns. Events that cannot match any of the URLs will be filtered out.  Filtering with urls requires the <c>"tabs"</c> or  <c>"activeTab"</c> permission.
        /// </summary>
        [JsonPropertyName("urls")]
        public IEnumerable<string> Urls
        {
            get
            {
                InitializeProperty("urls", _urls);
                return _urls;
            }
            set
            {
                _urls = value;
            }
        }
        
        // Property Definition
        private IEnumerable<UpdatePropertyName> _properties;
        /// <summary>
        /// A list of property names. Events that do not match any of the names will be filtered out.
        /// </summary>
        [JsonPropertyName("properties")]
        public IEnumerable<UpdatePropertyName> Properties
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
        
        // Property Definition
        private int? _tabId;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("tabId")]
        public int? TabId
        {
            get
            {
                InitializeProperty("tabId", _tabId);
                return _tabId;
            }
            set
            {
                _tabId = value;
            }
        }
        
        // Property Definition
        private int? _windowId;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("windowId")]
        public int? WindowId
        {
            get
            {
                InitializeProperty("windowId", _windowId);
                return _windowId;
            }
            set
            {
                _windowId = value;
            }
        }
    }
}

