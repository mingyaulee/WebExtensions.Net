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
        [JsAccessPath("firstParty")]
        [JsonPropertyName("firstParty")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public UrlClassificationParty FirstParty { get; set; }

        /// <summary>Classification flags if the request has been classified and it or its window hierarchy is third party.</summary>
        [JsAccessPath("thirdParty")]
        [JsonPropertyName("thirdParty")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public UrlClassificationParty ThirdParty { get; set; }
    }
}
