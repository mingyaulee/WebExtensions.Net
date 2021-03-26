using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.WebRequest
{
    // Class Definition
    /// <summary>
    /// An object describing filters to apply to webRequest events.
    /// </summary>
    public class RequestFilter : BaseObject
    {
        
        // Property Definition
        private IEnumerable<string> _urls;
        /// <summary>
        /// A list of URLs or URL patterns. Requests that cannot match any of the URLs will be filtered out.
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
        private IEnumerable<ResourceType> _types;
        /// <summary>
        /// A list of request types. Requests that cannot match any of the types will be filtered out.
        /// </summary>
        [JsonPropertyName("types")]
        public IEnumerable<ResourceType> Types
        {
            get
            {
                InitializeProperty("types", _types);
                return _types;
            }
            set
            {
                _types = value;
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
        
        // Property Definition
        private bool? _incognito;
        /// <summary>
        /// If provided, requests that do not match the incognito state will be filtered out.
        /// </summary>
        [JsonPropertyName("incognito")]
        public bool? Incognito
        {
            get
            {
                InitializeProperty("incognito", _incognito);
                return _incognito;
            }
            set
            {
                _incognito = value;
            }
        }
    }
}

