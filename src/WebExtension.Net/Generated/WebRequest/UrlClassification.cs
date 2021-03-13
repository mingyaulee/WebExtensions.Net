/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.WebRequest
{
    /// Class Definition
    /// <summary></summary>
    public class UrlClassification
    {
        
        /// Property Definition
        /// <summary>Classification flags if the request has been classified and it is first party.</summary>
        [JsonPropertyName("firstParty")]
        public UrlClassificationParty FirstParty { get; set; }
        
        /// Property Definition
        /// <summary>Classification flags if the request has been classified and it or its window hierarchy is third party.</summary>
        [JsonPropertyName("thirdParty")]
        public UrlClassificationParty ThirdParty { get; set; }
    }
}

