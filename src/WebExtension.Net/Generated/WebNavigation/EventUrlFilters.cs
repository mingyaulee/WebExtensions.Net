using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtension.Net.WebNavigation
{
    // Type Class
    /// <summary></summary>
    public class EventUrlFilters : BaseObject
    {
        private IEnumerable<Events.UrlFilter> _url;

        /// <summary></summary>
        [JsonPropertyName("url")]
        public IEnumerable<Events.UrlFilter> Url
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
