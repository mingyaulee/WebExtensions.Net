using JsBind.Net;
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
    public partial class WebExtensionsApi : BaseApi, IWebExtensionsApi
    {
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
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        public WebExtensionsApi(IJsRuntimeAdapter jsRuntime) : base(jsRuntime, "browser")
        {
        }

        /// <inheritdoc />
        public IAlarmsApi Alarms
        {
            get
            {
                if (_alarms is null)
                {
                    _alarms = new AlarmsApi(JsRuntime, AccessPath);
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
                    _bookmarks = new BookmarksApi(JsRuntime, AccessPath);
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
                    _browserAction = new BrowserActionApi(JsRuntime, AccessPath);
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
                    _browserSettings = new BrowserSettingsApi(JsRuntime, AccessPath);
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
                    _browsingData = new BrowsingDataApi(JsRuntime, AccessPath);
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
                    _clipboard = new ClipboardApi(JsRuntime, AccessPath);
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
                    _commands = new CommandsApi(JsRuntime, AccessPath);
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
                    _contentScripts = new ContentScriptsApi(JsRuntime, AccessPath);
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
                    _cookies = new CookiesApi(JsRuntime, AccessPath);
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
                    _devtools = new DevtoolsApi(JsRuntime, AccessPath);
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
                    _downloads = new DownloadsApi(JsRuntime, AccessPath);
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
                    _extension = new ExtensionApi(JsRuntime, AccessPath);
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
                    _history = new HistoryApi(JsRuntime, AccessPath);
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
                    _i18n = new I18nApi(JsRuntime, AccessPath);
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
                    _identity = new IdentityApi(JsRuntime, AccessPath);
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
                    _idle = new IdleApi(JsRuntime, AccessPath);
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
                    _management = new ManagementApi(JsRuntime, AccessPath);
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
                    _menus = new MenusApi(JsRuntime, AccessPath);
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
                    _notifications = new NotificationsApi(JsRuntime, AccessPath);
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
                    _omnibox = new OmniboxApi(JsRuntime, AccessPath);
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
                    _pageAction = new PageActionApi(JsRuntime, AccessPath);
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
                    _permissions = new PermissionsApi(JsRuntime, AccessPath);
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
                    _privacy = new PrivacyApi(JsRuntime, AccessPath);
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
                    _proxy = new ProxyApi(JsRuntime, AccessPath);
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
                    _runtime = new RuntimeApi(JsRuntime, AccessPath);
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
                    _search = new SearchApi(JsRuntime, AccessPath);
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
                    _sessions = new SessionsApi(JsRuntime, AccessPath);
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
                    _storage = new StorageApi(JsRuntime, AccessPath);
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
                    _tabs = new TabsApi(JsRuntime, AccessPath);
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
                    _topSites = new TopSitesApi(JsRuntime, AccessPath);
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
                    _webNavigation = new WebNavigationApi(JsRuntime, AccessPath);
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
                    _webRequest = new WebRequestApi(JsRuntime, AccessPath);
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
                    _windows = new WindowsApi(JsRuntime, AccessPath);
                }
                return _windows;
            }
        }
    }
}
