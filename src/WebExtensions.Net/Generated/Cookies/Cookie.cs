using System.Text.Json.Serialization;

namespace WebExtensions.Net.Cookies
{
    // Type Class
    /// <summary>Represents information about an HTTP cookie.</summary>
    public partial class Cookie : BaseObject
    {
        private string _domain;
        private double? _expirationDate;
        private string _firstPartyDomain;
        private bool _hostOnly;
        private bool _httpOnly;
        private string _name;
        private string _path;
        private SameSiteStatus _sameSite;
        private bool _secure;
        private bool _session;
        private string _storeId;
        private string _value;

        /// <summary>The domain of the cookie (e.g. "www.google.com", "example.com").</summary>
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

        /// <summary>The expiration date of the cookie as the number of seconds since the UNIX epoch. Not provided for session cookies.</summary>
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

        /// <summary>The first-party domain of the cookie.</summary>
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

        /// <summary>True if the cookie is a host-only cookie (i.e. a request's host must exactly match the domain of the cookie).</summary>
        [JsonPropertyName("hostOnly")]
        public bool HostOnly
        {
            get
            {
                InitializeProperty("hostOnly", _hostOnly);
                return _hostOnly;
            }
            set
            {
                _hostOnly = value;
            }
        }

        /// <summary>True if the cookie is marked as HttpOnly (i.e. the cookie is inaccessible to client-side scripts).</summary>
        [JsonPropertyName("httpOnly")]
        public bool HttpOnly
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

        /// <summary>The name of the cookie.</summary>
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

        /// <summary>The path of the cookie.</summary>
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

        /// <summary>The cookie's same-site status (i.e. whether the cookie is sent with cross-site requests).</summary>
        [JsonPropertyName("sameSite")]
        public SameSiteStatus SameSite
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

        /// <summary>True if the cookie is marked as Secure (i.e. its scope is limited to secure channels, typically HTTPS).</summary>
        [JsonPropertyName("secure")]
        public bool Secure
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

        /// <summary>True if the cookie is a session cookie, as opposed to a persistent cookie with an expiration date.</summary>
        [JsonPropertyName("session")]
        public bool Session
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

        /// <summary>The ID of the cookie store containing this cookie, as provided in getAllCookieStores().</summary>
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

        /// <summary>The value of the cookie.</summary>
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
