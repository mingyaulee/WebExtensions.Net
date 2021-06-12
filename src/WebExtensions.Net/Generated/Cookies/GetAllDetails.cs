using System.Text.Json.Serialization;

namespace WebExtensions.Net.Cookies
{
    // Type Class
    /// <summary>Information to filter the cookies being retrieved.</summary>
    public partial class GetAllDetails : BaseObject
    {
        private string _domain;
        private string _firstPartyDomain;
        private string _name;
        private string _path;
        private bool? _secure;
        private bool? _session;
        private string _storeId;
        private string _url;

        /// <summary>Restricts the retrieved cookies to those whose domains match or are subdomains of this one.</summary>
        [JsonPropertyName("domain")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Domain
        {
            get
            {
                InitializeProperty("domain", _domain);
                return _domain;
            }
            set
            {
                _domain = value;
            }
        }

        /// <summary>Restricts the retrieved cookies to those whose first-party domains match this one. This attribute is required if First-Party Isolation is enabled. To not filter by a specific first-party domain, use `null` or `undefined`.</summary>
        [JsonPropertyName("firstPartyDomain")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string FirstPartyDomain
        {
            get
            {
                InitializeProperty("firstPartyDomain", _firstPartyDomain);
                return _firstPartyDomain;
            }
            set
            {
                _firstPartyDomain = value;
            }
        }

        /// <summary>Filters the cookies by name.</summary>
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Name
        {
            get
            {
                InitializeProperty("name", _name);
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /// <summary>Restricts the retrieved cookies to those whose path exactly matches this string.</summary>
        [JsonPropertyName("path")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Path
        {
            get
            {
                InitializeProperty("path", _path);
                return _path;
            }
            set
            {
                _path = value;
            }
        }

        /// <summary>Filters the cookies by their Secure property.</summary>
        [JsonPropertyName("secure")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Secure
        {
            get
            {
                InitializeProperty("secure", _secure);
                return _secure;
            }
            set
            {
                _secure = value;
            }
        }

        /// <summary>Filters out session vs. persistent cookies.</summary>
        [JsonPropertyName("session")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Session
        {
            get
            {
                InitializeProperty("session", _session);
                return _session;
            }
            set
            {
                _session = value;
            }
        }

        /// <summary>The cookie store to retrieve cookies from. If omitted, the current execution context's cookie store will be used.</summary>
        [JsonPropertyName("storeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string StoreId
        {
            get
            {
                InitializeProperty("storeId", _storeId);
                return _storeId;
            }
            set
            {
                _storeId = value;
            }
        }

        /// <summary>Restricts the retrieved cookies to those that would match the given URL.</summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Url
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
