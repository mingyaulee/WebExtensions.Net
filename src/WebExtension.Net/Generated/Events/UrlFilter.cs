// This file is auto generated at 2021-03-24T04:51:22

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Events
{
    // Class Definition
    /// <summary>
    /// Filters URLs for various criteria. See <a href='events#filtered'>event filtering</a>. All criteria are case sensitive.
    /// </summary>
    public class UrlFilter
    {
        
        // Property Definition
        /// <summary>
        /// Matches if the host name of the URL contains a specified string. To test whether a host name component has a prefix 'foo', use hostContains: '.foo'. This matches 'www.foobar.com' and 'foo.com', because an implicit dot is added at the beginning of the host name. Similarly, hostContains can be used to match against component suffix ('foo.') and to exactly match against components ('.foo.'). Suffix- and exact-matching for the last components need to be done separately using hostSuffix, because no implicit dot is added at the end of the host name.
        /// </summary>
        [JsonPropertyName("hostContains")]
        public string HostContains { get; set; }
        
        // Property Definition
        /// <summary>
        /// Matches if the host name of the URL is equal to a specified string.
        /// </summary>
        [JsonPropertyName("hostEquals")]
        public string HostEquals { get; set; }
        
        // Property Definition
        /// <summary>
        /// Matches if the host name of the URL starts with a specified string.
        /// </summary>
        [JsonPropertyName("hostPrefix")]
        public string HostPrefix { get; set; }
        
        // Property Definition
        /// <summary>
        /// Matches if the host name of the URL ends with a specified string.
        /// </summary>
        [JsonPropertyName("hostSuffix")]
        public string HostSuffix { get; set; }
        
        // Property Definition
        /// <summary>
        /// Matches if the path segment of the URL contains a specified string.
        /// </summary>
        [JsonPropertyName("pathContains")]
        public string PathContains { get; set; }
        
        // Property Definition
        /// <summary>
        /// Matches if the path segment of the URL is equal to a specified string.
        /// </summary>
        [JsonPropertyName("pathEquals")]
        public string PathEquals { get; set; }
        
        // Property Definition
        /// <summary>
        /// Matches if the path segment of the URL starts with a specified string.
        /// </summary>
        [JsonPropertyName("pathPrefix")]
        public string PathPrefix { get; set; }
        
        // Property Definition
        /// <summary>
        /// Matches if the path segment of the URL ends with a specified string.
        /// </summary>
        [JsonPropertyName("pathSuffix")]
        public string PathSuffix { get; set; }
        
        // Property Definition
        /// <summary>
        /// Matches if the query segment of the URL contains a specified string.
        /// </summary>
        [JsonPropertyName("queryContains")]
        public string QueryContains { get; set; }
        
        // Property Definition
        /// <summary>
        /// Matches if the query segment of the URL is equal to a specified string.
        /// </summary>
        [JsonPropertyName("queryEquals")]
        public string QueryEquals { get; set; }
        
        // Property Definition
        /// <summary>
        /// Matches if the query segment of the URL starts with a specified string.
        /// </summary>
        [JsonPropertyName("queryPrefix")]
        public string QueryPrefix { get; set; }
        
        // Property Definition
        /// <summary>
        /// Matches if the query segment of the URL ends with a specified string.
        /// </summary>
        [JsonPropertyName("querySuffix")]
        public string QuerySuffix { get; set; }
        
        // Property Definition
        /// <summary>
        /// Matches if the URL (without fragment identifier) contains a specified string. Port numbers are stripped from the URL if they match the default port number.
        /// </summary>
        [JsonPropertyName("urlContains")]
        public string UrlContains { get; set; }
        
        // Property Definition
        /// <summary>
        /// Matches if the URL (without fragment identifier) is equal to a specified string. Port numbers are stripped from the URL if they match the default port number.
        /// </summary>
        [JsonPropertyName("urlEquals")]
        public string UrlEquals { get; set; }
        
        // Property Definition
        /// <summary>
        /// Matches if the URL (without fragment identifier) matches a specified regular expression. Port numbers are stripped from the URL if they match the default port number. The regular expressions use the <a href="https://github.com/google/re2/blob/master/doc/syntax.txt">RE2 syntax</a>.
        /// </summary>
        [JsonPropertyName("urlMatches")]
        public string UrlMatches { get; set; }
        
        // Property Definition
        /// <summary>
        /// Matches if the URL without query segment and fragment identifier matches a specified regular expression. Port numbers are stripped from the URL if they match the default port number. The regular expressions use the <a href="https://github.com/google/re2/blob/master/doc/syntax.txt">RE2 syntax</a>.
        /// </summary>
        [JsonPropertyName("originAndPathMatches")]
        public string OriginAndPathMatches { get; set; }
        
        // Property Definition
        /// <summary>
        /// Matches if the URL (without fragment identifier) starts with a specified string. Port numbers are stripped from the URL if they match the default port number.
        /// </summary>
        [JsonPropertyName("urlPrefix")]
        public string UrlPrefix { get; set; }
        
        // Property Definition
        /// <summary>
        /// Matches if the URL (without fragment identifier) ends with a specified string. Port numbers are stripped from the URL if they match the default port number.
        /// </summary>
        [JsonPropertyName("urlSuffix")]
        public string UrlSuffix { get; set; }
        
        // Property Definition
        /// <summary>
        /// Matches if the scheme of the URL is equal to any of the schemes specified in the array.
        /// </summary>
        [JsonPropertyName("schemes")]
        public IEnumerable<string> Schemes { get; set; }
        
        // Property Definition
        /// <summary>
        /// Matches if the port of the URL is contained in any of the specified port lists. For example <c>[80, 443, [1000, 1200]]</c> matches all requests on port 80, 443 and in the range 1000-1200.
        /// </summary>
        [JsonPropertyName("ports")]
        public IEnumerable<object> Ports { get; set; }
    }
}

