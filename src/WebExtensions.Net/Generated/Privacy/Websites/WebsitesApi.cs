using JsBind.Net;
using WebExtensions.Net.Types;

namespace WebExtensions.Net.Privacy.Websites
{
    /// <inheritdoc />
    public partial class WebsitesApi : BaseApi, IWebsitesApi
    {
        /// <summary>Creates a new instance of <see cref="WebsitesApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public WebsitesApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "websites"))
        {
        }

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
