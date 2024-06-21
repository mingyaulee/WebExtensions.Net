using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using WebExtensions.Net.ExtensionTypes;
using WebExtensions.Net.Runtime;
using WebExtensions.Net.Windows;

namespace WebExtensions.Net.Tabs
{
    /// <summary>Use the <c>browser.tabs</c> API to interact with the browser's tab system. You can use this API to create, modify, and rearrange tabs in the browser.</summary>
    [JsAccessPath("tabs")]
    public partial interface ITabsApi
    {
        /// <summary>Fires when the active tab in a window changes. Note that the tab's URL may not be set at the time this event fired, but you can listen to onUpdated events to be notified when a URL is set.</summary>
        [JsAccessPath("onActivated")]
        OnActivatedEvent OnActivated { get; }

        /// <summary>Fired when a tab is attached to a window, for example because it was moved between windows.</summary>
        [JsAccessPath("onAttached")]
        OnAttachedEvent OnAttached { get; }

        /// <summary>Fired when a tab is created. Note that the tab's URL may not be set at the time this event fired, but you can listen to onUpdated events to be notified when a URL is set.</summary>
        [JsAccessPath("onCreated")]
        OnCreatedEvent OnCreated { get; }

        /// <summary>Fired when a tab is detached from a window, for example because it is being moved between windows.</summary>
        [JsAccessPath("onDetached")]
        OnDetachedEvent OnDetached { get; }

        /// <summary>Fired when the highlighted or selected tabs in a window changes.</summary>
        [JsAccessPath("onHighlighted")]
        OnHighlightedEvent OnHighlighted { get; }

        /// <summary>Fired when a tab is moved within a window. Only one move event is fired, representing the tab the user directly moved. Move events are not fired for the other tabs that must move in response. This event is not fired when a tab is moved between windows. For that, see $(ref:tabs.onDetached).</summary>
        [JsAccessPath("onMoved")]
        OnMovedEvent OnMoved { get; }

        /// <summary>Fired when a tab is closed.</summary>
        [JsAccessPath("onRemoved")]
        OnRemovedEvent OnRemoved { get; }

        /// <summary>Fired when a tab is replaced with another tab due to prerendering or instant.</summary>
        [JsAccessPath("onReplaced")]
        OnReplacedEvent OnReplaced { get; }

        /// <summary>Fired when a tab is updated.</summary>
        [JsAccessPath("onUpdated")]
        OnUpdatedEvent OnUpdated { get; }

        /// <summary>Fired when a tab is zoomed.</summary>
        [JsAccessPath("onZoomChange")]
        OnZoomChangeEvent OnZoomChange { get; }

        /// <summary>An ID which represents the absence of a browser tab.</summary>
        [JsAccessPath("TAB_ID_NONE")]
        int TAB_ID_NONE { get; }

        /// <summary>Captures an area of a specified tab. You must have $(topic:declare_permissions)[&amp;lt;all_urls&amp;gt;] permission to use this method.</summary>
        /// <param name="tabId">The tab to capture. Defaults to the active tab of the current window.</param>
        /// <param name="options"></param>
        [JsAccessPath("captureTab")]
        ValueTask CaptureTab(int? tabId = null, ImageDetails options = null);

        /// <summary>Captures an area of the currently active tab in the specified window. You must have $(topic:declare_permissions)[&amp;lt;all_urls&amp;gt;] permission to use this method.</summary>
        /// <param name="windowId">The target window. Defaults to the $(topic:current-window)[current window].</param>
        /// <param name="options"></param>
        /// <returns>A data URL which encodes an image of the visible area of the captured tab. May be assigned to the 'src' property of an HTML Image element for display.</returns>
        [JsAccessPath("captureVisibleTab")]
        ValueTask<string> CaptureVisibleTab(int? windowId = null, ImageDetails options = null);

        /// <summary>Connects to the content script(s) in the specified tab. The $(ref:runtime.onConnect) event is fired in each content script running in the specified tab for the current extension. For more details, see $(topic:messaging)[Content Script Messaging].</summary>
        /// <param name="tabId"></param>
        /// <param name="connectInfo"></param>
        /// <returns>A port that can be used to communicate with the content scripts running in the specified tab. The port's $(ref:runtime.Port) event is fired if the tab closes or does not exist. </returns>
        [JsAccessPath("connect")]
        ValueTask<Port> Connect(int tabId, ConnectInfo connectInfo = null);

        /// <summary>Creates a new tab.</summary>
        /// <param name="createProperties"></param>
        /// <returns>Details about the created tab. Will contain the ID of the new tab.</returns>
        [JsAccessPath("create")]
        ValueTask<Tab> Create(CreateProperties createProperties);

        /// <summary>Detects the primary language of the content in a tab.</summary>
        /// <param name="tabId">Defaults to the active tab of the $(topic:current-window)[current window].</param>
        /// <returns>An ISO language code such as <c>en</c> or <c>fr</c>. For a complete list of languages supported by this method, see <see href='http://src.chromium.org/viewvc/chrome/trunk/src/third_party/cld/languages/internal/languages.cc'>kLanguageInfoTable</see>. The 2nd to 4th columns will be checked and the first non-NULL value will be returned except for Simplified Chinese for which zh-CN will be returned. For an unknown language, <c>und</c> will be returned.</returns>
        [JsAccessPath("detectLanguage")]
        ValueTask<string> DetectLanguage(int? tabId = null);

        /// <summary>discards one or more tabs.</summary>
        /// <param name="tabIds">The tab or list of tabs to discard.</param>
        [JsAccessPath("discard")]
        ValueTask Discard(int tabIds);

        /// <summary>discards one or more tabs.</summary>
        /// <param name="tabIds">The tab or list of tabs to discard.</param>
        [JsAccessPath("discard")]
        ValueTask Discard(IEnumerable<int> tabIds);

        /// <summary>Duplicates a tab.</summary>
        /// <param name="tabId">The ID of the tab which is to be duplicated.</param>
        /// <param name="duplicateProperties"></param>
        /// <returns>Details about the duplicated tab. The $(ref:tabs.Tab) object doesn't contain <c>url</c>, <c>title</c> and <c>favIconUrl</c> if the <c>"tabs"</c> permission has not been requested.</returns>
        [JsAccessPath("duplicate")]
        ValueTask<Tab> Duplicate(int tabId, DuplicateProperties duplicateProperties = null);

        /// <summary>Injects JavaScript code into a page. For details, see the $(topic:content_scripts)[programmatic injection] section of the content scripts doc.</summary>
        /// <param name="details">Details of the script to run.</param>
        /// <returns>The result of the script in every injected frame.</returns>
        [JsAccessPath("executeScript")]
        ValueTask<IEnumerable<object>> ExecuteScript(InjectDetails details);

        /// <summary>Injects JavaScript code into a page. For details, see the $(topic:content_scripts)[programmatic injection] section of the content scripts doc.</summary>
        /// <param name="tabId">The ID of the tab in which to run the script; defaults to the active tab of the current window.</param>
        /// <param name="details">Details of the script to run.</param>
        /// <returns>The result of the script in every injected frame.</returns>
        [JsAccessPath("executeScript")]
        ValueTask<IEnumerable<object>> ExecuteScript(int? tabId, InjectDetails details);

        /// <summary>Retrieves details about the specified tab.</summary>
        /// <param name="tabId"></param>
        /// <returns></returns>
        [JsAccessPath("get")]
        ValueTask<Tab> Get(int tabId);

        /// <summary>Gets the tab that this script call is being made from. May be undefined if called from a non-tab context (for example: a background page or popup view).</summary>
        /// <returns></returns>
        [JsAccessPath("getCurrent")]
        ValueTask<Tab> GetCurrent();

        /// <summary>Gets the current zoom factor of a specified tab.</summary>
        /// <param name="tabId">The ID of the tab to get the current zoom factor from; defaults to the active tab of the current window.</param>
        /// <returns>The tab's current zoom factor.</returns>
        [JsAccessPath("getZoom")]
        ValueTask<double> GetZoom(int? tabId = null);

        /// <summary>Gets the current zoom settings of a specified tab.</summary>
        /// <param name="tabId">The ID of the tab to get the current zoom settings from; defaults to the active tab of the current window.</param>
        /// <returns>The tab's current zoom settings.</returns>
        [JsAccessPath("getZoomSettings")]
        ValueTask<ZoomSettings> GetZoomSettings(int? tabId = null);

        /// <summary>Navigate to previous page in tab's history, if available.</summary>
        /// <param name="tabId">The ID of the tab to navigate backward.</param>
        [JsAccessPath("goBack")]
        ValueTask GoBack(int? tabId = null);

        /// <summary>Navigate to next page in tab's history, if available</summary>
        /// <param name="tabId">The ID of the tab to navigate forward.</param>
        [JsAccessPath("goForward")]
        ValueTask GoForward(int? tabId = null);

        /// <summary>Hides one or more tabs. The <c>"tabHide"</c> permission is required to hide tabs.  Not all tabs are hidable.  Returns an array of hidden tabs.</summary>
        /// <param name="tabIds">The TAB ID or list of TAB IDs to hide.</param>
        [JsAccessPath("hide")]
        ValueTask Hide(int tabIds);

        /// <summary>Hides one or more tabs. The <c>"tabHide"</c> permission is required to hide tabs.  Not all tabs are hidable.  Returns an array of hidden tabs.</summary>
        /// <param name="tabIds">The TAB ID or list of TAB IDs to hide.</param>
        [JsAccessPath("hide")]
        ValueTask Hide(IEnumerable<int> tabIds);

        /// <summary>Highlights the given tabs.</summary>
        /// <param name="highlightInfo"></param>
        /// <returns>Contains details about the window whose tabs were highlighted.</returns>
        [JsAccessPath("highlight")]
        ValueTask<Window> Highlight(HighlightHighlightInfo highlightInfo);

        /// <summary>Injects CSS into a page. For details, see the $(topic:content_scripts)[programmatic injection] section of the content scripts doc.</summary>
        /// <param name="details">Details of the CSS text to insert.</param>
        [JsAccessPath("insertCSS")]
        ValueTask InsertCSS(InjectDetails details);

        /// <summary>Injects CSS into a page. For details, see the $(topic:content_scripts)[programmatic injection] section of the content scripts doc.</summary>
        /// <param name="tabId">The ID of the tab in which to insert the CSS; defaults to the active tab of the current window.</param>
        /// <param name="details">Details of the CSS text to insert.</param>
        [JsAccessPath("insertCSS")]
        ValueTask InsertCSS(int? tabId, InjectDetails details);

        /// <summary>Moves one or more tabs to a new position within its window, or to a new window. Note that tabs can only be moved to and from normal (window.type === "normal") windows.</summary>
        /// <param name="tabIds">The tab or list of tabs to move.</param>
        /// <param name="moveProperties"></param>
        /// <returns>Details about the moved tabs.</returns>
        [JsAccessPath("move")]
        ValueTask<CallbackTabs> Move(int tabIds, MoveProperties moveProperties);

        /// <summary>Moves one or more tabs to a new position within its window, or to a new window. Note that tabs can only be moved to and from normal (window.type === "normal") windows.</summary>
        /// <param name="tabIds">The tab or list of tabs to move.</param>
        /// <param name="moveProperties"></param>
        /// <returns>Details about the moved tabs.</returns>
        [JsAccessPath("move")]
        ValueTask<CallbackTabs> Move(IEnumerable<int> tabIds, MoveProperties moveProperties);

        /// <summary>Removes an array of tabs from their lines of succession and prepends or appends them in a chain to another tab.</summary>
        /// <param name="tabIds">An array of tab IDs to move in the line of succession. For each tab in the array, the tab's current predecessors will have their successor set to the tab's current successor, and each tab will then be set to be the successor of the previous tab in the array. Any tabs not in the same window as the tab indicated by the second argument (or the first tab in the array, if no second argument) will be skipped.</param>
        /// <param name="tabId">The ID of a tab to set as the successor of the last tab in the array, or $(ref:tabs.TAB_ID_NONE) to leave the last tab without a successor. If options.append is true, then this tab is made the predecessor of the first tab in the array instead.</param>
        /// <param name="options"></param>
        [JsAccessPath("moveInSuccession")]
        ValueTask MoveInSuccession(IEnumerable<int> tabIds, int? tabId = null, MoveInSuccessionOptions options = null);

        /// <summary>Prints page in active tab.</summary>
        [JsAccessPath("print")]
        ValueTask Print();

        /// <summary>Shows print preview for page in active tab.</summary>
        [JsAccessPath("printPreview")]
        ValueTask PrintPreview();

        /// <summary>Gets all tabs that have the specified properties, or all tabs if no properties are specified.</summary>
        /// <param name="queryInfo"></param>
        /// <returns></returns>
        [JsAccessPath("query")]
        ValueTask<IEnumerable<Tab>> Query(QueryInfo queryInfo);

        /// <summary>Reload a tab.</summary>
        /// <param name="tabId">The ID of the tab to reload; defaults to the selected tab of the current window.</param>
        /// <param name="reloadProperties"></param>
        [JsAccessPath("reload")]
        ValueTask Reload(int? tabId = null, ReloadProperties reloadProperties = null);

        /// <summary>Closes one or more tabs.</summary>
        /// <param name="tabIds">The tab or list of tabs to close.</param>
        [JsAccessPath("remove")]
        ValueTask Remove(int tabIds);

        /// <summary>Closes one or more tabs.</summary>
        /// <param name="tabIds">The tab or list of tabs to close.</param>
        [JsAccessPath("remove")]
        ValueTask Remove(IEnumerable<int> tabIds);

        /// <summary>Removes injected CSS from a page. For details, see the $(topic:content_scripts)[programmatic injection] section of the content scripts doc.</summary>
        /// <param name="details">Details of the CSS text to remove.</param>
        [JsAccessPath("removeCSS")]
        ValueTask RemoveCSS(InjectDetails details);

        /// <summary>Removes injected CSS from a page. For details, see the $(topic:content_scripts)[programmatic injection] section of the content scripts doc.</summary>
        /// <param name="tabId">The ID of the tab from which to remove the injected CSS; defaults to the active tab of the current window.</param>
        /// <param name="details">Details of the CSS text to remove.</param>
        [JsAccessPath("removeCSS")]
        ValueTask RemoveCSS(int? tabId, InjectDetails details);

        /// <summary>Saves page in active tab as a PDF file.</summary>
        /// <param name="pageSettings">The page settings used to save the PDF file.</param>
        /// <returns>Save status: saved, replaced, canceled, not_saved, not_replaced.</returns>
        [JsAccessPath("saveAsPDF")]
        ValueTask<string> SaveAsPDF(PageSettings pageSettings);

        /// <summary>Sends a single message to the content script(s) in the specified tab, with an optional callback to run when a response is sent back.  The $(ref:runtime.onMessage) event is fired in each content script running in the specified tab for the current extension.</summary>
        /// <param name="tabId"></param>
        /// <param name="message"></param>
        /// <param name="options"></param>
        /// <returns>The JSON response object sent by the handler of the message. If an error occurs while connecting to the specified tab, the callback will be called with no arguments and $(ref:runtime.lastError) will be set to the error message.</returns>
        [JsAccessPath("sendMessage")]
        ValueTask<JsonElement> SendMessage(int tabId, object message, SendMessageOptions options = null);

        /// <summary>Zooms a specified tab.</summary>
        /// <param name="zoomFactor">The new zoom factor. Use a value of 0 here to set the tab to its current default zoom factor. Values greater than zero specify a (possibly non-default) zoom factor for the tab.</param>
        [JsAccessPath("setZoom")]
        ValueTask SetZoom(double zoomFactor);

        /// <summary>Zooms a specified tab.</summary>
        /// <param name="tabId">The ID of the tab to zoom; defaults to the active tab of the current window.</param>
        /// <param name="zoomFactor">The new zoom factor. Use a value of 0 here to set the tab to its current default zoom factor. Values greater than zero specify a (possibly non-default) zoom factor for the tab.</param>
        [JsAccessPath("setZoom")]
        ValueTask SetZoom(int? tabId, double zoomFactor);

        /// <summary>Sets the zoom settings for a specified tab, which define how zoom changes are handled. These settings are reset to defaults upon navigating the tab.</summary>
        /// <param name="zoomSettings">Defines how zoom changes are handled and at what scope.</param>
        [JsAccessPath("setZoomSettings")]
        ValueTask SetZoomSettings(ZoomSettings zoomSettings);

        /// <summary>Sets the zoom settings for a specified tab, which define how zoom changes are handled. These settings are reset to defaults upon navigating the tab.</summary>
        /// <param name="tabId">The ID of the tab to change the zoom settings for; defaults to the active tab of the current window.</param>
        /// <param name="zoomSettings">Defines how zoom changes are handled and at what scope.</param>
        [JsAccessPath("setZoomSettings")]
        ValueTask SetZoomSettings(int? tabId, ZoomSettings zoomSettings);

        /// <summary>Shows one or more tabs.</summary>
        /// <param name="tabIds">The TAB ID or list of TAB IDs to show.</param>
        [JsAccessPath("show")]
        ValueTask Show(int tabIds);

        /// <summary>Shows one or more tabs.</summary>
        /// <param name="tabIds">The TAB ID or list of TAB IDs to show.</param>
        [JsAccessPath("show")]
        ValueTask Show(IEnumerable<int> tabIds);

        /// <summary>Toggles reader mode for the document in the tab.</summary>
        /// <param name="tabId">Defaults to the active tab of the $(topic:current-window)[current window].</param>
        [JsAccessPath("toggleReaderMode")]
        ValueTask ToggleReaderMode(int? tabId = null);

        /// <summary>Modifies the properties of a tab. Properties that are not specified in <c>updateProperties</c> are not modified.</summary>
        /// <param name="updateProperties"></param>
        /// <returns>Details about the updated tab. The $(ref:tabs.Tab) object doesn't contain <c>url</c>, <c>title</c> and <c>favIconUrl</c> if the <c>"tabs"</c> permission has not been requested.</returns>
        [JsAccessPath("update")]
        ValueTask<Tab> Update(UpdateProperties updateProperties);

        /// <summary>Modifies the properties of a tab. Properties that are not specified in <c>updateProperties</c> are not modified.</summary>
        /// <param name="tabId">Defaults to the selected tab of the $(topic:current-window)[current window].</param>
        /// <param name="updateProperties"></param>
        /// <returns>Details about the updated tab. The $(ref:tabs.Tab) object doesn't contain <c>url</c>, <c>title</c> and <c>favIconUrl</c> if the <c>"tabs"</c> permission has not been requested.</returns>
        [JsAccessPath("update")]
        ValueTask<Tab> Update(int? tabId, UpdateProperties updateProperties);

        /// <summary>Warm up a tab</summary>
        /// <param name="tabId">The ID of the tab to warm up.</param>
        [JsAccessPath("warmup")]
        ValueTask Warmup(int? tabId = null);
    }
}
