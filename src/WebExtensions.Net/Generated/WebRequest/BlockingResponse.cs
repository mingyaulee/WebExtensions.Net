using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebRequest
{
    // Type Class
    /// <summary>Returns value for event handlers that have the 'blocking' extraInfoSpec applied. Allows the event handler to modify network requests.</summary>
    public partial class BlockingResponse : BaseObject
    {
        private AuthCredentials _authCredentials;
        private bool? _cancel;
        private string _redirectUrl;
        private HttpHeaders _requestHeaders;
        private HttpHeaders _responseHeaders;
        private bool? _upgradeToSecure;

        /// <summary>Only used as a response to the onAuthRequired event. If set, the request is made using the supplied credentials.</summary>
        [JsonPropertyName("authCredentials")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AuthCredentials AuthCredentials
        {
            get
            {
                InitializeProperty("authCredentials", _authCredentials);
                return _authCredentials;
            }
            set
            {
                _authCredentials = value;
            }
        }

        /// <summary>If true, the request is cancelled. Used in onBeforeRequest, this prevents the request from being sent.</summary>
        [JsonPropertyName("cancel")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Cancel
        {
            get
            {
                InitializeProperty("cancel", _cancel);
                return _cancel;
            }
            set
            {
                _cancel = value;
            }
        }

        /// <summary>Only used as a response to the onBeforeRequest and onHeadersReceived events. If set, the original request is prevented from being sent/completed and is instead redirected to the given URL. Redirections to non-HTTP schemes such as data: are allowed. Redirects initiated by a redirect action use the original request method for the redirect, with one exception: If the redirect is initiated at the onHeadersReceived stage, then the redirect will be issued using the GET method.</summary>
        [JsonPropertyName("redirectUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string RedirectUrl
        {
            get
            {
                InitializeProperty("redirectUrl", _redirectUrl);
                return _redirectUrl;
            }
            set
            {
                _redirectUrl = value;
            }
        }

        /// <summary>Only used as a response to the onBeforeSendHeaders event. If set, the request is made with these request headers instead.</summary>
        [JsonPropertyName("requestHeaders")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public HttpHeaders RequestHeaders
        {
            get
            {
                InitializeProperty("requestHeaders", _requestHeaders);
                return _requestHeaders;
            }
            set
            {
                _requestHeaders = value;
            }
        }

        /// <summary>Only used as a response to the onHeadersReceived event. If set, the server is assumed to have responded with these response headers instead. Only return <c>responseHeaders</c> if you really want to modify the headers in order to limit the number of conflicts (only one extension may modify <c>responseHeaders</c> for each request).</summary>
        [JsonPropertyName("responseHeaders")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public HttpHeaders ResponseHeaders
        {
            get
            {
                InitializeProperty("responseHeaders", _responseHeaders);
                return _responseHeaders;
            }
            set
            {
                _responseHeaders = value;
            }
        }

        /// <summary>Only used as a response to the onBeforeRequest event. If set, the original request is prevented from being sent/completed and is instead upgraded to a secure request.  If any extension returns <c>redirectUrl</c> during onBeforeRequest, <c>upgradeToSecure</c> will have no affect.</summary>
        [JsonPropertyName("upgradeToSecure")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? UpgradeToSecure
        {
            get
            {
                InitializeProperty("upgradeToSecure", _upgradeToSecure);
                return _upgradeToSecure;
            }
            set
            {
                _upgradeToSecure = value;
            }
        }
    }
}
