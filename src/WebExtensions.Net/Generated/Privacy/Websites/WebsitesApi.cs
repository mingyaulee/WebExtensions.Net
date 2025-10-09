using JsBind.Net;
using WebExtensions.Net.Types;

namespace WebExtensions.Net.Privacy.Websites
{
    /// <inheritdoc />
    /// <param name="jsRuntime">The JS runtime adapter.</param>
    /// <param name="accessPath">The base API access path.</param>
    public partial class WebsitesApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "websites")), IWebsitesApi
    {
        /// <inheritdoc />
        public Setting CookieConfig => GetProperty<Setting>("cookieConfig");

        /// <inheritdoc />
        public Setting FirstPartyIsolate => GetProperty<Setting>("firstPartyIsolate");

        /// <inheritdoc />
        public Setting HyperlinkAuditingEnabled => GetProperty<Setting>("hyperlinkAuditingEnabled");

        /// <inheritdoc />
        public Setting ReferrersEnabled => GetProperty<Setting>("referrersEnabled");

        /// <inheritdoc />
        public Setting ResistFingerprinting => GetProperty<Setting>("resistFingerprinting");

        /// <inheritdoc />
        public Setting TrackingProtectionMode => GetProperty<Setting>("trackingProtectionMode");
    }
}
