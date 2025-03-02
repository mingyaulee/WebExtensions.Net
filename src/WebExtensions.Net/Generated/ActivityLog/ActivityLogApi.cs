using JsBind.Net;

namespace WebExtensions.Net.ActivityLog
{
    /// <inheritdoc />
    public partial class ActivityLogApi : BaseApi, IActivityLogApi
    {
        private OnExtensionActivityEvent _onExtensionActivity;

        /// <summary>Creates a new instance of <see cref="ActivityLogApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public ActivityLogApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "activityLog"))
        {
        }

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
}
