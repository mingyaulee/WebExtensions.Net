using System.Text.Json.Serialization;

namespace WebExtensions.Net.Cookies
{
    // Type Class
    /// <summary>Details about the cookie being set.</summary>
    public partial class SetDetails : BaseObject
    {
        private string _domain;
        private double? _expirationDate;
        private string _firstPartyDomain;
        private bool? _httpOnly;
        private string _name;
        private string _path;
        private SameSiteStatus? _sameSite;
        private bool? _secure;
        private string _storeId;
        private string _url;
        private string _value;

        /// <summary>The domain of the cookie. If omitted, the cookie becomes a host-only cookie.</summary>
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

        /// <summary>The expiration date of the cookie as the number of seconds since the UNIX epoch. If omitted, the cookie becomes a session cookie.</summary>
        [JsonPropertyName("expirationDate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? ExpirationDate
        {
            get
            {
                InitializeProperty("expirationDate", _expirationDate);
                return _expirationDate;
            }
            set
            {
                _expirationDate = value;
            }
        }

        /// <summary>The first-party domain of the cookie. This attribute is required if First-Party Isolation is enabled.</summary>
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

        /// <summary>Whether the cookie should be marked as HttpOnly. Defaults to false.</summary>
        [JsonPropertyName("httpOnly")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? HttpOnly
        {
            get
            {
                InitializeProperty("httpOnly", _httpOnly);
                return _httpOnly;
            }
            set
            {
                _httpOnly = value;
            }
        }

        /// <summary>The name of the cookie. Empty by default if omitted.</summary>
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

        /// <summary>The path of the cookie. Defaults to the path portion of the url parameter.</summary>
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

        /// <summary>The cookie's same-site status.</summary>
        [JsonPropertyName("sameSite")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public SameSiteStatus? SameSite
        {
            get
            {
                InitializeProperty("sameSite", _sameSite);
                return _sameSite;
            }
            set
            {
                _sameSite = value;
            }
        }

        /// <summary>Whether the cookie should be marked as Secure. Defaults to false.</summary>
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

        /// <summary>The ID of the cookie store in which to set the cookie. By default, the cookie is set in the current execution context's cookie store.</summary>
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

        /// <summary>The request-URI to associate with the setting of the cookie. This value can affect the default domain and path values of the created cookie. If host permissions for this URL are not specified in the manifest file, the API call will fail.</summary>
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

        /// <summary>The value of the cookie. Empty by default if omitted.</summary>
        [JsonPropertyName("value")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Value
        {
            get
            {
                InitializeProperty("value", _value);
                return _value;
            }
            set
            {
                _value = value;
            }
        }
    }
}
