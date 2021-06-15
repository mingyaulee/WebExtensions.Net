using System.Threading.Tasks;
using WebExtensions.Net.Types;

namespace WebExtensions.Net.Privacy.Network
{
    /// <inheritdoc />
    public partial class NetworkApi : BaseApi, INetworkApi
    {
        /// <summary>Creates a new instance of <see cref="NetworkApi" />.</summary>
        /// <param name="webExtensionsJSRuntime">Web Extension JS Runtime</param>
        public NetworkApi(IWebExtensionsJSRuntime webExtensionsJSRuntime) : base(webExtensionsJSRuntime, "privacy.network")
        {
        }

        /// <inheritdoc />
        public virtual ValueTask<Setting> GetHttpsOnlyMode()
        {
            return GetPropertyAsync<Setting>("httpsOnlyMode");
        }

        /// <inheritdoc />
        public virtual ValueTask<Setting> GetNetworkPredictionEnabled()
        {
            return GetPropertyAsync<Setting>("networkPredictionEnabled");
        }

        /// <inheritdoc />
        public virtual ValueTask<Setting> GetPeerConnectionEnabled()
        {
            return GetPropertyAsync<Setting>("peerConnectionEnabled");
        }

        /// <inheritdoc />
        public virtual ValueTask<Setting> GetTlsVersionRestriction()
        {
            return GetPropertyAsync<Setting>("tlsVersionRestriction");
        }

        /// <inheritdoc />
        public virtual ValueTask<Setting> GetWebRTCIPHandlingPolicy()
        {
            return GetPropertyAsync<Setting>("webRTCIPHandlingPolicy");
        }
    }
}
