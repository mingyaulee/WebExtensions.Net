using JsBind.Net;
using WebExtensions.Net.Privacy.Network;
using WebExtensions.Net.Privacy.Services;
using WebExtensions.Net.Privacy.Websites;

namespace WebExtensions.Net.Privacy
{
    /// <inheritdoc />
    public partial class PrivacyApi : BaseApi, IPrivacyApi
    {
        private INetworkApi _network;
        private IServicesApi _services;
        private IWebsitesApi _websites;

        /// <summary>Creates a new instance of <see cref="PrivacyApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public PrivacyApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "privacy"))
        {
        }

        /// <inheritdoc />
        public INetworkApi Network => _network ??= new NetworkApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IServicesApi Services => _services ??= new ServicesApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IWebsitesApi Websites => _websites ??= new WebsitesApi(JsRuntime, AccessPath);
    }
}
