using System.Text.Json.Serialization;

namespace WebExtension.Net.WebRequest
{
    // Type Class
    /// <summary></summary>
    public class UrlClassification : BaseObject
    {
        private UrlClassificationParty _firstParty;
        private UrlClassificationParty _thirdParty;

        /// <summary>Classification flags if the request has been classified and it is first party.</summary>
        [JsonPropertyName("firstParty")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public UrlClassificationParty FirstParty
        {
            get
            {
                InitializeProperty("firstParty", _firstParty);
                return _firstParty;
            }
            set
            {
                _firstParty = value;
            }
        }

        /// <summary>Classification flags if the request has been classified and it or its window hierarchy is third party.</summary>
        [JsonPropertyName("thirdParty")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public UrlClassificationParty ThirdParty
        {
            get
            {
                InitializeProperty("thirdParty", _thirdParty);
                return _thirdParty;
            }
            set
            {
                _thirdParty = value;
            }
        }
    }
}
