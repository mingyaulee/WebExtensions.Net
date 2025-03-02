using JsBind.Net;

namespace WebExtensions.Net.NetworkStatus
{
    /// <summary>This API provides the ability to determine the status of and detect changes in the network connection. This API can only be used in privileged extensions.</summary>
    [JsAccessPath("networkStatus")]
    public partial interface INetworkStatusApi
    {
        /// <summary>Fired when the network connection state changes.</summary>
        [JsAccessPath("onConnectionChanged")]
        OnConnectionChangedEvent OnConnectionChanged { get; }

        /// <summary>Returns the $(ref:NetworkLinkInfo) of the current network connection.</summary>
        [JsAccessPath("getLinkInfo")]
        void GetLinkInfo();
    }
}
