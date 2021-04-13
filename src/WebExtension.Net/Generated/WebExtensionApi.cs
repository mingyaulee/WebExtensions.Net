using WebExtension.Net.ContentScripts;
using WebExtension.Net.Notifications;
using WebExtension.Net.Runtime;
using WebExtension.Net.Storage;
using WebExtension.Net.Tabs;
using WebExtension.Net.WebNavigation;
using WebExtension.Net.WebRequest;
using WebExtension.Net.Windows;

namespace WebExtension.Net
{
    /// <summary>Web Extension Api</summary>
    public class WebExtensionApi : IWebExtensionApi
    {
        private readonly WebExtensionJSRuntime webExtensionJSRuntime;
        private IContentScriptsApi _contentScripts;
        private INotificationsApi _notifications;
        private IRuntimeApi _runtime;
        private IStorageApi _storage;
        private ITabsApi _tabs;
        private IWebNavigationApi _webNavigation;
        private IWebRequestApi _webRequest;
        private IWindowsApi _windows;

        /// <summary>Creates a new instance of <see cref="WebExtensionApi" />.</summary>
        public WebExtensionApi(WebExtensionJSRuntime webExtensionJSRuntime)
        {
            this.webExtensionJSRuntime = webExtensionJSRuntime;
        }

        /// <inheritdoc />
        public IContentScriptsApi ContentScripts
        {
            get
            {
                if (_contentScripts is null)
                {
                    _contentScripts = new ContentScriptsApi(webExtensionJSRuntime);
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
                    _notifications = new NotificationsApi(webExtensionJSRuntime);
                }
                return _notifications;
            }
        }

        /// <inheritdoc />
        public IRuntimeApi Runtime
        {
            get
            {
                if (_runtime is null)
                {
                    _runtime = new RuntimeApi(webExtensionJSRuntime);
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
                    _storage = new StorageApi(webExtensionJSRuntime);
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
                    _tabs = new TabsApi(webExtensionJSRuntime);
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
                    _webNavigation = new WebNavigationApi(webExtensionJSRuntime);
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
                    _webRequest = new WebRequestApi(webExtensionJSRuntime);
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
                    _windows = new WindowsApi(webExtensionJSRuntime);
                }
                return _windows;
            }
        }
    }
}
