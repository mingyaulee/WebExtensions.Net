using JsBind.Net;
using System;
using WebExtensions.Net.BrowserSettings.ColorManagement;
using WebExtensions.Net.Types;

namespace WebExtensions.Net.BrowserSettings
{
    /// <inheritdoc />
    public partial class BrowserSettingsApi : BaseApi, IBrowserSettingsApi
    {
        private IColorManagementApi _colorManagement;

        /// <summary>Creates a new instance of <see cref="BrowserSettingsApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public BrowserSettingsApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "browserSettings"))
        {
        }

        /// <inheritdoc />
        public IColorManagementApi ColorManagement => _colorManagement ??= new ColorManagementApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public Setting AllowPopupsForUserEvents => GetProperty<Setting>("allowPopupsForUserEvents");

        /// <inheritdoc />
        public Setting CacheEnabled => GetProperty<Setting>("cacheEnabled");

        /// <inheritdoc />
        public Setting CloseTabsByDoubleClick => GetProperty<Setting>("closeTabsByDoubleClick");

        /// <inheritdoc />
        public Setting ContextMenuShowEvent => GetProperty<Setting>("contextMenuShowEvent");

        /// <inheritdoc />
        [Obsolete("FTP support was removed from Firefox in bug 1574475")]
        public Setting FtpProtocolEnabled => GetProperty<Setting>("ftpProtocolEnabled");

        /// <inheritdoc />
        public Setting HomepageOverride => GetProperty<Setting>("homepageOverride");

        /// <inheritdoc />
        public Setting ImageAnimationBehavior => GetProperty<Setting>("imageAnimationBehavior");

        /// <inheritdoc />
        public Setting NewTabPageOverride => GetProperty<Setting>("newTabPageOverride");

        /// <inheritdoc />
        public Setting NewTabPosition => GetProperty<Setting>("newTabPosition");

        /// <inheritdoc />
        public Setting OpenBookmarksInNewTabs => GetProperty<Setting>("openBookmarksInNewTabs");

        /// <inheritdoc />
        public Setting OpenSearchResultsInNewTabs => GetProperty<Setting>("openSearchResultsInNewTabs");

        /// <inheritdoc />
        public Setting OpenUrlbarResultsInNewTabs => GetProperty<Setting>("openUrlbarResultsInNewTabs");

        /// <inheritdoc />
        public Setting OverrideContentColorScheme => GetProperty<Setting>("overrideContentColorScheme");

        /// <inheritdoc />
        public Setting OverrideDocumentColors => GetProperty<Setting>("overrideDocumentColors");

        /// <inheritdoc />
        public Setting UseDocumentFonts => GetProperty<Setting>("useDocumentFonts");

        /// <inheritdoc />
        public Setting VerticalTabs => GetProperty<Setting>("verticalTabs");

        /// <inheritdoc />
        public Setting WebNotificationsDisabled => GetProperty<Setting>("webNotificationsDisabled");

        /// <inheritdoc />
        public Setting ZoomFullPage => GetProperty<Setting>("zoomFullPage");

        /// <inheritdoc />
        public Setting ZoomSiteSpecific => GetProperty<Setting>("zoomSiteSpecific");
    }
}
