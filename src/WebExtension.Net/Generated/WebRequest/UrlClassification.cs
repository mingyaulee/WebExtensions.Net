using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.WebRequest
{
    // Class Definition
    /// <summary>
    /// 
    /// </summary>
    public class UrlClassification : BaseObject
    {
        
        // Property Definition
        private UrlClassificationParty _firstParty;
        /// <summary>
        /// Classification flags if the request has been classified and it is first party.
        /// </summary>
        [JsonPropertyName("firstParty")]
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
        
        // Property Definition
        private UrlClassificationParty _thirdParty;
        /// <summary>
        /// Classification flags if the request has been classified and it or its window hierarchy is third party.
        /// </summary>
        [JsonPropertyName("thirdParty")]
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

