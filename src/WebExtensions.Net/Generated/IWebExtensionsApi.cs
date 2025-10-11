using JsBind.Net;
using System;
using WebExtensions.Net.ActionNs;
using WebExtensions.Net.ActivityLog;
using WebExtensions.Net.Alarms;
using WebExtensions.Net.Bookmarks;
using WebExtensions.Net.BrowserAction;
using WebExtensions.Net.BrowserSettings;
using WebExtensions.Net.BrowsingData;
using WebExtensions.Net.CaptivePortal;
using WebExtensions.Net.Clipboard;
using WebExtensions.Net.Commands;
using WebExtensions.Net.ContentScripts;
using WebExtensions.Net.ContextualIdentities;
using WebExtensions.Net.Cookies;
using WebExtensions.Net.DeclarativeNetRequest;
using WebExtensions.Net.Devtools;
using WebExtensions.Net.Dns;
using WebExtensions.Net.Downloads;
using WebExtensions.Net.Extension;
using WebExtensions.Net.Find;
using WebExtensions.Net.GeckoProfiler;
using WebExtensions.Net.History;
using WebExtensions.Net.I18n;
using WebExtensions.Net.Identity;
using WebExtensions.Net.Idle;
using WebExtensions.Net.Management;
using WebExtensions.Net.Menus;
using WebExtensions.Net.NetworkStatus;
using WebExtensions.Net.NormandyAddonStudy;
using WebExtensions.Net.Notifications;
using WebExtensions.Net.Omnibox;
using WebExtensions.Net.PageAction;
using WebExtensions.Net.Permissions;
using WebExtensions.Net.Pkcs11;
using WebExtensions.Net.Privacy;
using WebExtensions.Net.Proxy;
using WebExtensions.Net.Runtime;
using WebExtensions.Net.Scripting;
using WebExtensions.Net.Search;
using WebExtensions.Net.Sessions;
using WebExtensions.Net.SidebarAction;
using WebExtensions.Net.Storage;
using WebExtensions.Net.TabGroups;
using WebExtensions.Net.Tabs;
using WebExtensions.Net.Telemetry;
using WebExtensions.Net.Test;
using WebExtensions.Net.Theme;
using WebExtensions.Net.TopSites;
using WebExtensions.Net.Trial;
using WebExtensions.Net.UserScripts;
using WebExtensions.Net.WebNavigation;
using WebExtensions.Net.WebRequest;
using WebExtensions.Net.Windows;

namespace WebExtensions.Net;

/// <summary>Web Extension Api</summary>
[JsAccessPath("browser")]
public partial interface IWebExtensionsApi
{
    /// <summary>Use browser actions to put icons in the main browser toolbar, to the right of the address bar. In addition to its icon, a browser action can also have a tooltip, a badge, and a popup.<br />Requires manifest permission manifest:action, manifest:browser_action.</summary>
    [JsAccessPath("action")]
    IActionApi Action { get; }

    /// <summary>Monitor extension activity<br />Requires manifest permission activityLog.</summary>
    [JsAccessPath("activityLog")]
    IActivityLogApi ActivityLog { get; }

    /// <summary><br />Requires manifest permission alarms.</summary>
    [JsAccessPath("alarms")]
    IAlarmsApi Alarms { get; }

    /// <summary>Use the <c>browser.bookmarks</c> API to create, organize, and otherwise manipulate bookmarks. Also see $(topic:override)[Override Pages], which you can use to create a custom Bookmark Manager page.<br />Requires manifest permission bookmarks.</summary>
    [JsAccessPath("bookmarks")]
    IBookmarksApi Bookmarks { get; }

    /// <summary>Use browser actions to put icons in the main browser toolbar, to the right of the address bar. In addition to its icon, a browser action can also have a tooltip, a badge, and a popup.<br />Requires manifest permission manifest:action, manifest:browser_action.</summary>
    [JsAccessPath("browserAction")]
    [Obsolete("Deprecated in Manifest V3, use action API.")]
    IBrowserActionApi BrowserAction { get; }

    /// <summary>Use the <c>browser.browserSettings</c> API to control global settings of the browser.<br />Requires manifest permission browserSettings.</summary>
    [JsAccessPath("browserSettings")]
    IBrowserSettingsApi BrowserSettings { get; }

    /// <summary>Use the <c>chrome.browsingData</c> API to remove browsing data from a user's local profile.<br />Requires manifest permission browsingData.</summary>
    [JsAccessPath("browsingData")]
    IBrowsingDataApi BrowsingData { get; }

    /// <summary>This API provides the ability detect the captive portal state of the users connection.<br />Requires manifest permission captivePortal.</summary>
    [JsAccessPath("captivePortal")]
    ICaptivePortalApi CaptivePortal { get; }

    /// <summary>Offers the ability to write to the clipboard. Reading is not supported because the clipboard can already be read through the standard web platform APIs.<br />Requires manifest permission clipboardWrite.</summary>
    [JsAccessPath("clipboard")]
    IClipboardApi Clipboard { get; }

    /// <summary>Use the commands API to add keyboard shortcuts that trigger actions in your extension, for example, an action to open the browser action or send a command to the xtension.<br />Requires manifest permission manifest:commands.</summary>
    [JsAccessPath("commands")]
    ICommandsApi Commands { get; }

    /// <summary></summary>
    [JsAccessPath("contentScripts")]
    IContentScriptsApi ContentScripts { get; }

    /// <summary>Use the <c>browser.contextualIdentities</c> API to query and modify contextual identity, also called as containers.<br />Requires manifest permission contextualIdentities.</summary>
    [JsAccessPath("contextualIdentities")]
    IContextualIdentitiesApi ContextualIdentities { get; }

    /// <summary>Use the <c>browser.cookies</c> API to query and modify cookies, and to be notified when they change.<br />Requires manifest permission cookies.</summary>
    [JsAccessPath("cookies")]
    ICookiesApi Cookies { get; }

    /// <summary>Use the declarativeNetRequest API to block or modify network requests by specifying declarative rules.<br />Requires manifest permission declarativeNetRequest, declarativeNetRequestWithHostAccess.</summary>
    [JsAccessPath("declarativeNetRequest")]
    IDeclarativeNetRequestApi DeclarativeNetRequest { get; }

    /// <summary><br />Requires manifest permission manifest:devtools_page.</summary>
    [JsAccessPath("devtools")]
    IDevtoolsApi Devtools { get; }

    /// <summary>Asynchronous DNS API<br />Requires manifest permission dns.</summary>
    [JsAccessPath("dns")]
    IDnsApi Dns { get; }

    /// <summary><br />Requires manifest permission downloads.</summary>
    [JsAccessPath("downloads")]
    IDownloadsApi Downloads { get; }

    /// <summary>The <c>browser.extension</c> API has utilities that can be used by any extension page. It includes support for exchanging messages between an extension and its content scripts or between extensions, as described in detail in $(topic:messaging)[Message Passing].</summary>
    [JsAccessPath("extension")]
    IExtensionApi Extension { get; }

    /// <summary>Use the <c>browser.find</c> API to interact with the browser's <c>Find</c> interface.<br />Requires manifest permission find.</summary>
    [JsAccessPath("find")]
    IFindApi Find { get; }

    /// <summary>Exposes the browser's profiler.<br />Requires manifest permission geckoProfiler.</summary>
    [JsAccessPath("geckoProfiler")]
    IGeckoProfilerApi GeckoProfiler { get; }

    /// <summary>Use the <c>browser.history</c> API to interact with the browser's record of visited pages. You can add, remove, and query for URLs in the browser's history. To override the history page with your own version, see $(topic:override)[Override Pages].<br />Requires manifest permission history.</summary>
    [JsAccessPath("history")]
    IHistoryApi History { get; }

    /// <summary>Use the <c>browser.i18n</c> infrastructure to implement internationalization across your whole app or extension.</summary>
    [JsAccessPath("i18n")]
    II18nApi I18n { get; }

    /// <summary>Use the chrome.identity API to get OAuth2 access tokens. <br />Requires manifest permission identity.</summary>
    [JsAccessPath("identity")]
    IIdentityApi Identity { get; }

    /// <summary>Use the <c>browser.idle</c> API to detect when the machine's idle state changes.<br />Requires manifest permission idle.</summary>
    [JsAccessPath("idle")]
    IIdleApi Idle { get; }

    /// <summary>The <c>browser.management</c> API provides ways to manage the list of extensions that are installed and running.</summary>
    [JsAccessPath("management")]
    IManagementApi Management { get; }

    /// <summary>The part of the menus API that is available in all extension contexts, including content scripts. Use the browser.menus API to add items to the browser's menus. You can choose what types of objects your context menu additions apply to, such as images, hyperlinks, and pages.<br />Requires manifest permission menus.</summary>
    [JsAccessPath("menus")]
    IMenusApi Menus { get; }

    /// <summary>This API provides the ability to determine the status of and detect changes in the network connection. This API can only be used in privileged extensions.<br />Requires manifest permission networkStatus.</summary>
    [JsAccessPath("networkStatus")]
    INetworkStatusApi NetworkStatus { get; }

    /// <summary>Normandy Study API<br />Requires manifest permission normandyAddonStudy.</summary>
    [JsAccessPath("normandyAddonStudy")]
    INormandyAddonStudyApi NormandyAddonStudy { get; }

    /// <summary><br />Requires manifest permission notifications.</summary>
    [JsAccessPath("notifications")]
    INotificationsApi Notifications { get; }

    /// <summary>The omnibox API allows you to register a keyword with Firefox's address bar.<br />Requires manifest permission manifest:omnibox.</summary>
    [JsAccessPath("omnibox")]
    IOmniboxApi Omnibox { get; }

    /// <summary>Use the <c>browser.pageAction</c> API to put icons inside the address bar. Page actions represent actions that can be taken on the current page, but that aren't applicable to all pages.<br />Requires manifest permission manifest:page_action.</summary>
    [JsAccessPath("pageAction")]
    IPageActionApi PageAction { get; }

    /// <summary></summary>
    [JsAccessPath("permissions")]
    IPermissionsApi Permissions { get; }

    /// <summary>PKCS#11 module management API<br />Requires manifest permission pkcs11.</summary>
    [JsAccessPath("pkcs11")]
    IPkcs11Api Pkcs11 { get; }

    /// <summary><br />Requires manifest permission privacy.</summary>
    [JsAccessPath("privacy")]
    IPrivacyApi Privacy { get; }

    /// <summary>Provides access to global proxy settings for Firefox and proxy event listeners to handle dynamic proxy implementations.<br />Requires manifest permission proxy.</summary>
    [JsAccessPath("proxy")]
    IProxyApi Proxy { get; }

    /// <summary>Use the <c>browser.runtime</c> API to retrieve the background page, return details about the manifest, and listen for and respond to events in the app or extension lifecycle. You can also use this API to convert the relative path of URLs to fully-qualified URLs.</summary>
    [JsAccessPath("runtime")]
    IRuntimeApi Runtime { get; }

    /// <summary>Use the scripting API to execute script in different contexts.<br />Requires manifest permission scripting.</summary>
    [JsAccessPath("scripting")]
    IScriptingApi Scripting { get; }

    /// <summary>Use browser.search to interact with search engines.<br />Requires manifest permission search.</summary>
    [JsAccessPath("search")]
    ISearchApi Search { get; }

    /// <summary>Use the <c>chrome.sessions</c> API to query and restore tabs and windows from a browsing session.<br />Requires manifest permission sessions.</summary>
    [JsAccessPath("sessions")]
    ISessionsApi Sessions { get; }

    /// <summary>Use sidebar actions to add a sidebar to Firefox.<br />Requires manifest permission manifest:sidebar_action.</summary>
    [JsAccessPath("sidebarAction")]
    ISidebarActionApi SidebarAction { get; }

    /// <summary>Use the <c>browser.storage</c> API to store, retrieve, and track changes to user data.<br />Requires manifest permission storage.</summary>
    [JsAccessPath("storage")]
    IStorageApi Storage { get; }

    /// <summary>Use the browser.tabGroups API to interact with the browser's tab grouping system. You can use this API to modify, and rearrange tab groups.<br />Requires manifest permission tabGroups.</summary>
    [JsAccessPath("tabGroups")]
    ITabGroupsApi TabGroups { get; }

    /// <summary>Use the <c>browser.tabs</c> API to interact with the browser's tab system. You can use this API to create, modify, and rearrange tabs in the browser.</summary>
    [JsAccessPath("tabs")]
    ITabsApi Tabs { get; }

    /// <summary>Use the <c>browser.telemetry</c> API to send telemetry data to the Mozilla Telemetry service. Restricted to Mozilla privileged webextensions.<br />Requires manifest permission telemetry.</summary>
    [JsAccessPath("telemetry")]
    ITelemetryApi Telemetry { get; }

    /// <summary>none</summary>
    [JsAccessPath("test")]
    ITestApi Test { get; }

    /// <summary>The theme API allows customizing of visual elements of the browser.</summary>
    [JsAccessPath("theme")]
    IThemeApi Theme { get; }

    /// <summary>Use the chrome.topSites API to access the top sites that are displayed on the new tab page. <br />Requires manifest permission topSites.</summary>
    [JsAccessPath("topSites")]
    ITopSitesApi TopSites { get; }

    /// <summary><br />Requires manifest permission trialML.</summary>
    [JsAccessPath("trial")]
    ITrialApi Trial { get; }

    /// <summary><br />Requires manifest permission manifest:user_scripts, userScripts.</summary>
    [JsAccessPath("userScripts")]
    IUserScriptsApi UserScripts { get; }

    /// <summary>Use the <c>browser.webNavigation</c> API to receive notifications about the status of navigation requests in-flight.<br />Requires manifest permission webNavigation.</summary>
    [JsAccessPath("webNavigation")]
    IWebNavigationApi WebNavigation { get; }

    /// <summary>Use the <c>browser.webRequest</c> API to observe and analyze traffic and to intercept, block, or modify requests in-flight.<br />Requires manifest permission webRequest.</summary>
    [JsAccessPath("webRequest")]
    IWebRequestApi WebRequest { get; }

    /// <summary>Use the <c>browser.windows</c> API to interact with browser windows. You can use this API to create, modify, and rearrange windows in the browser.</summary>
    [JsAccessPath("windows")]
    IWindowsApi Windows { get; }
}
