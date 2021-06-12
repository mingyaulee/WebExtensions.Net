using System.Threading.Tasks;
using WebExtensions.Net.Types;

namespace WebExtensions.Net.Proxy
{
    /// <summary>Provides access to global proxy settings for Firefox and proxy event listeners to handle dynamic proxy implementations.</summary>
    public partial interface IProxyApi
    {
        /// <summary>Notifies about errors caused by the invalid use of the proxy API.</summary>
        OnErrorEvent OnError { get; }

        /// <summary>Fired when proxy data is needed for a request.</summary>
        OnRequestEvent OnRequest { get; }

        /// <summary>Gets the 'settings' property.</summary>
        /// <returns>Configures proxy settings. This setting's value is an object of type ProxyConfig.</returns>
        ValueTask<Setting> GetSettings();
    }
}
