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
    public partial class WebExtensionsApi : IWebExtensionsApi
    {
        private readonly IWebExtensionsJSRuntime webExtensionsJSRuntime;
        private IAlarmsApi _alarms;
        private IBookmarksApi _bookmarks;
        private IBrowserActionApi _browserAction;
        private IBrowserSettingsApi _browserSettings;
        private IBrowsingDataApi _browsingData;
        private IClipboardApi _clipboard;
        private ICommandsApi _commands;
        private IContentScriptsApi _contentScripts;
        private ICookiesApi _cookies;
        private IDevtoolsApi _devtools;
        private IDownloadsApi _downloads;
        private IExtensionApi _extension;
        private IHistoryApi _history;
        private II18nApi _i18n;
        private IIdentityApi _identity;
        private IIdleApi _idle;
        private IManagementApi _management;
        private IMenusApi _menus;
        private INotificationsApi _notifications;
        private IOmniboxApi _omnibox;
        private IPageActionApi _pageAction;
        private IPermissionsApi _permissions;
        private IPrivacyApi _privacy;
        private IProxyApi _proxy;
        private IRuntimeApi _runtime;
        private ISearchApi _search;
        private ISessionsApi _sessions;
        private IStorageApi _storage;
        private ITabsApi _tabs;
        private ITopSitesApi _topSites;
        private IWebNavigationApi _webNavigation;
        private IWebRequestApi _webRequest;
        private IWindowsApi _windows;

        /// <summary>Creates a new instance of <see cref="WebExtensionsApi" />.</summary>
        public WebExtensionsApi(IWebExtensionsJSRuntime webExtensionsJSRuntime)
        {
            this.webExtensionsJSRuntime = webExtensionsJSRuntime;
        }

        /// <inheritdoc />
        public IAlarmsApi Alarms
        {
            get
            {
                if (_alarms is null)
                {
                    _alarms = new AlarmsApi(webExtensionsJSRuntime);
                }
                return _alarms;
            }
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
        public IBrowserActionApi BrowserAction
        {
            get
            {
                if (_browserAction is null)
                {
                    _browserAction = new BrowserActionApi(webExtensionsJSRuntime);
                }
                return _browserAction;
            }
        }

        /// <inheritdoc />
        public IBrowserSettingsApi BrowserSettings
        {
            get
            {
                if (_browserSettings is null)
                {
                    _browserSettings = new BrowserSettingsApi(webExtensionsJSRuntime);
                }
                return _browserSettings;
            }
        }

        /// <inheritdoc />
        public IBrowsingDataApi BrowsingData
        {
            get
            {
                if (_browsingData is null)
                {
                    _browsingData = new BrowsingDataApi(webExtensionsJSRuntime);
                }
                return _browsingData;
            }
        }

        /// <inheritdoc />
        public IClipboardApi Clipboard
        {
            get
            {
                if (_clipboard is null)
                {
                    _clipboard = new ClipboardApi(webExtensionsJSRuntime);
                }
                return _clipboard;
            }
        }

        /// <inheritdoc />
        public ICommandsApi Commands
        {
            get
            {
                if (_commands is null)
                {
                    _commands = new CommandsApi(webExtensionsJSRuntime);
                }
                return _commands;
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
        public ICookiesApi Cookies
        {
            get
            {
                if (_cookies is null)
                {
                    _cookies = new CookiesApi(webExtensionsJSRuntime);
                }
                return _cookies;
            }
        }

        /// <inheritdoc />
        public IDevtoolsApi Devtools
        {
            get
            {
                if (_devtools is null)
                {
                    _devtools = new DevtoolsApi(webExtensionsJSRuntime);
                }
                return _devtools;
            }
        }

        /// <inheritdoc />
        public IDownloadsApi Downloads
        {
            get
            {
                if (_downloads is null)
                {
                    _downloads = new DownloadsApi(webExtensionsJSRuntime);
                }
                return _downloads;
            }
        }

        /// <inheritdoc />
        public IExtensionApi Extension
        {
            get
            {
                if (_extension is null)
                {
                    _extension = new ExtensionApi(webExtensionsJSRuntime);
                }
                return _extension;
            }
        }

        /// <inheritdoc />
        public IHistoryApi History
        {
            get
            {
                if (_history is null)
                {
                    _history = new HistoryApi(webExtensionsJSRuntime);
                }
                return _history;
            }
        }

        /// <inheritdoc />
        public II18nApi I18n
        {
            get
            {
                if (_i18n is null)
                {
                    _i18n = new I18nApi(webExtensionsJSRuntime);
                }
                return _i18n;
            }
        }

        /// <inheritdoc />
        public IIdentityApi Identity
        {
            get
            {
                if (_identity is null)
                {
                    _identity = new IdentityApi(webExtensionsJSRuntime);
                }
                return _identity;
            }
        }

        /// <inheritdoc />
        public IIdleApi Idle
        {
            get
            {
                if (_idle is null)
                {
                    _idle = new IdleApi(webExtensionsJSRuntime);
                }
                return _idle;
            }
        }

        /// <inheritdoc />
        public IManagementApi Management
        {
            get
            {
                if (_management is null)
                {
                    _management = new ManagementApi(webExtensionsJSRuntime);
                }
                return _management;
            }
        }

        /// <inheritdoc />
        public IMenusApi Menus
        {
            get
            {
                if (_menus is null)
                {
                    _menus = new MenusApi(webExtensionsJSRuntime);
                }
                return _menus;
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
        public IOmniboxApi Omnibox
        {
            get
            {
                if (_omnibox is null)
                {
                    _omnibox = new OmniboxApi(webExtensionsJSRuntime);
                }
                return _omnibox;
            }
        }

        /// <inheritdoc />
        public IPageActionApi PageAction
        {
            get
            {
                if (_pageAction is null)
                {
                    _pageAction = new PageActionApi(webExtensionsJSRuntime);
                }
                return _pageAction;
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
        public IPrivacyApi Privacy
        {
            get
            {
                if (_privacy is null)
                {
                    _privacy = new PrivacyApi(webExtensionsJSRuntime);
                }
                return _privacy;
            }
        }

        /// <inheritdoc />
        public IProxyApi Proxy
        {
            get
            {
                if (_proxy is null)
                {
                    _proxy = new ProxyApi(webExtensionsJSRuntime);
                }
                return _proxy;
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
        public ISearchApi Search
        {
            get
            {
                if (_search is null)
                {
                    _search = new SearchApi(webExtensionsJSRuntime);
                }
                return _search;
            }
        }

        /// <inheritdoc />
        public ISessionsApi Sessions
        {
            get
            {
                if (_sessions is null)
                {
                    _sessions = new SessionsApi(webExtensionsJSRuntime);
                }
                return _sessions;
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
        public ITopSitesApi TopSites
        {
            get
            {
                if (_topSites is null)
                {
                    _topSites = new TopSitesApi(webExtensionsJSRuntime);
                }
                return _topSites;
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
