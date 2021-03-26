using WebExtension.Net.Windows;
using WebExtension.Net.ContentScripts;
using WebExtension.Net.Tabs;
using WebExtension.Net.Runtime;
using WebExtension.Net.WebNavigation;
using WebExtension.Net.Storage;
using WebExtension.Net.Notifications;
using WebExtension.Net.WebRequest;

namespace WebExtension.Net
{
    /// <inheritdoc />
    public class WebExtensionAPI : IWebExtensionAPI
    {
        private readonly WebExtensionJSRuntime webExtensionJSRuntime;
        /// <summary>Creates a new instance of WebExtensionAPI.</summary>
        public WebExtensionAPI(WebExtensionJSRuntime webExtensionJSRuntime)
        {
            this.webExtensionJSRuntime = webExtensionJSRuntime;
        }

        
        private WindowsAPI _windows;
        /// <inheritdoc />
        public IWindowsAPI Windows
        {
            get
            {
                if (_windows is null)
                {
                    _windows = new WindowsAPI(webExtensionJSRuntime);
                }
                return _windows;
            }
        }
        
        private ContentScriptsAPI _contentScripts;
        /// <inheritdoc />
        public IContentScriptsAPI ContentScripts
        {
            get
            {
                if (_contentScripts is null)
                {
                    _contentScripts = new ContentScriptsAPI(webExtensionJSRuntime);
                }
                return _contentScripts;
            }
        }
        
        private TabsAPI _tabs;
        /// <inheritdoc />
        public ITabsAPI Tabs
        {
            get
            {
                if (_tabs is null)
                {
                    _tabs = new TabsAPI(webExtensionJSRuntime);
                }
                return _tabs;
            }
        }
        
        private RuntimeAPI _runtime;
        /// <inheritdoc />
        public IRuntimeAPI Runtime
        {
            get
            {
                if (_runtime is null)
                {
                    _runtime = new RuntimeAPI(webExtensionJSRuntime);
                }
                return _runtime;
            }
        }
        
        private WebNavigationAPI _webNavigation;
        /// <inheritdoc />
        public IWebNavigationAPI WebNavigation
        {
            get
            {
                if (_webNavigation is null)
                {
                    _webNavigation = new WebNavigationAPI(webExtensionJSRuntime);
                }
                return _webNavigation;
            }
        }
        
        private StorageAPI _storage;
        /// <inheritdoc />
        public IStorageAPI Storage
        {
            get
            {
                if (_storage is null)
                {
                    _storage = new StorageAPI(webExtensionJSRuntime);
                }
                return _storage;
            }
        }
        
        private NotificationsAPI _notifications;
        /// <inheritdoc />
        public INotificationsAPI Notifications
        {
            get
            {
                if (_notifications is null)
                {
                    _notifications = new NotificationsAPI(webExtensionJSRuntime);
                }
                return _notifications;
            }
        }
        
        private WebRequestAPI _webRequest;
        /// <inheritdoc />
        public IWebRequestAPI WebRequest
        {
            get
            {
                if (_webRequest is null)
                {
                    _webRequest = new WebRequestAPI(webExtensionJSRuntime);
                }
                return _webRequest;
            }
        }
    }
}
