using JsBind.Net;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.TopSites
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class Options : BaseObject
    {
        /// <summary>Include sites that the user has blocked from appearing on the Firefox new tab.</summary>
        [JsAccessPath("includeBlocked")]
        [JsonPropertyName("includeBlocked")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IncludeBlocked { get; set; }

        /// <summary>Include sites favicon if available.</summary>
        [JsAccessPath("includeFavicon")]
        [JsonPropertyName("includeFavicon")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IncludeFavicon { get; set; }

        /// <summary>Include sites that the user has pinned on the Firefox new tab.</summary>
        [JsAccessPath("includePinned")]
        [JsonPropertyName("includePinned")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IncludePinned { get; set; }

        /// <summary>Include search shortcuts appearing on the Firefox new tab.</summary>
        [JsAccessPath("includeSearchShortcuts")]
        [JsonPropertyName("includeSearchShortcuts")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IncludeSearchShortcuts { get; set; }

        /// <summary>The number of top sites to return, defaults to the value used by Firefox</summary>
        [JsAccessPath("limit")]
        [JsonPropertyName("limit")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Limit { get; set; }

        /// <summary>Return the sites that exactly appear on the user's new-tab page. When true, all other options are ignored except limit and includeFavicon. If the user disabled newtab Top Sites, the newtab parameter will be ignored.</summary>
        [JsAccessPath("newtab")]
        [JsonPropertyName("newtab")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Newtab { get; set; }

        /// <summary>Limit the result to a single top site link per domain</summary>
        [JsAccessPath("onePerDomain")]
        [JsonPropertyName("onePerDomain")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? OnePerDomain { get; set; }

        /// <summary></summary>
        [Obsolete("Please use the other options to tune the results received from topSites.")]
        [JsAccessPath("providers")]
        [JsonPropertyName("providers")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> Providers { get; set; }
    }
}
