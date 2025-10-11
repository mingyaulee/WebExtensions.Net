using JsBind.Net;
using WebExtensions.Net.Manifest;

namespace WebExtensions.Net.Theme;

/// <inheritdoc />
/// <param name="jsRuntime">The JS runtime adapter.</param>
/// <param name="accessPath">The base API access path.</param>
public partial class ThemeApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "theme")), IThemeApi
{
    private OnUpdatedEvent _onUpdated;

    /// <inheritdoc />
    public OnUpdatedEvent OnUpdated
    {
        get
        {
            if (_onUpdated is null)
            {
                _onUpdated = new OnUpdatedEvent();
                _onUpdated.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onUpdated"));
            }
            return _onUpdated;
        }
    }

    /// <inheritdoc />
    public virtual void GetCurrent(int? windowId = null)
        => InvokeVoid("getCurrent", windowId);

    /// <inheritdoc />
    public virtual void Reset(int? windowId = null)
        => InvokeVoid("reset", windowId);

    /// <inheritdoc />
    public virtual void Update(ThemeType details)
        => InvokeVoid("update", details);

    /// <inheritdoc />
    public virtual void Update(int? windowId, ThemeType details)
        => InvokeVoid("update", windowId, details);
}
