using JsBind.Net;
using WebExtensions.Net.Devtools.InspectedWindow;
using WebExtensions.Net.Devtools.Network;
using WebExtensions.Net.Devtools.Panels;

namespace WebExtensions.Net.Devtools;

/// <inheritdoc />
/// <param name="jsRuntime">The JS runtime adapter.</param>
/// <param name="accessPath">The base API access path.</param>
public partial class DevtoolsApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "devtools")), IDevtoolsApi
{
    private IInspectedWindowApi _inspectedWindow;
    private INetworkApi _network;
    private IPanelsApi _panels;

    /// <inheritdoc />
    public IInspectedWindowApi InspectedWindow => _inspectedWindow ??= new InspectedWindowApi(JsRuntime, AccessPath);

    /// <inheritdoc />
    public INetworkApi Network => _network ??= new NetworkApi(JsRuntime, AccessPath);

    /// <inheritdoc />
    public IPanelsApi Panels => _panels ??= new PanelsApi(JsRuntime, AccessPath);
}
