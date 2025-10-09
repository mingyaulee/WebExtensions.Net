using JsBind.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtensions.Net.WebRequest
{
    /// <inheritdoc />
    /// <param name="jsRuntime">The JS runtime adapter.</param>
    /// <param name="accessPath">The base API access path.</param>
    public partial class WebRequestApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "webRequest")), IWebRequestApi
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
                    _onAuthRequired.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onAuthRequired"));
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
                    _onBeforeRedirect.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onBeforeRedirect"));
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
                    _onBeforeRequest.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onBeforeRequest"));
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
                    _onBeforeSendHeaders.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onBeforeSendHeaders"));
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
                    _onCompleted.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onCompleted"));
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
                    _onErrorOccurred.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onErrorOccurred"));
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
                    _onHeadersReceived.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onHeadersReceived"));
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
                    _onResponseStarted.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onResponseStarted"));
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
                    _onSendHeaders.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onSendHeaders"));
                }
                return _onSendHeaders;
            }
        }

        /// <inheritdoc />
        public virtual JsonElement FilterResponseData(string requestId)
            => Invoke<JsonElement>("filterResponseData", requestId);

        /// <inheritdoc />
        public virtual void GetSecurityInfo(string requestId, Options options = null)
            => InvokeVoid("getSecurityInfo", requestId, options);

        /// <inheritdoc />
        public virtual ValueTask HandlerBehaviorChanged()
            => InvokeVoidAsync("handlerBehaviorChanged");
    }
}
