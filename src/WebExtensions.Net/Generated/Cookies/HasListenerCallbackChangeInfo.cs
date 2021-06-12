using System.Text.Json.Serialization;

namespace WebExtensions.Net.Cookies
{
    // Type Class
    /// <summary></summary>
    public partial class HasListenerCallbackChangeInfo : BaseObject
    {
        private OnChangedCause _cause;
        private Cookie _cookie;
        private bool _removed;

        /// <summary>The underlying reason behind the cookie's change.</summary>
        [JsonPropertyName("cause")]
        public OnChangedCause Cause
        {
            get
            {
                InitializeProperty("cause", _cause);
                return _cause;
            }
            set
            {
                _cause = value;
            }
        }

        /// <summary>Information about the cookie that was set or removed.</summary>
        [JsonPropertyName("cookie")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Cookie Cookie
        {
            get
            {
                InitializeProperty("cookie", _cookie);
                return _cookie;
            }
            set
            {
                _cookie = value;
            }
        }

        /// <summary>True if a cookie was removed.</summary>
        [JsonPropertyName("removed")]
        public bool Removed
        {
            get
            {
                InitializeProperty("removed", _removed);
                return _removed;
            }
            set
            {
                _removed = value;
            }
        }
    }
}
