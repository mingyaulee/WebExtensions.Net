using JsBind.Net;

namespace WebExtensions.Net.NetworkStatus
{
    /// <inheritdoc />
    /// <param name="jsRuntime">The JS runtime adapter.</param>
    /// <param name="accessPath">The base API access path.</param>
    public partial class NetworkStatusApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "networkStatus")), INetworkStatusApi
    {
        private OnConnectionChangedEvent _onConnectionChanged;

        /// <inheritdoc />
        public OnConnectionChangedEvent OnConnectionChanged
        {
            get
            {
                if (_onConnectionChanged is null)
                {
                    _onConnectionChanged = new OnConnectionChangedEvent();
                    _onConnectionChanged.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onConnectionChanged"));
                }
                return _onConnectionChanged;
            }
        }

        /// <inheritdoc />
        public virtual void GetLinkInfo()
            => InvokeVoid("getLinkInfo");
    }
}
