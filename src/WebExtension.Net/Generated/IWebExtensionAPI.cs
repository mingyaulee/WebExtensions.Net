/// This file is auto generated at 2021-03-19T09:46:29

using WebExtension.Net.ContentScripts;
using WebExtension.Net.Windows;
using WebExtension.Net.Tabs;
using WebExtension.Net.Runtime;
using WebExtension.Net.WebNavigation;
using WebExtension.Net.Notifications;
using WebExtension.Net.WebRequest;

namespace WebExtension.Net
{
    public interface IWebExtensionAPI
    {
        /// <summary></summary>
        IContentScriptsAPI ContentScripts { get; }
        /// <summary>Use the <code>browser.windows</code> API to interact with browser windows. You can use this API to create, modify, and rearrange windows in the browser.</summary>
        IWindowsAPI Windows { get; }
        /// <summary>Use the <code>browser.tabs</code> API to interact with the browser's tab system. You can use this API to create, modify, and rearrange tabs in the browser.</summary>
        ITabsAPI Tabs { get; }
        /// <summary>Use the <code>browser.runtime</code> API to retrieve the background page, return details about the manifest, and listen for and respond to events in the app or extension lifecycle. You can also use this API to convert the relative path of URLs to fully-qualified URLs.</summary>
        IRuntimeAPI Runtime { get; }
        /// <summary>Use the <code>browser.webNavigation</code> API to receive notifications about the status of navigation requests in-flight.</summary>
        IWebNavigationAPI WebNavigation { get; }
        /// <summary></summary>
        INotificationsAPI Notifications { get; }
        /// <summary>Use the <code>browser.webRequest</code> API to observe and analyze traffic and to intercept, block, or modify requests in-flight.</summary>
        IWebRequestAPI WebRequest { get; }
    }
}
