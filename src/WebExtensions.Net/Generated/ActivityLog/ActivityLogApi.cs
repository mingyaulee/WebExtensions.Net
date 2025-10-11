using JsBind.Net;

namespace WebExtensions.Net.ActivityLog;

/// <inheritdoc />
/// <param name="jsRuntime">The JS runtime adapter.</param>
/// <param name="accessPath">The base API access path.</param>
public partial class ActivityLogApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "activityLog")), IActivityLogApi
{
    private OnExtensionActivityEvent _onExtensionActivity;

    /// <inheritdoc />
    public OnExtensionActivityEvent OnExtensionActivity
    {
        get
        {
            if (_onExtensionActivity is null)
            {
                _onExtensionActivity = new OnExtensionActivityEvent();
                _onExtensionActivity.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onExtensionActivity"));
            }
            return _onExtensionActivity;
        }
    }
}
