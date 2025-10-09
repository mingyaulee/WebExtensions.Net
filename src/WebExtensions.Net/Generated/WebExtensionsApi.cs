using JsBind.Net;
using WebExtensions.Net.ActionNs;
using WebExtensions.Net.ActivityLog;
using WebExtensions.Net.Alarms;
using WebExtensions.Net.Bookmarks;
using WebExtensions.Net.BrowserAction;
using WebExtensions.Net.BrowserSettings;
using WebExtensions.Net.BrowsingData;
using WebExtensions.Net.CaptivePortal;
using WebExtensions.Net.Clipboard;
using WebExtensions.Net.Commands;
using WebExtensions.Net.ContentScripts;
using WebExtensions.Net.ContextualIdentities;
using WebExtensions.Net.Cookies;
using WebExtensions.Net.DeclarativeNetRequest;
using WebExtensions.Net.Devtools;
using WebExtensions.Net.Dns;
using WebExtensions.Net.Downloads;
using WebExtensions.Net.Extension;
using WebExtensions.Net.Find;
using WebExtensions.Net.GeckoProfiler;
using WebExtensions.Net.History;
using WebExtensions.Net.I18n;
using WebExtensions.Net.Identity;
using WebExtensions.Net.Idle;
using WebExtensions.Net.Management;
using WebExtensions.Net.Menus;
using WebExtensions.Net.NetworkStatus;
using WebExtensions.Net.NormandyAddonStudy;
using WebExtensions.Net.Notifications;
using WebExtensions.Net.Omnibox;
using WebExtensions.Net.PageAction;
using WebExtensions.Net.Permissions;
using WebExtensions.Net.Pkcs11;
using WebExtensions.Net.Privacy;
using WebExtensions.Net.Proxy;
using WebExtensions.Net.Runtime;
using WebExtensions.Net.Scripting;
using WebExtensions.Net.Search;
using WebExtensions.Net.Sessions;
using WebExtensions.Net.SidebarAction;
using WebExtensions.Net.Storage;
using WebExtensions.Net.TabGroups;
using WebExtensions.Net.Tabs;
using WebExtensions.Net.Telemetry;
using WebExtensions.Net.Test;
using WebExtensions.Net.Theme;
using WebExtensions.Net.TopSites;
using WebExtensions.Net.Trial;
using WebExtensions.Net.UserScripts;
using WebExtensions.Net.WebNavigation;
using WebExtensions.Net.WebRequest;
using WebExtensions.Net.Windows;

namespace WebExtensions.Net
{
    /// <summary>Web Extension Api</summary>
    /// <param name="jsRuntime">The JS runtime adapter.</param>
    public partial class WebExtensionsApi(IJsRuntimeAdapter jsRuntime) : BaseApi(jsRuntime, "browser"), IWebExtensionsApi
    {
        private IActionApi _action;
        private IActivityLogApi _activityLog;
        private IAlarmsApi _alarms;
        private IBookmarksApi _bookmarks;
        private IBrowserActionApi _browserAction;
        private IBrowserSettingsApi _browserSettings;
        private IBrowsingDataApi _browsingData;
        private ICaptivePortalApi _captivePortal;
        private IClipboardApi _clipboard;
        private ICommandsApi _commands;
        private IContentScriptsApi _contentScripts;
        private IContextualIdentitiesApi _contextualIdentities;
        private ICookiesApi _cookies;
        private IDeclarativeNetRequestApi _declarativeNetRequest;
        private IDevtoolsApi _devtools;
        private IDnsApi _dns;
        private IDownloadsApi _downloads;
        private IExtensionApi _extension;
        private IFindApi _find;
        private IGeckoProfilerApi _geckoProfiler;
        private IHistoryApi _history;
        private II18nApi _i18n;
        private IIdentityApi _identity;
        private IIdleApi _idle;
        private IManagementApi _management;
        private IMenusApi _menus;
        private INetworkStatusApi _networkStatus;
        private INormandyAddonStudyApi _normandyAddonStudy;
        private INotificationsApi _notifications;
        private IOmniboxApi _omnibox;
        private IPageActionApi _pageAction;
        private IPermissionsApi _permissions;
        private IPkcs11Api _pkcs11;
        private IPrivacyApi _privacy;
        private IProxyApi _proxy;
        private IRuntimeApi _runtime;
        private IScriptingApi _scripting;
        private ISearchApi _search;
        private ISessionsApi _sessions;
        private ISidebarActionApi _sidebarAction;
        private IStorageApi _storage;
        private ITabGroupsApi _tabGroups;
        private ITabsApi _tabs;
        private ITelemetryApi _telemetry;
        private ITestApi _test;
        private IThemeApi _theme;
        private ITopSitesApi _topSites;
        private ITrialApi _trial;
        private IUserScriptsApi _userScripts;
        private IWebNavigationApi _webNavigation;
        private IWebRequestApi _webRequest;
        private IWindowsApi _windows;

        /// <inheritdoc />
        public IActionApi Action => _action ??= new ActionApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IActivityLogApi ActivityLog => _activityLog ??= new ActivityLogApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IAlarmsApi Alarms => _alarms ??= new AlarmsApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IBookmarksApi Bookmarks => _bookmarks ??= new BookmarksApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IBrowserActionApi BrowserAction => _browserAction ??= new BrowserActionApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IBrowserSettingsApi BrowserSettings => _browserSettings ??= new BrowserSettingsApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IBrowsingDataApi BrowsingData => _browsingData ??= new BrowsingDataApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public ICaptivePortalApi CaptivePortal => _captivePortal ??= new CaptivePortalApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IClipboardApi Clipboard => _clipboard ??= new ClipboardApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public ICommandsApi Commands => _commands ??= new CommandsApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IContentScriptsApi ContentScripts => _contentScripts ??= new ContentScriptsApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IContextualIdentitiesApi ContextualIdentities => _contextualIdentities ??= new ContextualIdentitiesApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public ICookiesApi Cookies => _cookies ??= new CookiesApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IDeclarativeNetRequestApi DeclarativeNetRequest => _declarativeNetRequest ??= new DeclarativeNetRequestApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IDevtoolsApi Devtools => _devtools ??= new DevtoolsApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IDnsApi Dns => _dns ??= new DnsApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IDownloadsApi Downloads => _downloads ??= new DownloadsApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IExtensionApi Extension => _extension ??= new ExtensionApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IFindApi Find => _find ??= new FindApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IGeckoProfilerApi GeckoProfiler => _geckoProfiler ??= new GeckoProfilerApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IHistoryApi History => _history ??= new HistoryApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public II18nApi I18n => _i18n ??= new I18nApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IIdentityApi Identity => _identity ??= new IdentityApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IIdleApi Idle => _idle ??= new IdleApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IManagementApi Management => _management ??= new ManagementApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IMenusApi Menus => _menus ??= new MenusApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public INetworkStatusApi NetworkStatus => _networkStatus ??= new NetworkStatusApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public INormandyAddonStudyApi NormandyAddonStudy => _normandyAddonStudy ??= new NormandyAddonStudyApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public INotificationsApi Notifications => _notifications ??= new NotificationsApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IOmniboxApi Omnibox => _omnibox ??= new OmniboxApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IPageActionApi PageAction => _pageAction ??= new PageActionApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IPermissionsApi Permissions => _permissions ??= new PermissionsApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IPkcs11Api Pkcs11 => _pkcs11 ??= new Pkcs11Api(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IPrivacyApi Privacy => _privacy ??= new PrivacyApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IProxyApi Proxy => _proxy ??= new ProxyApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IRuntimeApi Runtime => _runtime ??= new RuntimeApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IScriptingApi Scripting => _scripting ??= new ScriptingApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public ISearchApi Search => _search ??= new SearchApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public ISessionsApi Sessions => _sessions ??= new SessionsApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public ISidebarActionApi SidebarAction => _sidebarAction ??= new SidebarActionApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IStorageApi Storage => _storage ??= new StorageApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public ITabGroupsApi TabGroups => _tabGroups ??= new TabGroupsApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public ITabsApi Tabs => _tabs ??= new TabsApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public ITelemetryApi Telemetry => _telemetry ??= new TelemetryApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public ITestApi Test => _test ??= new TestApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IThemeApi Theme => _theme ??= new ThemeApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public ITopSitesApi TopSites => _topSites ??= new TopSitesApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public ITrialApi Trial => _trial ??= new TrialApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IUserScriptsApi UserScripts => _userScripts ??= new UserScriptsApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IWebNavigationApi WebNavigation => _webNavigation ??= new WebNavigationApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IWebRequestApi WebRequest => _webRequest ??= new WebRequestApi(JsRuntime, AccessPath);

        /// <inheritdoc />
        public IWindowsApi Windows => _windows ??= new WindowsApi(JsRuntime, AccessPath);
    }
}
