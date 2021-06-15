using WebExtensions.Net.Alarms;
using WebExtensions.Net.Bookmarks;
using WebExtensions.Net.BrowserAction;
using WebExtensions.Net.BrowserSettings;
using WebExtensions.Net.BrowsingData;
using WebExtensions.Net.Clipboard;
using WebExtensions.Net.Commands;
using WebExtensions.Net.ContentScripts;
using WebExtensions.Net.Cookies;
using WebExtensions.Net.Devtools;
using WebExtensions.Net.Downloads;
using WebExtensions.Net.Extension;
using WebExtensions.Net.History;
using WebExtensions.Net.I18n;
using WebExtensions.Net.Identity;
using WebExtensions.Net.Idle;
using WebExtensions.Net.Management;
using WebExtensions.Net.Menus;
using WebExtensions.Net.Notifications;
using WebExtensions.Net.Omnibox;
using WebExtensions.Net.PageAction;
using WebExtensions.Net.Permissions;
using WebExtensions.Net.Privacy;
using WebExtensions.Net.Proxy;
using WebExtensions.Net.Runtime;
using WebExtensions.Net.Search;
using WebExtensions.Net.Sessions;
using WebExtensions.Net.Storage;
using WebExtensions.Net.Tabs;
using WebExtensions.Net.TopSites;
using WebExtensions.Net.WebNavigation;
using WebExtensions.Net.WebRequest;
using WebExtensions.Net.Windows;

namespace WebExtensions.Net
{
    /// <summary>Web Extension Api</summary>
    public partial interface IWebExtensionsApi
    {
        /// <summary><br />Requires manifest permission alarms.</summary>
        IAlarmsApi Alarms { get; }

        /// <summary>Use the <c>browser.bookmarks</c> API to create, organize, and otherwise manipulate bookmarks. Also see $(topic:override)[Override Pages], which you can use to create a custom Bookmark Manager page.<br />Requires manifest permission bookmarks.</summary>
        IBookmarksApi Bookmarks { get; }

        /// <summary>Use browser actions to put icons in the main browser toolbar, to the right of the address bar. In addition to its icon, a browser action can also have a tooltip, a badge, and a popup.<br />Requires manifest permission manifest:browser_action.</summary>
        IBrowserActionApi BrowserAction { get; }

        /// <summary>Use the <c>browser.browserSettings</c> API to control global settings of the browser.<br />Requires manifest permission browserSettings.</summary>
        IBrowserSettingsApi BrowserSettings { get; }

        /// <summary>Use the <c>chrome.browsingData</c> API to remove browsing data from a user's local profile.<br />Requires manifest permission browsingData.</summary>
        IBrowsingDataApi BrowsingData { get; }

        /// <summary>Offers the ability to write to the clipboard. Reading is not supported because the clipboard can already be read through the standard web platform APIs.<br />Requires manifest permission clipboardWrite.</summary>
        IClipboardApi Clipboard { get; }

        /// <summary>Use the commands API to add keyboard shortcuts that trigger actions in your extension, for example, an action to open the browser action or send a command to the xtension.<br />Requires manifest permission manifest:commands.</summary>
        ICommandsApi Commands { get; }

        /// <summary></summary>
        IContentScriptsApi ContentScripts { get; }

        /// <summary>Use the <c>browser.cookies</c> API to query and modify cookies, and to be notified when they change.<br />Requires manifest permission cookies.</summary>
        ICookiesApi Cookies { get; }

        /// <summary><br />Requires manifest permission manifest:devtools_page.</summary>
        IDevtoolsApi Devtools { get; }

        /// <summary><br />Requires manifest permission downloads.</summary>
        IDownloadsApi Downloads { get; }

        /// <summary>The <c>browser.extension</c> API has utilities that can be used by any extension page. It includes support for exchanging messages between an extension and its content scripts or between extensions, as described in detail in $(topic:messaging)[Message Passing].</summary>
        IExtensionApi Extension { get; }

        /// <summary>Use the <c>browser.history</c> API to interact with the browser's record of visited pages. You can add, remove, and query for URLs in the browser's history. To override the history page with your own version, see $(topic:override)[Override Pages].<br />Requires manifest permission history.</summary>
        IHistoryApi History { get; }

        /// <summary>Use the <c>browser.i18n</c> infrastructure to implement internationalization across your whole app or extension.</summary>
        II18nApi I18n { get; }

        /// <summary>Use the chrome.identity API to get OAuth2 access tokens. <br />Requires manifest permission identity.</summary>
        IIdentityApi Identity { get; }

        /// <summary>Use the <c>browser.idle</c> API to detect when the machine's idle state changes.<br />Requires manifest permission idle.</summary>
        IIdleApi Idle { get; }

        /// <summary>The <c>browser.management</c> API provides ways to manage the list of extensions that are installed and running.</summary>
        IManagementApi Management { get; }

        /// <summary>The part of the menus API that is available in all extension contexts, including content scripts. Use the browser.menus API to add items to the browser's menus. You can choose what types of objects your context menu additions apply to, such as images, hyperlinks, and pages.<br />Requires manifest permission menus, menus.</summary>
        IMenusApi Menus { get; }

        /// <summary><br />Requires manifest permission notifications.</summary>
        INotificationsApi Notifications { get; }

        /// <summary>The omnibox API allows you to register a keyword with Firefox's address bar.<br />Requires manifest permission manifest:omnibox.</summary>
        IOmniboxApi Omnibox { get; }

        /// <summary>Use the <c>browser.pageAction</c> API to put icons inside the address bar. Page actions represent actions that can be taken on the current page, but that aren't applicable to all pages.<br />Requires manifest permission manifest:page_action.</summary>
        IPageActionApi PageAction { get; }

        /// <summary><br />Requires manifest permission manifest:optional_permissions.</summary>
        IPermissionsApi Permissions { get; }

        /// <summary><br />Requires manifest permission privacy.</summary>
        IPrivacyApi Privacy { get; }

        /// <summary>Provides access to global proxy settings for Firefox and proxy event listeners to handle dynamic proxy implementations.<br />Requires manifest permission proxy.</summary>
        IProxyApi Proxy { get; }

        /// <summary>Use the <c>browser.runtime</c> API to retrieve the background page, return details about the manifest, and listen for and respond to events in the app or extension lifecycle. You can also use this API to convert the relative path of URLs to fully-qualified URLs.</summary>
        IRuntimeApi Runtime { get; }

        /// <summary>Use browser.search to interact with search engines.<br />Requires manifest permission search.</summary>
        ISearchApi Search { get; }

        /// <summary>Use the <c>chrome.sessions</c> API to query and restore tabs and windows from a browsing session.<br />Requires manifest permission sessions.</summary>
        ISessionsApi Sessions { get; }

        /// <summary>Use the <c>browser.storage</c> API to store, retrieve, and track changes to user data.<br />Requires manifest permission storage.</summary>
        IStorageApi Storage { get; }

        /// <summary>Use the <c>browser.tabs</c> API to interact with the browser's tab system. You can use this API to create, modify, and rearrange tabs in the browser.</summary>
        ITabsApi Tabs { get; }

        /// <summary>Use the chrome.topSites API to access the top sites that are displayed on the new tab page. <br />Requires manifest permission topSites.</summary>
        ITopSitesApi TopSites { get; }

        /// <summary>Use the <c>browser.webNavigation</c> API to receive notifications about the status of navigation requests in-flight.<br />Requires manifest permission webNavigation.</summary>
        IWebNavigationApi WebNavigation { get; }

        /// <summary>Use the <c>browser.webRequest</c> API to observe and analyze traffic and to intercept, block, or modify requests in-flight.<br />Requires manifest permission webRequest.</summary>
        IWebRequestApi WebRequest { get; }

        /// <summary>Use the <c>browser.windows</c> API to interact with browser windows. You can use this API to create, modify, and rearrange windows in the browser.</summary>
        IWindowsApi Windows { get; }
    }
}
