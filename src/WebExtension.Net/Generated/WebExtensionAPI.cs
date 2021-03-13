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
    public class WebExtensionAPI : IWebExtensionAPI
    {
        private readonly WebExtensionJSRuntime webExtensionJSRuntime;
        public WebExtensionAPI(WebExtensionJSRuntime webExtensionJSRuntime)
        {
            this.webExtensionJSRuntime = webExtensionJSRuntime;
        }

        
        private ContentScriptsAPI _contentScripts;
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
        
        private WindowsAPI _windows;
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
        
        private TabsAPI _tabs;
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
        
        private NotificationsAPI _notifications;
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
