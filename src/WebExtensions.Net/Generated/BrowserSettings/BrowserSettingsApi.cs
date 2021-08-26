using JsBind.Net;
using System;
using System.Threading.Tasks;
using WebExtensions.Net.Types;

namespace WebExtensions.Net.BrowserSettings
{
    /// <inheritdoc />
    public partial class BrowserSettingsApi : BaseApi, IBrowserSettingsApi
    {
        /// <summary>Creates a new instance of <see cref="BrowserSettingsApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public BrowserSettingsApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "browserSettings"))
        {
        }

        /// <inheritdoc />
        public virtual ValueTask<Setting> GetAllowPopupsForUserEvents()
        {
            return GetPropertyAsync<Setting>("allowPopupsForUserEvents");
        }

        /// <inheritdoc />
        public virtual ValueTask<Setting> GetCacheEnabled()
        {
            return GetPropertyAsync<Setting>("cacheEnabled");
        }

        /// <inheritdoc />
        public virtual ValueTask<Setting> GetCloseTabsByDoubleClick()
        {
            return GetPropertyAsync<Setting>("closeTabsByDoubleClick");
        }

        /// <inheritdoc />
        public virtual ValueTask<Setting> GetContextMenuShowEvent()
        {
            return GetPropertyAsync<Setting>("contextMenuShowEvent");
        }

        /// <inheritdoc />
        [Obsolete("FTP support was removed from Firefox in bug 1574475")]
        public virtual ValueTask<Setting> GetFtpProtocolEnabled()
        {
            return GetPropertyAsync<Setting>("ftpProtocolEnabled");
        }

        /// <inheritdoc />
        public virtual ValueTask<Setting> GetHomepageOverride()
        {
            return GetPropertyAsync<Setting>("homepageOverride");
        }

        /// <inheritdoc />
        public virtual ValueTask<Setting> GetImageAnimationBehavior()
        {
            return GetPropertyAsync<Setting>("imageAnimationBehavior");
        }

        /// <inheritdoc />
        public virtual ValueTask<Setting> GetNewTabPageOverride()
        {
            return GetPropertyAsync<Setting>("newTabPageOverride");
        }

        /// <inheritdoc />
        public virtual ValueTask<Setting> GetNewTabPosition()
        {
            return GetPropertyAsync<Setting>("newTabPosition");
        }

        /// <inheritdoc />
        public virtual ValueTask<Setting> GetOpenBookmarksInNewTabs()
        {
            return GetPropertyAsync<Setting>("openBookmarksInNewTabs");
        }

        /// <inheritdoc />
        public virtual ValueTask<Setting> GetOpenSearchResultsInNewTabs()
        {
            return GetPropertyAsync<Setting>("openSearchResultsInNewTabs");
        }

        /// <inheritdoc />
        public virtual ValueTask<Setting> GetOpenUrlbarResultsInNewTabs()
        {
            return GetPropertyAsync<Setting>("openUrlbarResultsInNewTabs");
        }

        /// <inheritdoc />
        public virtual ValueTask<Setting> GetOverrideDocumentColors()
        {
            return GetPropertyAsync<Setting>("overrideDocumentColors");
        }

        /// <inheritdoc />
        public virtual ValueTask<Setting> GetUseDocumentFonts()
        {
            return GetPropertyAsync<Setting>("useDocumentFonts");
        }

        /// <inheritdoc />
        public virtual ValueTask<Setting> GetWebNotificationsDisabled()
        {
            return GetPropertyAsync<Setting>("webNotificationsDisabled");
        }

        /// <inheritdoc />
        public virtual ValueTask<Setting> GetZoomFullPage()
        {
            return GetPropertyAsync<Setting>("zoomFullPage");
        }

        /// <inheritdoc />
        public virtual ValueTask<Setting> GetZoomSiteSpecific()
        {
            return GetPropertyAsync<Setting>("zoomSiteSpecific");
        }
    }
}
