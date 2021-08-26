using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebRequest
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class UrlClassification : BaseObject
    {
        /// <summary>Classification flags if the request has been classified and it is first party.</summary>
        [JsonPropertyName("firstParty")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public UrlClassificationParty FirstParty { get; set; }

        /// <summary>Classification flags if the request has been classified and it or its window hierarchy is third party.</summary>
        [JsonPropertyName("thirdParty")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public UrlClassificationParty ThirdParty { get; set; }
    }
}
