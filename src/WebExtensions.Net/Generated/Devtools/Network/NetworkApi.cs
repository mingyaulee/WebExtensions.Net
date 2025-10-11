using JsBind.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtensions.Net.Devtools.Network;

/// <inheritdoc />
/// <param name="jsRuntime">The JS runtime adapter.</param>
/// <param name="accessPath">The base API access path.</param>
public partial class NetworkApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "network")), INetworkApi
{
    private OnNavigatedEvent _onNavigated;
    private OnRequestFinishedEvent _onRequestFinished;

    /// <inheritdoc />
    public OnNavigatedEvent OnNavigated
    {
        get
        {
            if (_onNavigated is null)
            {
                _onNavigated = new OnNavigatedEvent();
                _onNavigated.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onNavigated"));
            }
            return _onNavigated;
        }
    }

    /// <inheritdoc />
    public OnRequestFinishedEvent OnRequestFinished
    {
        get
        {
            if (_onRequestFinished is null)
            {
                _onRequestFinished = new OnRequestFinishedEvent();
                _onRequestFinished.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onRequestFinished"));
            }
            return _onRequestFinished;
        }
    }

    /// <inheritdoc />
    public virtual ValueTask<JsonElement> GetHAR()
        => InvokeAsync<JsonElement>("getHAR");
}
