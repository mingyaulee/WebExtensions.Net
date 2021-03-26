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
    public class UrlFilter : BaseObject
    {
        
        // Property Definition
        private string _hostContains;
        /// <summary>
        /// Matches if the host name of the URL contains a specified string. To test whether a host name component has a prefix 'foo', use hostContains: '.foo'. This matches 'www.foobar.com' and 'foo.com', because an implicit dot is added at the beginning of the host name. Similarly, hostContains can be used to match against component suffix ('foo.') and to exactly match against components ('.foo.'). Suffix- and exact-matching for the last components need to be done separately using hostSuffix, because no implicit dot is added at the end of the host name.
        /// </summary>
        [JsonPropertyName("hostContains")]
        public string HostContains
        {
            get
            {
                InitializeProperty("hostContains", _hostContains);
                return _hostContains;
            }
            set
            {
                _hostContains = value;
            }
        }
        
        // Property Definition
        private string _hostEquals;
        /// <summary>
        /// Matches if the host name of the URL is equal to a specified string.
        /// </summary>
        [JsonPropertyName("hostEquals")]
        public string HostEquals
        {
            get
            {
                InitializeProperty("hostEquals", _hostEquals);
                return _hostEquals;
            }
            set
            {
                _hostEquals = value;
            }
        }
        
        // Property Definition
        private string _hostPrefix;
        /// <summary>
        /// Matches if the host name of the URL starts with a specified string.
        /// </summary>
        [JsonPropertyName("hostPrefix")]
        public string HostPrefix
        {
            get
            {
                InitializeProperty("hostPrefix", _hostPrefix);
                return _hostPrefix;
            }
            set
            {
                _hostPrefix = value;
            }
        }
        
        // Property Definition
        private string _hostSuffix;
        /// <summary>
        /// Matches if the host name of the URL ends with a specified string.
        /// </summary>
        [JsonPropertyName("hostSuffix")]
        public string HostSuffix
        {
            get
            {
                InitializeProperty("hostSuffix", _hostSuffix);
                return _hostSuffix;
            }
            set
            {
                _hostSuffix = value;
            }
        }
        
        // Property Definition
        private string _pathContains;
        /// <summary>
        /// Matches if the path segment of the URL contains a specified string.
        /// </summary>
        [JsonPropertyName("pathContains")]
        public string PathContains
        {
            get
            {
                InitializeProperty("pathContains", _pathContains);
                return _pathContains;
            }
            set
            {
                _pathContains = value;
            }
        }
        
        // Property Definition
        private string _pathEquals;
        /// <summary>
        /// Matches if the path segment of the URL is equal to a specified string.
        /// </summary>
        [JsonPropertyName("pathEquals")]
        public string PathEquals
        {
            get
            {
                InitializeProperty("pathEquals", _pathEquals);
                return _pathEquals;
            }
            set
            {
                _pathEquals = value;
            }
        }
        
        // Property Definition
        private string _pathPrefix;
        /// <summary>
        /// Matches if the path segment of the URL starts with a specified string.
        /// </summary>
        [JsonPropertyName("pathPrefix")]
        public string PathPrefix
        {
            get
            {
                InitializeProperty("pathPrefix", _pathPrefix);
                return _pathPrefix;
            }
            set
            {
                _pathPrefix = value;
            }
        }
        
        // Property Definition
        private string _pathSuffix;
        /// <summary>
        /// Matches if the path segment of the URL ends with a specified string.
        /// </summary>
        [JsonPropertyName("pathSuffix")]
        public string PathSuffix
        {
            get
            {
                InitializeProperty("pathSuffix", _pathSuffix);
                return _pathSuffix;
            }
            set
            {
                _pathSuffix = value;
            }
        }
        
        // Property Definition
        private string _queryContains;
        /// <summary>
        /// Matches if the query segment of the URL contains a specified string.
        /// </summary>
        [JsonPropertyName("queryContains")]
        public string QueryContains
        {
            get
            {
                InitializeProperty("queryContains", _queryContains);
                return _queryContains;
            }
            set
            {
                _queryContains = value;
            }
        }
        
        // Property Definition
        private string _queryEquals;
        /// <summary>
        /// Matches if the query segment of the URL is equal to a specified string.
        /// </summary>
        [JsonPropertyName("queryEquals")]
        public string QueryEquals
        {
            get
            {
                InitializeProperty("queryEquals", _queryEquals);
                return _queryEquals;
            }
            set
            {
                _queryEquals = value;
            }
        }
        
        // Property Definition
        private string _queryPrefix;
        /// <summary>
        /// Matches if the query segment of the URL starts with a specified string.
        /// </summary>
        [JsonPropertyName("queryPrefix")]
        public string QueryPrefix
        {
            get
            {
                InitializeProperty("queryPrefix", _queryPrefix);
                return _queryPrefix;
            }
            set
            {
                _queryPrefix = value;
            }
        }
        
        // Property Definition
        private string _querySuffix;
        /// <summary>
        /// Matches if the query segment of the URL ends with a specified string.
        /// </summary>
        [JsonPropertyName("querySuffix")]
        public string QuerySuffix
        {
            get
            {
                InitializeProperty("querySuffix", _querySuffix);
                return _querySuffix;
            }
            set
            {
                _querySuffix = value;
            }
        }
        
        // Property Definition
        private string _urlContains;
        /// <summary>
        /// Matches if the URL (without fragment identifier) contains a specified string. Port numbers are stripped from the URL if they match the default port number.
        /// </summary>
        [JsonPropertyName("urlContains")]
        public string UrlContains
        {
            get
            {
                InitializeProperty("urlContains", _urlContains);
                return _urlContains;
            }
            set
            {
                _urlContains = value;
            }
        }
        
        // Property Definition
        private string _urlEquals;
        /// <summary>
        /// Matches if the URL (without fragment identifier) is equal to a specified string. Port numbers are stripped from the URL if they match the default port number.
        /// </summary>
        [JsonPropertyName("urlEquals")]
        public string UrlEquals
        {
            get
            {
                InitializeProperty("urlEquals", _urlEquals);
                return _urlEquals;
            }
            set
            {
                _urlEquals = value;
            }
        }
        
        // Property Definition
        private string _urlMatches;
        /// <summary>
        /// Matches if the URL (without fragment identifier) matches a specified regular expression. Port numbers are stripped from the URL if they match the default port number. The regular expressions use the <a href="https://github.com/google/re2/blob/master/doc/syntax.txt">RE2 syntax</a>.
        /// </summary>
        [JsonPropertyName("urlMatches")]
        public string UrlMatches
        {
            get
            {
                InitializeProperty("urlMatches", _urlMatches);
                return _urlMatches;
            }
            set
            {
                _urlMatches = value;
            }
        }
        
        // Property Definition
        private string _originAndPathMatches;
        /// <summary>
        /// Matches if the URL without query segment and fragment identifier matches a specified regular expression. Port numbers are stripped from the URL if they match the default port number. The regular expressions use the <a href="https://github.com/google/re2/blob/master/doc/syntax.txt">RE2 syntax</a>.
        /// </summary>
        [JsonPropertyName("originAndPathMatches")]
        public string OriginAndPathMatches
        {
            get
            {
                InitializeProperty("originAndPathMatches", _originAndPathMatches);
                return _originAndPathMatches;
            }
            set
            {
                _originAndPathMatches = value;
            }
        }
        
        // Property Definition
        private string _urlPrefix;
        /// <summary>
        /// Matches if the URL (without fragment identifier) starts with a specified string. Port numbers are stripped from the URL if they match the default port number.
        /// </summary>
        [JsonPropertyName("urlPrefix")]
        public string UrlPrefix
        {
            get
            {
                InitializeProperty("urlPrefix", _urlPrefix);
                return _urlPrefix;
            }
            set
            {
                _urlPrefix = value;
            }
        }
        
        // Property Definition
        private string _urlSuffix;
        /// <summary>
        /// Matches if the URL (without fragment identifier) ends with a specified string. Port numbers are stripped from the URL if they match the default port number.
        /// </summary>
        [JsonPropertyName("urlSuffix")]
        public string UrlSuffix
        {
            get
            {
                InitializeProperty("urlSuffix", _urlSuffix);
                return _urlSuffix;
            }
            set
            {
                _urlSuffix = value;
            }
        }
        
        // Property Definition
        private IEnumerable<string> _schemes;
        /// <summary>
        /// Matches if the scheme of the URL is equal to any of the schemes specified in the array.
        /// </summary>
        [JsonPropertyName("schemes")]
        public IEnumerable<string> Schemes
        {
            get
            {
                InitializeProperty("schemes", _schemes);
                return _schemes;
            }
            set
            {
                _schemes = value;
            }
        }
        
        // Property Definition
        private IEnumerable<object> _ports;
        /// <summary>
        /// Matches if the port of the URL is contained in any of the specified port lists. For example <c>[80, 443, [1000, 1200]]</c> matches all requests on port 80, 443 and in the range 1000-1200.
        /// </summary>
        [JsonPropertyName("ports")]
        public IEnumerable<object> Ports
        {
            get
            {
                InitializeProperty("ports", _ports);
                return _ports;
            }
            set
            {
                _ports = value;
            }
        }
    }
}

