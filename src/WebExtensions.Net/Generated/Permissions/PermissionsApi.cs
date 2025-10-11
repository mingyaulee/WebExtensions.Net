using JsBind.Net;
using System.Threading.Tasks;

namespace WebExtensions.Net.Permissions;

/// <inheritdoc />
/// <param name="jsRuntime">The JS runtime adapter.</param>
/// <param name="accessPath">The base API access path.</param>
public partial class PermissionsApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "permissions")), IPermissionsApi
{
    private OnAddedEvent _onAdded;
    private OnRemovedEvent _onRemoved;

    /// <inheritdoc />
    public OnAddedEvent OnAdded
    {
        get
        {
            if (_onAdded is null)
            {
                _onAdded = new OnAddedEvent();
                _onAdded.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onAdded"));
            }
            return _onAdded;
        }
    }

    /// <inheritdoc />
    public OnRemovedEvent OnRemoved
    {
        get
        {
            if (_onRemoved is null)
            {
                _onRemoved = new OnRemovedEvent();
                _onRemoved.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onRemoved"));
            }
            return _onRemoved;
        }
    }

    /// <inheritdoc />
    public virtual ValueTask<bool> Contains(AnyPermissions permissions)
        => InvokeAsync<bool>("contains", permissions);

    /// <inheritdoc />
    public virtual ValueTask<AnyPermissions> GetAll()
        => InvokeAsync<AnyPermissions>("getAll");

    /// <inheritdoc />
    public virtual ValueTask Remove(PermissionsType permissions)
        => InvokeVoidAsync("remove", permissions);

    /// <inheritdoc />
    public virtual ValueTask<bool> Request(PermissionsType permissions)
        => InvokeAsync<bool>("request", permissions);
}
