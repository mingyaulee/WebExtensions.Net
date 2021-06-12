using WebExtensions.Net.Bookmarks;
using WebExtensions.Net.ContentScripts;
using WebExtensions.Net.Notifications;
using WebExtensions.Net.Permissions;
using WebExtensions.Net.Runtime;
using WebExtensions.Net.Storage;
using WebExtensions.Net.Tabs;
using WebExtensions.Net.WebNavigation;
using WebExtensions.Net.WebRequest;
using WebExtensions.Net.Windows;

namespace WebExtensions.Net
{
    /// <summary>Web Extension Api</summary>
    public partial interface IWebExtensionsApi
    {
        /// <summary>Use the <c>browser.bookmarks</c> API to create, organize, and otherwise manipulate bookmarks. Also see $(topic:override)[Override Pages], which you can use to create a custom Bookmark Manager page.<br />Requires manifest permission bookmarks.</summary>
        IBookmarksApi Bookmarks { get; }

        /// <summary></summary>
        IContentScriptsApi ContentScripts { get; }

        /// <summary><br />Requires manifest permission notifications.</summary>
        INotificationsApi Notifications { get; }

        /// <summary><br />Requires manifest permission manifest:optional_permissions.</summary>
        IPermissionsApi Permissions { get; }

        /// <summary>Use the <c>browser.runtime</c> API to retrieve the background page, return details about the manifest, and listen for and respond to events in the app or extension lifecycle. You can also use this API to convert the relative path of URLs to fully-qualified URLs.</summary>
        IRuntimeApi Runtime { get; }

        /// <summary>Use the <c>browser.storage</c> API to store, retrieve, and track changes to user data.<br />Requires manifest permission storage.</summary>
        IStorageApi Storage { get; }

        /// <summary>Use the <c>browser.tabs</c> API to interact with the browser's tab system. You can use this API to create, modify, and rearrange tabs in the browser.</summary>
        ITabsApi Tabs { get; }

        /// <summary>Use the <c>browser.webNavigation</c> API to receive notifications about the status of navigation requests in-flight.<br />Requires manifest permission webNavigation.</summary>
        IWebNavigationApi WebNavigation { get; }

        /// <summary>Use the <c>browser.webRequest</c> API to observe and analyze traffic and to intercept, block, or modify requests in-flight.<br />Requires manifest permission webRequest.</summary>
        IWebRequestApi WebRequest { get; }

        /// <summary>Use the <c>browser.windows</c> API to interact with browser windows. You can use this API to create, modify, and rearrange windows in the browser.</summary>
        IWindowsApi Windows { get; }
    }
}
