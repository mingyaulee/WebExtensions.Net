using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary>An object describing filters to apply to tabs.onUpdated events.</summary>
    public partial class UpdateFilter : BaseObject
    {
        private IEnumerable<UpdatePropertyName> _properties;
        private int? _tabId;
        private IEnumerable<string> _urls;
        private int? _windowId;

        /// <summary>A list of property names. Events that do not match any of the names will be filtered out.</summary>
        [JsonPropertyName("properties")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
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

        /// <summary>A list of URLs or URL patterns. Events that cannot match any of the URLs will be filtered out.  Filtering with urls requires the <c>"tabs"</c> or  <c>"activeTab"</c> permission.</summary>
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
