using System.Text.Json.Serialization;

namespace WebExtensions.Net.Cookies
{
    // Type Class
    /// <summary>Information to identify the cookie to remove.</summary>
    public partial class RemoveDetails : BaseObject
    {
        private string _firstPartyDomain;
        private string _name;
        private string _storeId;
        private string _url;

        /// <summary>The first-party domain associated with the cookie. This attribute is required if First-Party Isolation is enabled.</summary>
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

        /// <summary>The name of the cookie to remove.</summary>
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

        /// <summary>The ID of the cookie store to look in for the cookie. If unspecified, the cookie is looked for by default in the current execution context's cookie store.</summary>
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

        /// <summary>The URL associated with the cookie. If host permissions for this URL are not specified in the manifest file, the API call will fail.</summary>
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
