using JsBind.Net;
using System.Threading.Tasks;
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
        public virtual ValueTask<Setting> GetCookieConfig()
        {
            return GetPropertyAsync<Setting>("cookieConfig");
        }

        /// <inheritdoc />
        public virtual ValueTask<Setting> GetFirstPartyIsolate()
        {
            return GetPropertyAsync<Setting>("firstPartyIsolate");
        }

        /// <inheritdoc />
        public virtual ValueTask<Setting> GetHyperlinkAuditingEnabled()
        {
            return GetPropertyAsync<Setting>("hyperlinkAuditingEnabled");
        }

        /// <inheritdoc />
        public virtual ValueTask<Setting> GetReferrersEnabled()
        {
            return GetPropertyAsync<Setting>("referrersEnabled");
        }

        /// <inheritdoc />
        public virtual ValueTask<Setting> GetResistFingerprinting()
        {
            return GetPropertyAsync<Setting>("resistFingerprinting");
        }

        /// <inheritdoc />
        public virtual ValueTask<Setting> GetTrackingProtectionMode()
        {
            return GetPropertyAsync<Setting>("trackingProtectionMode");
        }
    }
}
