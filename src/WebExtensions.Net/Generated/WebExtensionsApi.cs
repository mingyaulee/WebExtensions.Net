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
    public partial class WebExtensionsApi : IWebExtensionsApi
    {
        private readonly IWebExtensionsJSRuntime webExtensionsJSRuntime;
        private IBookmarksApi _bookmarks;
        private IContentScriptsApi _contentScripts;
        private INotificationsApi _notifications;
        private IPermissionsApi _permissions;
        private IRuntimeApi _runtime;
        private IStorageApi _storage;
        private ITabsApi _tabs;
        private IWebNavigationApi _webNavigation;
        private IWebRequestApi _webRequest;
        private IWindowsApi _windows;

        /// <summary>Creates a new instance of <see cref="WebExtensionsApi" />.</summary>
        public WebExtensionsApi(IWebExtensionsJSRuntime webExtensionsJSRuntime)
        {
            this.webExtensionsJSRuntime = webExtensionsJSRuntime;
        }

        /// <inheritdoc />
        public IBookmarksApi Bookmarks
        {
            get
            {
                if (_bookmarks is null)
                {
                    _bookmarks = new BookmarksApi(webExtensionsJSRuntime);
                }
                return _bookmarks;
            }
        }

        /// <inheritdoc />
        public IContentScriptsApi ContentScripts
        {
            get
            {
                if (_contentScripts is null)
                {
                    _contentScripts = new ContentScriptsApi(webExtensionsJSRuntime);
                }
                return _contentScripts;
            }
        }

        /// <inheritdoc />
        public INotificationsApi Notifications
        {
            get
            {
                if (_notifications is null)
                {
                    _notifications = new NotificationsApi(webExtensionsJSRuntime);
                }
                return _notifications;
            }
        }

        /// <inheritdoc />
        public IPermissionsApi Permissions
        {
            get
            {
                if (_permissions is null)
                {
                    _permissions = new PermissionsApi(webExtensionsJSRuntime);
                }
                return _permissions;
            }
        }

        /// <inheritdoc />
        public IRuntimeApi Runtime
        {
            get
            {
                if (_runtime is null)
                {
                    _runtime = new RuntimeApi(webExtensionsJSRuntime);
                }
                return _runtime;
            }
        }

        /// <inheritdoc />
        public IStorageApi Storage
        {
            get
            {
                if (_storage is null)
                {
                    _storage = new StorageApi(webExtensionsJSRuntime);
                }
                return _storage;
            }
        }

        /// <inheritdoc />
        public ITabsApi Tabs
        {
            get
            {
                if (_tabs is null)
                {
                    _tabs = new TabsApi(webExtensionsJSRuntime);
                }
                return _tabs;
            }
        }

        /// <inheritdoc />
        public IWebNavigationApi WebNavigation
        {
            get
            {
                if (_webNavigation is null)
                {
                    _webNavigation = new WebNavigationApi(webExtensionsJSRuntime);
                }
                return _webNavigation;
            }
        }

        /// <inheritdoc />
        public IWebRequestApi WebRequest
        {
            get
            {
                if (_webRequest is null)
                {
                    _webRequest = new WebRequestApi(webExtensionsJSRuntime);
                }
                return _webRequest;
            }
        }

        /// <inheritdoc />
        public IWindowsApi Windows
        {
            get
            {
                if (_windows is null)
                {
                    _windows = new WindowsApi(webExtensionsJSRuntime);
                }
                return _windows;
            }
        }
    }
}
