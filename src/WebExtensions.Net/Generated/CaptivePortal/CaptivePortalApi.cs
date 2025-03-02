using JsBind.Net;
using WebExtensions.Net.Types;

namespace WebExtensions.Net.CaptivePortal
{
    /// <inheritdoc />
    public partial class CaptivePortalApi : BaseApi, ICaptivePortalApi
    {
        private OnConnectivityAvailableEvent _onConnectivityAvailable;
        private OnStateChangedEvent _onStateChanged;

        /// <summary>Creates a new instance of <see cref="CaptivePortalApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public CaptivePortalApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "captivePortal"))
        {
        }

        /// <inheritdoc />
        public Setting CanonicalURL => GetProperty<Setting>("canonicalURL");

        /// <inheritdoc />
        public OnConnectivityAvailableEvent OnConnectivityAvailable
        {
            get
            {
                if (_onConnectivityAvailable is null)
                {
                    _onConnectivityAvailable = new OnConnectivityAvailableEvent();
                    _onConnectivityAvailable.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onConnectivityAvailable"));
                }
                return _onConnectivityAvailable;
            }
        }

        /// <inheritdoc />
        public OnStateChangedEvent OnStateChanged
        {
            get
            {
                if (_onStateChanged is null)
                {
                    _onStateChanged = new OnStateChangedEvent();
                    _onStateChanged.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onStateChanged"));
                }
                return _onStateChanged;
            }
        }

        /// <inheritdoc />
        public virtual void GetLastChecked()
            => InvokeVoid("getLastChecked");

        /// <inheritdoc />
        public virtual void GetState()
            => InvokeVoid("getState");
    }
}
