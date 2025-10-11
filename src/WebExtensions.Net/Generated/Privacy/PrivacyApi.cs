using JsBind.Net;
using WebExtensions.Net.Privacy.Network;
using WebExtensions.Net.Privacy.Services;
using WebExtensions.Net.Privacy.Websites;

namespace WebExtensions.Net.Privacy;

/// <inheritdoc />
/// <param name="jsRuntime">The JS runtime adapter.</param>
/// <param name="accessPath">The base API access path.</param>
public partial class PrivacyApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "privacy")), IPrivacyApi
{
    private INetworkApi _network;
    private IServicesApi _services;
    private IWebsitesApi _websites;

    /// <inheritdoc />
    public INetworkApi Network => _network ??= new NetworkApi(JsRuntime, AccessPath);

    /// <inheritdoc />
    public IServicesApi Services => _services ??= new ServicesApi(JsRuntime, AccessPath);

    /// <inheritdoc />
    public IWebsitesApi Websites => _websites ??= new WebsitesApi(JsRuntime, AccessPath);
}
