using WebExtensions.Net.Types;

namespace WebExtensions.Net.Privacy.Network
{
    /// <summary>Use the <c>browser.privacy</c> API to control usage of the features in the browser that can affect a user's privacy.</summary>
    public partial interface INetworkApi
    {
        /// <summary>Allow users to query the status of 'Global Privacy Control'. This setting's value is of type boolean, defaulting to <c>false</c>.</summary>
        Setting GlobalPrivacyControl { get; }

        /// <summary>Allow users to query the mode for 'HTTPS-Only Mode'. This setting's value is of type HTTPSOnlyModeOption, defaulting to <c>never</c>.</summary>
        Setting HttpsOnlyMode { get; }

        /// <summary>If enabled, the browser attempts to speed up your web browsing experience by pre-resolving DNS entries, prerendering sites (<c>&amp;lt;link rel='prefetch' ...&amp;gt;</c>), and preemptively opening TCP and SSL connections to servers.  This preference's value is a boolean, defaulting to <c>true</c>.</summary>
        Setting NetworkPredictionEnabled { get; }

        /// <summary>Allow users to enable and disable RTCPeerConnections (aka WebRTC).</summary>
        Setting PeerConnectionEnabled { get; }

        /// <summary>This property controls the minimum and maximum TLS versions. This setting's value is an object of $(ref:tlsVersionRestrictionConfig).</summary>
        Setting TlsVersionRestriction { get; }

        /// <summary>Allow users to specify the media performance/privacy tradeoffs which impacts how WebRTC traffic will be routed and how much local address information is exposed. This preference's value is of type IPHandlingPolicy, defaulting to <c>default</c>.</summary>
        Setting WebRTCIPHandlingPolicy { get; }
    }
}
