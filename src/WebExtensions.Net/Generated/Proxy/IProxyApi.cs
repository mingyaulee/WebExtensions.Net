using JsBind.Net;
using WebExtensions.Net.Types;

namespace WebExtensions.Net.Proxy
{
    /// <summary>Provides access to global proxy settings for Firefox and proxy event listeners to handle dynamic proxy implementations.</summary>
    [JsAccessPath("proxy")]
    public partial interface IProxyApi
    {
        /// <summary>Notifies about errors caused by the invalid use of the proxy API.</summary>
        [JsAccessPath("onError")]
        OnErrorEvent OnError { get; }

        /// <summary>Fired when proxy data is needed for a request.</summary>
        [JsAccessPath("onRequest")]
        OnRequestEvent OnRequest { get; }

        /// <summary>Configures proxy settings. This setting's value is an object of type ProxyConfig.</summary>
        [JsAccessPath("settings")]
        Setting Settings { get; }
    }
}
