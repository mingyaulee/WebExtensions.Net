using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtension.Net.WebRequest
{
    /// <inheritdoc />
    public partial class WebRequestApi : BaseApi, IWebRequestApi
    {
        private OnAuthRequiredEvent _onAuthRequired;
        private OnBeforeRedirectEvent _onBeforeRedirect;
        private OnBeforeRequestEvent _onBeforeRequest;
        private OnBeforeSendHeadersEvent _onBeforeSendHeaders;
        private OnCompletedEvent _onCompleted;
        private OnErrorOccurredEvent _onErrorOccurred;
        private OnHeadersReceivedEvent _onHeadersReceived;
        private OnResponseStartedEvent _onResponseStarted;
        private OnSendHeadersEvent _onSendHeaders;

        /// <summary>Creates a new instance of <see cref="WebRequestApi" />.</summary>
        /// <param name="webExtensionJSRuntime">Web Extension JS Runtime</param>
        public WebRequestApi(WebExtensionJSRuntime webExtensionJSRuntime) : base(webExtensionJSRuntime, "webRequest")
        {
        }

        /// <inheritdoc />
        public int MAX_HANDLER_BEHAVIOR_CHANGED_CALLS_PER_10_MINUTES => 20;

        /// <inheritdoc />
        public OnAuthRequiredEvent OnAuthRequired
        {
            get
            {
                if (_onAuthRequired is null)
                {
                    _onAuthRequired = new OnAuthRequiredEvent();
                    InitializeProperty("onAuthRequired", _onAuthRequired);
                }
                return _onAuthRequired;
            }
        }

        /// <inheritdoc />
        public OnBeforeRedirectEvent OnBeforeRedirect
        {
            get
            {
                if (_onBeforeRedirect is null)
                {
                    _onBeforeRedirect = new OnBeforeRedirectEvent();
                    InitializeProperty("onBeforeRedirect", _onBeforeRedirect);
                }
                return _onBeforeRedirect;
            }
        }

        /// <inheritdoc />
        public OnBeforeRequestEvent OnBeforeRequest
        {
            get
            {
                if (_onBeforeRequest is null)
                {
                    _onBeforeRequest = new OnBeforeRequestEvent();
                    InitializeProperty("onBeforeRequest", _onBeforeRequest);
                }
                return _onBeforeRequest;
            }
        }

        /// <inheritdoc />
        public OnBeforeSendHeadersEvent OnBeforeSendHeaders
        {
            get
            {
                if (_onBeforeSendHeaders is null)
                {
                    _onBeforeSendHeaders = new OnBeforeSendHeadersEvent();
                    InitializeProperty("onBeforeSendHeaders", _onBeforeSendHeaders);
                }
                return _onBeforeSendHeaders;
            }
        }

        /// <inheritdoc />
        public OnCompletedEvent OnCompleted
        {
            get
            {
                if (_onCompleted is null)
                {
                    _onCompleted = new OnCompletedEvent();
                    InitializeProperty("onCompleted", _onCompleted);
                }
                return _onCompleted;
            }
        }

        /// <inheritdoc />
        public OnErrorOccurredEvent OnErrorOccurred
        {
            get
            {
                if (_onErrorOccurred is null)
                {
                    _onErrorOccurred = new OnErrorOccurredEvent();
                    InitializeProperty("onErrorOccurred", _onErrorOccurred);
                }
                return _onErrorOccurred;
            }
        }

        /// <inheritdoc />
        public OnHeadersReceivedEvent OnHeadersReceived
        {
            get
            {
                if (_onHeadersReceived is null)
                {
                    _onHeadersReceived = new OnHeadersReceivedEvent();
                    InitializeProperty("onHeadersReceived", _onHeadersReceived);
                }
                return _onHeadersReceived;
            }
        }

        /// <inheritdoc />
        public OnResponseStartedEvent OnResponseStarted
        {
            get
            {
                if (_onResponseStarted is null)
                {
                    _onResponseStarted = new OnResponseStartedEvent();
                    InitializeProperty("onResponseStarted", _onResponseStarted);
                }
                return _onResponseStarted;
            }
        }

        /// <inheritdoc />
        public OnSendHeadersEvent OnSendHeaders
        {
            get
            {
                if (_onSendHeaders is null)
                {
                    _onSendHeaders = new OnSendHeadersEvent();
                    InitializeProperty("onSendHeaders", _onSendHeaders);
                }
                return _onSendHeaders;
            }
        }

        /// <inheritdoc />
        public virtual ValueTask<JsonElement> FilterResponseData(string requestId)
        {
            return InvokeAsync<JsonElement>("filterResponseData", requestId);
        }

        /// <inheritdoc />
        public virtual ValueTask GetSecurityInfo(string requestId, Options options)
        {
            return InvokeVoidAsync("getSecurityInfo", requestId, options);
        }

        /// <inheritdoc />
        public virtual ValueTask HandlerBehaviorChanged()
        {
            return InvokeVoidAsync("handlerBehaviorChanged");
        }
    }
}
