using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtension.Net.WebRequest
{
    // Type Class
    /// <summary>An object describing filters to apply to webRequest events.</summary>
    public class RequestFilter : BaseObject
    {
        private IEnumerable<string> _urls;
        private IEnumerable<ResourceType> _types;
        private int? _tabId;
        private int? _windowId;
        private bool? _incognito;

        /// <summary>A list of URLs or URL patterns. Requests that cannot match any of the URLs will be filtered out.</summary>
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

        /// <summary>A list of request types. Requests that cannot match any of the types will be filtered out.</summary>
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

        /// <summary></summary>
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

        /// <summary></summary>
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

        /// <summary>If provided, requests that do not match the incognito state will be filtered out.</summary>
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
