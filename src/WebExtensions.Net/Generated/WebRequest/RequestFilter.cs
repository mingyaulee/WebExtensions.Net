using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebRequest
{
    // Type Class
    /// <summary>An object describing filters to apply to webRequest events.</summary>
    public partial class RequestFilter : BaseObject
    {
        private bool? _incognito;
        private int? _tabId;
        private IEnumerable<ResourceType> _types;
        private IEnumerable<string> _urls;
        private int? _windowId;

        /// <summary>If provided, requests that do not match the incognito state will be filtered out.</summary>
        [JsonPropertyName("incognito")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
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

        /// <summary></summary>
        [JsonPropertyName("tabId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
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

        /// <summary>A list of request types. Requests that cannot match any of the types will be filtered out.</summary>
        [JsonPropertyName("types")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
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

        /// <summary>A list of URLs or URL patterns. Requests that cannot match any of the URLs will be filtered out.</summary>
        [JsonPropertyName("urls")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
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

        /// <summary></summary>
        [JsonPropertyName("windowId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
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
