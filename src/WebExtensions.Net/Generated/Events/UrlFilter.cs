using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Events
{
    // Type Class
    /// <summary>Filters URLs for various criteria. See <see href='events#filtered'>event filtering</see>. All criteria are case sensitive.</summary>
    [BindAllProperties]
    public partial class UrlFilter : BaseObject
    {
        /// <summary>Matches if the host name of the URL contains a specified string. To test whether a host name component has a prefix 'foo', use hostContains: '.foo'. This matches 'www.foobar.com' and 'foo.com', because an implicit dot is added at the beginning of the host name. Similarly, hostContains can be used to match against component suffix ('foo.') and to exactly match against components ('.foo.'). Suffix- and exact-matching for the last components need to be done separately using hostSuffix, because no implicit dot is added at the end of the host name.</summary>
        [JsonPropertyName("hostContains")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string HostContains { get; set; }

        /// <summary>Matches if the host name of the URL is equal to a specified string.</summary>
        [JsonPropertyName("hostEquals")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string HostEquals { get; set; }

        /// <summary>Matches if the host name of the URL starts with a specified string.</summary>
        [JsonPropertyName("hostPrefix")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string HostPrefix { get; set; }

        /// <summary>Matches if the host name of the URL ends with a specified string.</summary>
        [JsonPropertyName("hostSuffix")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string HostSuffix { get; set; }

        /// <summary>Matches if the URL without query segment and fragment identifier matches a specified regular expression. Port numbers are stripped from the URL if they match the default port number. The regular expressions use the <see href="https://github.com/google/re2/blob/master/doc/syntax.txt">RE2 syntax</see>.</summary>
        [JsonPropertyName("originAndPathMatches")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string OriginAndPathMatches { get; set; }

        /// <summary>Matches if the path segment of the URL contains a specified string.</summary>
        [JsonPropertyName("pathContains")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string PathContains { get; set; }

        /// <summary>Matches if the path segment of the URL is equal to a specified string.</summary>
        [JsonPropertyName("pathEquals")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string PathEquals { get; set; }

        /// <summary>Matches if the path segment of the URL starts with a specified string.</summary>
        [JsonPropertyName("pathPrefix")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string PathPrefix { get; set; }

        /// <summary>Matches if the path segment of the URL ends with a specified string.</summary>
        [JsonPropertyName("pathSuffix")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string PathSuffix { get; set; }

        /// <summary>Matches if the port of the URL is contained in any of the specified port lists. For example <c>[80, 443, [1000, 1200]]</c> matches all requests on port 80, 443 and in the range 1000-1200.</summary>
        [JsonPropertyName("ports")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<Port> Ports { get; set; }

        /// <summary>Matches if the query segment of the URL contains a specified string.</summary>
        [JsonPropertyName("queryContains")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string QueryContains { get; set; }

        /// <summary>Matches if the query segment of the URL is equal to a specified string.</summary>
        [JsonPropertyName("queryEquals")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string QueryEquals { get; set; }

        /// <summary>Matches if the query segment of the URL starts with a specified string.</summary>
        [JsonPropertyName("queryPrefix")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string QueryPrefix { get; set; }

        /// <summary>Matches if the query segment of the URL ends with a specified string.</summary>
        [JsonPropertyName("querySuffix")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string QuerySuffix { get; set; }

        /// <summary>Matches if the scheme of the URL is equal to any of the schemes specified in the array.</summary>
        [JsonPropertyName("schemes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> Schemes { get; set; }

        /// <summary>Matches if the URL (without fragment identifier) contains a specified string. Port numbers are stripped from the URL if they match the default port number.</summary>
        [JsonPropertyName("urlContains")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string UrlContains { get; set; }

        /// <summary>Matches if the URL (without fragment identifier) is equal to a specified string. Port numbers are stripped from the URL if they match the default port number.</summary>
        [JsonPropertyName("urlEquals")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string UrlEquals { get; set; }

        /// <summary>Matches if the URL (without fragment identifier) matches a specified regular expression. Port numbers are stripped from the URL if they match the default port number. The regular expressions use the <see href="https://github.com/google/re2/blob/master/doc/syntax.txt">RE2 syntax</see>.</summary>
        [JsonPropertyName("urlMatches")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string UrlMatches { get; set; }

        /// <summary>Matches if the URL (without fragment identifier) starts with a specified string. Port numbers are stripped from the URL if they match the default port number.</summary>
        [JsonPropertyName("urlPrefix")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string UrlPrefix { get; set; }

        /// <summary>Matches if the URL (without fragment identifier) ends with a specified string. Port numbers are stripped from the URL if they match the default port number.</summary>
        [JsonPropertyName("urlSuffix")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string UrlSuffix { get; set; }
    }
}
