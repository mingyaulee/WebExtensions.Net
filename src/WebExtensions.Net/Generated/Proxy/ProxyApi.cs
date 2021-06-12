using System.Threading.Tasks;
using WebExtensions.Net.Types;

namespace WebExtensions.Net.Proxy
{
    /// <inheritdoc />
    public partial class ProxyApi : BaseApi, IProxyApi
    {
        private OnErrorEvent _onError;
        private OnRequestEvent _onRequest;

        /// <summary>Creates a new instance of <see cref="ProxyApi" />.</summary>
        /// <param name="webExtensionsJSRuntime">Web Extension JS Runtime</param>
        public ProxyApi(IWebExtensionsJSRuntime webExtensionsJSRuntime) : base(webExtensionsJSRuntime, "proxy")
        {
        }

        /// <inheritdoc />
        public OnErrorEvent OnError
        {
            get
            {
                if (_onError is null)
                {
                    _onError = new OnErrorEvent();
                    InitializeProperty("onError", _onError);
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
                    InitializeProperty("onRequest", _onRequest);
                }
                return _onRequest;
            }
        }

        /// <inheritdoc />
        public virtual ValueTask<Setting> GetSettings()
        {
            return GetPropertyAsync<Setting>("settings");
        }
    }
}
