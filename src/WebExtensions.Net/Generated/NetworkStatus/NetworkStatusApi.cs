using JsBind.Net;

namespace WebExtensions.Net.NetworkStatus
{
    /// <inheritdoc />
    public partial class NetworkStatusApi : BaseApi, INetworkStatusApi
    {
        private OnConnectionChangedEvent _onConnectionChanged;

        /// <summary>Creates a new instance of <see cref="NetworkStatusApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public NetworkStatusApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "networkStatus"))
        {
        }

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
