using System.Text.Json.Serialization;

namespace WebExtensions.Net.Cookies
{
    // Type Class
    /// <summary>Contains details about the cookie that's been removed.  If removal failed for any reason, this will be "null", and $(ref:runtime.lastError) will be set.</summary>
    public partial class CallbackDetails : BaseObject
    {
        private string _firstPartyDomain;
        private string _name;
        private string _storeId;
        private string _url;

        /// <summary>The first-party domain associated with the cookie that's been removed.</summary>
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

        /// <summary>The name of the cookie that's been removed.</summary>
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

        /// <summary>The ID of the cookie store from which the cookie was removed.</summary>
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

        /// <summary>The URL associated with the cookie that's been removed.</summary>
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
