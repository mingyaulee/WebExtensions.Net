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
    /// <inheritdoc />
    public class WebExtensionApi : IWebExtensionApi
    {
        private readonly WebExtensionJSRuntime webExtensionJSRuntime;
        /// <summary>Creates a new instance of WebExtensionApi.</summary>
        public WebExtensionApi(WebExtensionJSRuntime webExtensionJSRuntime)
        {
            this.webExtensionJSRuntime = webExtensionJSRuntime;
        }

        
        private ContentScriptsApi _contentScripts;
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
        
        private NotificationsApi _notifications;
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
        
        private RuntimeApi _runtime;
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
        
        private StorageApi _storage;
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
        
        private TabsApi _tabs;
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
        
        private WebNavigationApi _webNavigation;
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
        
        private WebRequestApi _webRequest;
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
        
        private WindowsApi _windows;
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
