using System.Threading.Tasks;
using WebExtensions.Net.Types;

namespace WebExtensions.Net.Privacy.Network
{
    /// <summary>Use the <c>browser.privacy</c> API to control usage of the features in the browser that can affect a user's privacy.</summary>
    public partial interface INetworkApi
    {
        /// <summary>Gets the 'globalPrivacyControl' property.</summary>
        /// <returns>Allow users to query the status of 'Global Privacy Control'. This setting's value is of type boolean, defaulting to <c>false</c>.</returns>
        ValueTask<Setting> GetGlobalPrivacyControl();

        /// <summary>Gets the 'httpsOnlyMode' property.</summary>
        /// <returns>Allow users to query the mode for 'HTTPS-Only Mode'. This setting's value is of type HTTPSOnlyModeOption, defaulting to <c>never</c>.</returns>
        ValueTask<Setting> GetHttpsOnlyMode();

        /// <summary>Gets the 'networkPredictionEnabled' property.</summary>
        /// <returns>If enabled, the browser attempts to speed up your web browsing experience by pre-resolving DNS entries, prerendering sites (<c>&amp;lt;link rel='prefetch' ...&amp;gt;</c>), and preemptively opening TCP and SSL connections to servers.  This preference's value is a boolean, defaulting to <c>true</c>.</returns>
        ValueTask<Setting> GetNetworkPredictionEnabled();

        /// <summary>Gets the 'peerConnectionEnabled' property.</summary>
        /// <returns>Allow users to enable and disable RTCPeerConnections (aka WebRTC).</returns>
        ValueTask<Setting> GetPeerConnectionEnabled();

        /// <summary>Gets the 'tlsVersionRestriction' property.</summary>
        /// <returns>This property controls the minimum and maximum TLS versions. This setting's value is an object of $(ref:tlsVersionRestrictionConfig).</returns>
        ValueTask<Setting> GetTlsVersionRestriction();

        /// <summary>Gets the 'webRTCIPHandlingPolicy' property.</summary>
        /// <returns>Allow users to specify the media performance/privacy tradeoffs which impacts how WebRTC traffic will be routed and how much local address information is exposed. This preference's value is of type IPHandlingPolicy, defaulting to <c>default</c>.</returns>
        ValueTask<Setting> GetWebRTCIPHandlingPolicy();
    }
}
