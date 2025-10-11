using JsBind.Net;

namespace WebExtensions.Net.Storage;

/// <inheritdoc />
/// <param name="jsRuntime">The JS runtime adapter.</param>
/// <param name="accessPath">The base API access path.</param>
public partial class StorageApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "storage")), IStorageApi
{
    private OnChangedEvent _onChanged;

    /// <inheritdoc />
    public StorageArea Local => GetProperty<StorageArea>("local");

    /// <inheritdoc />
    public StorageArea Managed => GetProperty<StorageArea>("managed");

    /// <inheritdoc />
    public OnChangedEvent OnChanged
    {
        get
        {
            if (_onChanged is null)
            {
                _onChanged = new OnChangedEvent();
                _onChanged.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onChanged"));
            }
            return _onChanged;
        }
    }

    /// <inheritdoc />
    public StorageAreaWithUsage Session => GetProperty<StorageAreaWithUsage>("session");

    /// <inheritdoc />
    public StorageAreaWithUsage Sync => GetProperty<StorageAreaWithUsage>("sync");
}
