using JsBind.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebExtensions.Net.Manifest;

namespace WebExtensions.Net.Management;

/// <inheritdoc />
/// <param name="jsRuntime">The JS runtime adapter.</param>
/// <param name="accessPath">The base API access path.</param>
public partial class ManagementApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "management")), IManagementApi
{
    private OnDisabledEvent _onDisabled;
    private OnEnabledEvent _onEnabled;
    private OnInstalledEvent _onInstalled;
    private OnUninstalledEvent _onUninstalled;

    /// <inheritdoc />
    public OnDisabledEvent OnDisabled
    {
        get
        {
            if (_onDisabled is null)
            {
                _onDisabled = new OnDisabledEvent();
                _onDisabled.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onDisabled"));
            }
            return _onDisabled;
        }
    }

    /// <inheritdoc />
    public OnEnabledEvent OnEnabled
    {
        get
        {
            if (_onEnabled is null)
            {
                _onEnabled = new OnEnabledEvent();
                _onEnabled.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onEnabled"));
            }
            return _onEnabled;
        }
    }

    /// <inheritdoc />
    public OnInstalledEvent OnInstalled
    {
        get
        {
            if (_onInstalled is null)
            {
                _onInstalled = new OnInstalledEvent();
                _onInstalled.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onInstalled"));
            }
            return _onInstalled;
        }
    }

    /// <inheritdoc />
    public OnUninstalledEvent OnUninstalled
    {
        get
        {
            if (_onUninstalled is null)
            {
                _onUninstalled = new OnUninstalledEvent();
                _onUninstalled.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onUninstalled"));
            }
            return _onUninstalled;
        }
    }

    /// <inheritdoc />
    public virtual ValueTask<ExtensionInfo> Get(ExtensionID id)
        => InvokeAsync<ExtensionInfo>("get", id);

    /// <inheritdoc />
    public virtual ValueTask<IEnumerable<ExtensionInfo>> GetAll()
        => InvokeAsync<IEnumerable<ExtensionInfo>>("getAll");

    /// <inheritdoc />
    public virtual ValueTask<ExtensionInfo> GetSelf()
        => InvokeAsync<ExtensionInfo>("getSelf");

    /// <inheritdoc />
    public virtual ValueTask<Result> Install(InstallOptions options)
        => InvokeAsync<Result>("install", options);

    /// <inheritdoc />
    public virtual ValueTask SetEnabled(string id, bool enabled)
        => InvokeVoidAsync("setEnabled", id, enabled);

    /// <inheritdoc />
    public virtual ValueTask UninstallSelf(UninstallSelfOptions options = null)
        => InvokeVoidAsync("uninstallSelf", options);
}
