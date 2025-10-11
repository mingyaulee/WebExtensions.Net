using JsBind.Net;
using System;
using WebExtensions.Net.BrowserSettings.ColorManagement;
using WebExtensions.Net.Types;

namespace WebExtensions.Net.BrowserSettings;

/// <summary>Use the <c>browser.browserSettings</c> API to control global settings of the browser.</summary>
[JsAccessPath("browserSettings")]
public partial interface IBrowserSettingsApi
{
    /// <summary>Use the <c>browserSettings.colorManagement</c> API to query and set items related to color management.<br />Requires manifest permission browserSettings.</summary>
    [JsAccessPath("colorManagement")]
    IColorManagementApi ColorManagement { get; }

    /// <summary>Allows or disallows pop-up windows from opening in response to user events.</summary>
    [JsAccessPath("allowPopupsForUserEvents")]
    Setting AllowPopupsForUserEvents { get; }

    /// <summary>Enables or disables the browser cache.</summary>
    [JsAccessPath("cacheEnabled")]
    Setting CacheEnabled { get; }

    /// <summary>This boolean setting controls whether the selected tab can be closed with a double click.</summary>
    [JsAccessPath("closeTabsByDoubleClick")]
    Setting CloseTabsByDoubleClick { get; }

    /// <summary>Controls after which mouse event context menus popup. This setting's value is of type ContextMenuMouseEvent, which has possible values of <c>mouseup</c> and <c>mousedown</c>.</summary>
    [JsAccessPath("contextMenuShowEvent")]
    Setting ContextMenuShowEvent { get; }

    /// <summary>Returns whether the FTP protocol is enabled. Read-only.</summary>
    [JsAccessPath("ftpProtocolEnabled")]
    [Obsolete("FTP support was removed from Firefox in bug 1574475")]
    Setting FtpProtocolEnabled { get; }

    /// <summary>Returns the value of the overridden home page. Read-only.</summary>
    [JsAccessPath("homepageOverride")]
    Setting HomepageOverride { get; }

    /// <summary>Controls the behaviour of image animation in the browser. This setting's value is of type ImageAnimationBehavior, defaulting to <c>normal</c>.</summary>
    [JsAccessPath("imageAnimationBehavior")]
    Setting ImageAnimationBehavior { get; }

    /// <summary>Returns the value of the overridden new tab page. Read-only.</summary>
    [JsAccessPath("newTabPageOverride")]
    Setting NewTabPageOverride { get; }

    /// <summary>Controls where new tabs are opened. `afterCurrent` will open all new tabs next to the current tab, `relatedAfterCurrent` will open only related tabs next to the current tab, and `atEnd` will open all tabs at the end of the tab strip. The default is `relatedAfterCurrent`.</summary>
    [JsAccessPath("newTabPosition")]
    Setting NewTabPosition { get; }

    /// <summary>This boolean setting controls whether bookmarks are opened in the current tab or in a new tab.</summary>
    [JsAccessPath("openBookmarksInNewTabs")]
    Setting OpenBookmarksInNewTabs { get; }

    /// <summary>This boolean setting controls whether search results are opened in the current tab or in a new tab.</summary>
    [JsAccessPath("openSearchResultsInNewTabs")]
    Setting OpenSearchResultsInNewTabs { get; }

    /// <summary>This boolean setting controls whether urlbar results are opened in the current tab or in a new tab.</summary>
    [JsAccessPath("openUrlbarResultsInNewTabs")]
    Setting OpenUrlbarResultsInNewTabs { get; }

    /// <summary>This setting controls whether a light or dark color scheme overrides the page's preferred color scheme.</summary>
    [JsAccessPath("overrideContentColorScheme")]
    Setting OverrideContentColorScheme { get; }

    /// <summary>This setting controls whether the user-chosen colors override the page's colors.</summary>
    [JsAccessPath("overrideDocumentColors")]
    Setting OverrideDocumentColors { get; }

    /// <summary>This setting controls whether the document's fonts are used.</summary>
    [JsAccessPath("useDocumentFonts")]
    Setting UseDocumentFonts { get; }

    /// <summary>This boolean setting controls whether vertical tabs are enabled.</summary>
    [JsAccessPath("verticalTabs")]
    Setting VerticalTabs { get; }

    /// <summary>Disables webAPI notifications.</summary>
    [JsAccessPath("webNotificationsDisabled")]
    Setting WebNotificationsDisabled { get; }

    /// <summary>This boolean setting controls whether zoom is applied to the full page or to text only.</summary>
    [JsAccessPath("zoomFullPage")]
    Setting ZoomFullPage { get; }

    /// <summary>This boolean setting controls whether zoom is applied on a per-site basis or to the current tab only. If privacy.resistFingerprinting is true, this setting has no effect and zoom is applied to the current tab only.</summary>
    [JsAccessPath("zoomSiteSpecific")]
    Setting ZoomSiteSpecific { get; }
}
