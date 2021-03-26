using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.WebNavigation
{
    // Class Definition
    /// <summary>
    /// 
    /// </summary>
    public class EventUrlFilters : BaseObject
    {
        
        // Property Definition
        private IEnumerable<Events.UrlFilter> _url;
        /// <summary>
        /// 
        /// </summary>
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

