using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebExtensions.Net.ExtensionTypes;

namespace WebExtensions.Net.BrowsingData
{
    // Type Class
    /// <summary>Options that determine exactly what data will be removed.</summary>
    [BindAllProperties]
    public partial class RemovalOptions : BaseObject
    {
        /// <summary>Only remove data associated with this specific cookieStoreId.</summary>
        [JsAccessPath("cookieStoreId")]
        [JsonPropertyName("cookieStoreId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string CookieStoreId { get; set; }

        /// <summary>Only remove data associated with these hostnames (only applies to cookies and localStorage).</summary>
        [JsAccessPath("hostnames")]
        [JsonPropertyName("hostnames")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> Hostnames { get; set; }

        /// <summary>An object whose properties specify which origin types ought to be cleared. If this object isn't specified, it defaults to clearing only "unprotected" origins. Please ensure that you <em>really</em> want to remove application data before adding 'protectedWeb' or 'extensions'.</summary>
        [JsAccessPath("originTypes")]
        [JsonPropertyName("originTypes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public OriginTypes OriginTypes { get; set; }

        /// <summary>Remove data accumulated on or after this date, represented in milliseconds since the epoch (accessible via the <c>getTime</c> method of the JavaScript <c>Date</c> object). If absent, defaults to 0 (which would remove all browsing data).</summary>
        [JsAccessPath("since")]
        [JsonPropertyName("since")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Date Since { get; set; }
    }
}
