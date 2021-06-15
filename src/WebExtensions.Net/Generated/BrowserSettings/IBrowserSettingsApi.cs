using System;
using System.Threading.Tasks;
using WebExtensions.Net.Types;

namespace WebExtensions.Net.BrowserSettings
{
    /// <summary>Use the <c>browser.browserSettings</c> API to control global settings of the browser.</summary>
    public partial interface IBrowserSettingsApi
    {
        /// <summary>Gets the 'allowPopupsForUserEvents' property.</summary>
        /// <returns>Allows or disallows pop-up windows from opening in response to user events.</returns>
        ValueTask<Setting> GetAllowPopupsForUserEvents();

        /// <summary>Gets the 'cacheEnabled' property.</summary>
        /// <returns>Enables or disables the browser cache.</returns>
        ValueTask<Setting> GetCacheEnabled();

        /// <summary>Gets the 'closeTabsByDoubleClick' property.</summary>
        /// <returns>This boolean setting controls whether the selected tab can be closed with a double click.</returns>
        ValueTask<Setting> GetCloseTabsByDoubleClick();

        /// <summary>Gets the 'contextMenuShowEvent' property.</summary>
        /// <returns>Controls after which mouse event context menus popup. This setting's value is of type ContextMenuMouseEvent, which has possible values of <c>mouseup</c> and <c>mousedown</c>.</returns>
        ValueTask<Setting> GetContextMenuShowEvent();

        /// <summary>Gets the 'ftpProtocolEnabled' property.</summary>
        /// <returns>Returns whether the FTP protocol is enabled. Read-only.</returns>
        [Obsolete("FTP support was removed from Firefox in bug 1574475")]
        ValueTask<Setting> GetFtpProtocolEnabled();

        /// <summary>Gets the 'homepageOverride' property.</summary>
        /// <returns>Returns the value of the overridden home page. Read-only.</returns>
        ValueTask<Setting> GetHomepageOverride();

        /// <summary>Gets the 'imageAnimationBehavior' property.</summary>
        /// <returns>Controls the behaviour of image animation in the browser. This setting's value is of type ImageAnimationBehavior, defaulting to <c>normal</c>.</returns>
        ValueTask<Setting> GetImageAnimationBehavior();

        /// <summary>Gets the 'newTabPageOverride' property.</summary>
        /// <returns>Returns the value of the overridden new tab page. Read-only.</returns>
        ValueTask<Setting> GetNewTabPageOverride();

        /// <summary>Gets the 'newTabPosition' property.</summary>
        /// <returns>Controls where new tabs are opened. `afterCurrent` will open all new tabs next to the current tab, `relatedAfterCurrent` will open only related tabs next to the current tab, and `atEnd` will open all tabs at the end of the tab strip. The default is `relatedAfterCurrent`.</returns>
        ValueTask<Setting> GetNewTabPosition();

        /// <summary>Gets the 'openBookmarksInNewTabs' property.</summary>
        /// <returns>This boolean setting controls whether bookmarks are opened in the current tab or in a new tab.</returns>
        ValueTask<Setting> GetOpenBookmarksInNewTabs();

        /// <summary>Gets the 'openSearchResultsInNewTabs' property.</summary>
        /// <returns>This boolean setting controls whether search results are opened in the current tab or in a new tab.</returns>
        ValueTask<Setting> GetOpenSearchResultsInNewTabs();

        /// <summary>Gets the 'openUrlbarResultsInNewTabs' property.</summary>
        /// <returns>This boolean setting controls whether urlbar results are opened in the current tab or in a new tab.</returns>
        ValueTask<Setting> GetOpenUrlbarResultsInNewTabs();

        /// <summary>Gets the 'overrideDocumentColors' property.</summary>
        /// <returns>This setting controls whether the user-chosen colors override the page's colors.</returns>
        ValueTask<Setting> GetOverrideDocumentColors();

        /// <summary>Gets the 'useDocumentFonts' property.</summary>
        /// <returns>This setting controls whether the document's fonts are used.</returns>
        ValueTask<Setting> GetUseDocumentFonts();

        /// <summary>Gets the 'webNotificationsDisabled' property.</summary>
        /// <returns>Disables webAPI notifications.</returns>
        ValueTask<Setting> GetWebNotificationsDisabled();

        /// <summary>Gets the 'zoomFullPage' property.</summary>
        /// <returns>This boolean setting controls whether zoom is applied to the full page or to text only.</returns>
        ValueTask<Setting> GetZoomFullPage();

        /// <summary>Gets the 'zoomSiteSpecific' property.</summary>
        /// <returns>This boolean setting controls whether zoom is applied on a per-site basis or to the current tab only. If privacy.resistFingerprinting is true, this setting has no effect and zoom is applied to the current tab only.</returns>
        ValueTask<Setting> GetZoomSiteSpecific();
    }
}
