using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebExtensions.Net.ExtensionTypes;

namespace WebExtensions.Net.BrowsingData
{
    // Type Class
    /// <summary>Options that determine exactly what data will be removed.</summary>
    public partial class RemovalOptions : BaseObject
    {
        private string _cookieStoreId;
        private IEnumerable<string> _hostnames;
        private OriginTypes _originTypes;
        private Date _since;

        /// <summary>Only remove data associated with this specific cookieStoreId.</summary>
        [JsonPropertyName("cookieStoreId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string CookieStoreId
        {
            get
            {
                InitializeProperty("cookieStoreId", _cookieStoreId);
                return _cookieStoreId;
            }
            set
            {
                _cookieStoreId = value;
            }
        }

        /// <summary>Only remove data associated with these hostnames (only applies to cookies and localStorage).</summary>
        [JsonPropertyName("hostnames")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> Hostnames
        {
            get
            {
                InitializeProperty("hostnames", _hostnames);
                return _hostnames;
            }
            set
            {
                _hostnames = value;
            }
        }

        /// <summary>An object whose properties specify which origin types ought to be cleared. If this object isn't specified, it defaults to clearing only "unprotected" origins. Please ensure that you <em>really</em> want to remove application data before adding 'protectedWeb' or 'extensions'.</summary>
        [JsonPropertyName("originTypes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public OriginTypes OriginTypes
        {
            get
            {
                InitializeProperty("originTypes", _originTypes);
                return _originTypes;
            }
            set
            {
                _originTypes = value;
            }
        }

        /// <summary>Remove data accumulated on or after this date, represented in milliseconds since the epoch (accessible via the <c>getTime</c> method of the JavaScript <c>Date</c> object). If absent, defaults to 0 (which would remove all browsing data).</summary>
        [JsonPropertyName("since")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Date Since
        {
            get
            {
                InitializeProperty("since", _since);
                return _since;
            }
            set
            {
                _since = value;
            }
        }
    }
}
