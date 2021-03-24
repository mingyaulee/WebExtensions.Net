// This file is auto generated at 2021-03-24T04:51:22

using WebExtension.Net.Windows;
using WebExtension.Net.ContentScripts;
using WebExtension.Net.Tabs;
using WebExtension.Net.Notifications;
using WebExtension.Net.Runtime;
using WebExtension.Net.WebNavigation;
using WebExtension.Net.WebRequest;

namespace WebExtension.Net
{
    /// <summary>Web Extension API</summary>
    public interface IWebExtensionAPI
    {
        /// <summary>
        /// Use the <c>browser.windows</c> API to interact with browser windows. You can use this API to create, modify, and rearrange windows in the browser.
        /// </summary>
        IWindowsAPI Windows { get; }
        /// <summary>
        /// 
        /// </summary>
        IContentScriptsAPI ContentScripts { get; }
        /// <summary>
        /// Use the <c>browser.tabs</c> API to interact with the browser's tab system. You can use this API to create, modify, and rearrange tabs in the browser.
        /// </summary>
        ITabsAPI Tabs { get; }
        /// <summary>
        /// 
        /// Requires manifest permission notifications.
        /// </summary>
        INotificationsAPI Notifications { get; }
        /// <summary>
        /// Use the <c>browser.runtime</c> API to retrieve the background page, return details about the manifest, and listen for and respond to events in the app or extension lifecycle. You can also use this API to convert the relative path of URLs to fully-qualified URLs.
        /// </summary>
        IRuntimeAPI Runtime { get; }
        /// <summary>
        /// Use the <c>browser.webNavigation</c> API to receive notifications about the status of navigation requests in-flight.
        /// Requires manifest permission webNavigation.
        /// </summary>
        IWebNavigationAPI WebNavigation { get; }
        /// <summary>
        /// Use the <c>browser.webRequest</c> API to observe and analyze traffic and to intercept, block, or modify requests in-flight.
        /// Requires manifest permission webRequest.
        /// </summary>
        IWebRequestAPI WebRequest { get; }
    }
}
