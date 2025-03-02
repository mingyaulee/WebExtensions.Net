using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.DeclarativeNetRequest
{
    // Type Class
    /// <summary>The condition under which this rule is triggered.</summary>
    [BindAllProperties]
    public partial class Condition : BaseObject
    {
        /// <summary>Specifies whether the network request is first-party or third-party to the domain from which it originated. If omitted, all requests are matched.</summary>
        [JsAccessPath("domainType")]
        [JsonPropertyName("domainType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DomainType? DomainType { get; set; }

        /// <summary>The rule will not match network requests originating from the list of 'initiatorDomains'. If the list is empty or omitted, no domains are excluded. This takes precedence over 'initiatorDomains'.</summary>
        [JsAccessPath("excludedInitiatorDomains")]
        [JsonPropertyName("excludedInitiatorDomains")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> ExcludedInitiatorDomains { get; set; }

        /// <summary>The rule will not match network requests when the domains matches one from the list of 'excludedRequestDomains'. If the list is empty or omitted, no domains are excluded. This takes precedence over 'requestDomains'.</summary>
        [JsAccessPath("excludedRequestDomains")]
        [JsonPropertyName("excludedRequestDomains")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> ExcludedRequestDomains { get; set; }

        /// <summary>List of request methods which the rule won't match. Cannot be specified if 'requestMethods' is specified. If neither of them is specified, all request methods are matched.</summary>
        [JsAccessPath("excludedRequestMethods")]
        [JsonPropertyName("excludedRequestMethods")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> ExcludedRequestMethods { get; set; }

        /// <summary>List of resource types which the rule won't match. Cannot be specified if 'resourceTypes' is specified. If neither of them is specified, all resource types except 'main_frame' are matched.</summary>
        [JsAccessPath("excludedResourceTypes")]
        [JsonPropertyName("excludedResourceTypes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<ResourceType> ExcludedResourceTypes { get; set; }

        /// <summary>List of tabIds which the rule should not match. An ID of -1 excludes requests which don't originate from a tab. Only supported for session-scoped rules.</summary>
        [JsAccessPath("excludedTabIds")]
        [JsonPropertyName("excludedTabIds")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<int> ExcludedTabIds { get; set; }

        /// <summary>The rule will only match network requests originating from the list of 'initiatorDomains'. If the list is omitted, the rule is applied to requests from all domains.</summary>
        [JsAccessPath("initiatorDomains")]
        [JsonPropertyName("initiatorDomains")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> InitiatorDomains { get; set; }

        /// <summary>Whether 'urlFilter' or 'regexFilter' is case-sensitive.</summary>
        [JsAccessPath("isUrlFilterCaseSensitive")]
        [JsonPropertyName("isUrlFilterCaseSensitive")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsUrlFilterCaseSensitive { get; set; }

        /// <summary>Regular expression to match against the network request url. Only one of 'urlFilter' or 'regexFilter' can be specified.</summary>
        [JsAccessPath("regexFilter")]
        [JsonPropertyName("regexFilter")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string RegexFilter { get; set; }

        /// <summary>The rule will only match network requests when the domain matches one from the list of 'requestDomains'. If the list is omitted, the rule is applied to requests from all domains.</summary>
        [JsAccessPath("requestDomains")]
        [JsonPropertyName("requestDomains")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> RequestDomains { get; set; }

        /// <summary>List of HTTP request methods which the rule can match. Should be a lower-case method such as 'connect', 'delete', 'get', 'head', 'options', 'patch', 'post', 'put'.'</summary>
        [JsAccessPath("requestMethods")]
        [JsonPropertyName("requestMethods")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> RequestMethods { get; set; }

        /// <summary>List of resource types which the rule can match. When the rule action is 'allowAllRequests', this must be specified and may only contain 'main_frame' or 'sub_frame'. Cannot be specified if 'excludedResourceTypes' is specified. If neither of them is specified, all resource types except 'main_frame' are matched.</summary>
        [JsAccessPath("resourceTypes")]
        [JsonPropertyName("resourceTypes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<ResourceType> ResourceTypes { get; set; }

        /// <summary>List of tabIds which the rule should match. An ID of -1 matches requests which don't originate from a tab. Only supported for session-scoped rules.</summary>
        [JsAccessPath("tabIds")]
        [JsonPropertyName("tabIds")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<int> TabIds { get; set; }

        /// <summary>TODO: link to doc explaining supported pattern. The pattern which is matched against the network request url. Only one of 'urlFilter' or 'regexFilter' can be specified.</summary>
        [JsAccessPath("urlFilter")]
        [JsonPropertyName("urlFilter")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string UrlFilter { get; set; }
    }
}
