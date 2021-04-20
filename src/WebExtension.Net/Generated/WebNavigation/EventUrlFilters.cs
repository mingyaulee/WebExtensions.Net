using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebExtension.Net.Events;

namespace WebExtension.Net.WebNavigation
{
    // Type Class
    /// <summary></summary>
    public class EventUrlFilters : BaseObject
    {
        private IEnumerable<UrlFilter> _url;

        /// <summary></summary>
        [JsonPropertyName("url")]
        public IEnumerable<UrlFilter> Url
        {
            get
            {
                InitializeProperty("url", _url);
                return _url;
            }
            set
            {
                _url = value;
            }
        }
    }
}
