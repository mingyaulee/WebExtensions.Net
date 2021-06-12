using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.TopSites
{
    // Type Class
    /// <summary></summary>
    public partial class Options : BaseObject
    {
        private bool? _includeBlocked;
        private bool? _includeFavicon;
        private bool? _includePinned;
        private bool? _includeSearchShortcuts;
        private int? _limit;
        private bool? _newtab;
        private bool? _onePerDomain;
        private IEnumerable<string> _providers;

        /// <summary>Include sites that the user has blocked from appearing on the Firefox new tab.</summary>
        [JsonPropertyName("includeBlocked")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IncludeBlocked
        {
            get
            {
                InitializeProperty("includeBlocked", _includeBlocked);
                return _includeBlocked;
            }
            set
            {
                _includeBlocked = value;
            }
        }

        /// <summary>Include sites favicon if available.</summary>
        [JsonPropertyName("includeFavicon")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IncludeFavicon
        {
            get
            {
                InitializeProperty("includeFavicon", _includeFavicon);
                return _includeFavicon;
            }
            set
            {
                _includeFavicon = value;
            }
        }

        /// <summary>Include sites that the user has pinned on the Firefox new tab.</summary>
        [JsonPropertyName("includePinned")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IncludePinned
        {
            get
            {
                InitializeProperty("includePinned", _includePinned);
                return _includePinned;
            }
            set
            {
                _includePinned = value;
            }
        }

        /// <summary>Include search shortcuts appearing on the Firefox new tab.</summary>
        [JsonPropertyName("includeSearchShortcuts")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IncludeSearchShortcuts
        {
            get
            {
                InitializeProperty("includeSearchShortcuts", _includeSearchShortcuts);
                return _includeSearchShortcuts;
            }
            set
            {
                _includeSearchShortcuts = value;
            }
        }

        /// <summary>The number of top sites to return, defaults to the value used by Firefox</summary>
        [JsonPropertyName("limit")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Limit
        {
            get
            {
                InitializeProperty("limit", _limit);
                return _limit;
            }
            set
            {
                _limit = value;
            }
        }

        /// <summary>Return the sites that exactly appear on the user's new-tab page. When true, all other options are ignored except limit and includeFavicon. If the user disabled newtab Top Sites, the newtab parameter will be ignored.</summary>
        [JsonPropertyName("newtab")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Newtab
        {
            get
            {
                InitializeProperty("newtab", _newtab);
                return _newtab;
            }
            set
            {
                _newtab = value;
            }
        }

        /// <summary>Limit the result to a single top site link per domain</summary>
        [JsonPropertyName("onePerDomain")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? OnePerDomain
        {
            get
            {
                InitializeProperty("onePerDomain", _onePerDomain);
                return _onePerDomain;
            }
            set
            {
                _onePerDomain = value;
            }
        }

        /// <summary></summary>
        [Obsolete("Please use the other options to tune the results received from topSites.")]
        [JsonPropertyName("providers")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> Providers
        {
            get
            {
                InitializeProperty("providers", _providers);
                return _providers;
            }
            set
            {
                _providers = value;
            }
        }
    }
}
