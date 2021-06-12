using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Cookies
{
    // Type Class
    /// <summary>Represents a cookie store in the browser. An incognito mode window, for instance, uses a separate cookie store from a non-incognito window.</summary>
    public partial class CookieStore : BaseObject
    {
        private string _id;
        private bool _incognito;
        private IEnumerable<int> _tabIds;

        /// <summary>The unique identifier for the cookie store.</summary>
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Id
        {
            get
            {
                InitializeProperty("id", _id);
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        /// <summary>Indicates if this is an incognito cookie store</summary>
        [JsonPropertyName("incognito")]
        public bool Incognito
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

        /// <summary>Identifiers of all the browser tabs that share this cookie store.</summary>
        [JsonPropertyName("tabIds")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<int> TabIds
        {
            get
            {
                InitializeProperty("tabIds", _tabIds);
                return _tabIds;
            }
            set
            {
                _tabIds = value;
            }
        }
    }
}
