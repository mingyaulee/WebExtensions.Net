using JsBind.Net;
using WebExtensions.Net.Types;

namespace WebExtensions.Net.Privacy.Network
{
    /// <inheritdoc />
    /// <param name="jsRuntime">The JS runtime adapter.</param>
    /// <param name="accessPath">The base API access path.</param>
    public partial class NetworkApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "network")), INetworkApi
    {
        /// <inheritdoc />
        public Setting GlobalPrivacyControl => GetProperty<Setting>("globalPrivacyControl");

        /// <inheritdoc />
        public Setting HttpsOnlyMode => GetProperty<Setting>("httpsOnlyMode");

        /// <inheritdoc />
        public Setting NetworkPredictionEnabled => GetProperty<Setting>("networkPredictionEnabled");

        /// <inheritdoc />
        public Setting PeerConnectionEnabled => GetProperty<Setting>("peerConnectionEnabled");

        /// <inheritdoc />
        public Setting TlsVersionRestriction => GetProperty<Setting>("tlsVersionRestriction");

        /// <inheritdoc />
        public Setting WebRTCIPHandlingPolicy => GetProperty<Setting>("webRTCIPHandlingPolicy");
    }
}
