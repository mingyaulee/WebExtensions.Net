using JsBind.Net;
using WebExtensions.Net.Privacy.Network;
using WebExtensions.Net.Privacy.Services;
using WebExtensions.Net.Privacy.Websites;

namespace WebExtensions.Net.Privacy
{
    /// <summary></summary>
    [JsAccessPath("privacy")]
    public partial interface IPrivacyApi
    {
        /// <summary>Use the <c>browser.privacy</c> API to control usage of the features in the browser that can affect a user's privacy.<br />Requires manifest permission privacy.</summary>
        [JsAccessPath("network")]
        INetworkApi Network { get; }

        /// <summary>Use the <c>browser.privacy</c> API to control usage of the features in the browser that can affect a user's privacy.<br />Requires manifest permission privacy.</summary>
        [JsAccessPath("services")]
        IServicesApi Services { get; }

        /// <summary>Use the <c>browser.privacy</c> API to control usage of the features in the browser that can affect a user's privacy.<br />Requires manifest permission privacy.</summary>
        [JsAccessPath("websites")]
        IWebsitesApi Websites { get; }
    }
}
