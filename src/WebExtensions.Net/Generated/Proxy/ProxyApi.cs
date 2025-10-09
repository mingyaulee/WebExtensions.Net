using JsBind.Net;
using WebExtensions.Net.Types;

namespace WebExtensions.Net.Proxy
{
    /// <inheritdoc />
    /// <param name="jsRuntime">The JS runtime adapter.</param>
    /// <param name="accessPath">The base API access path.</param>
    public partial class ProxyApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "proxy")), IProxyApi
    {
        private OnErrorEvent _onError;
        private OnRequestEvent _onRequest;

        /// <inheritdoc />
        public OnErrorEvent OnError
        {
            get
            {
                if (_onError is null)
                {
                    _onError = new OnErrorEvent();
                    _onError.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onError"));
                }
                return _onError;
            }
        }

        /// <inheritdoc />
        public OnRequestEvent OnRequest
        {
            get
            {
                if (_onRequest is null)
                {
                    _onRequest = new OnRequestEvent();
                    _onRequest.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onRequest"));
                }
                return _onRequest;
            }
        }

        /// <inheritdoc />
        public Setting Settings => GetProperty<Setting>("settings");
    }
}
