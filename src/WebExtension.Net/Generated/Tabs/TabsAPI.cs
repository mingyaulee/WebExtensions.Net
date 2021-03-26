using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtension.Net.Tabs
{
    /// <inheritdoc />
    public class TabsAPI : BaseAPI, ITabsAPI
    {
        /// <summary>Creates a new instance of TabsAPI.</summary>
        /// <param name="webExtensionJSRuntime">Web Extension JS Runtime</param>
        public TabsAPI(WebExtensionJSRuntime webExtensionJSRuntime) : base(webExtensionJSRuntime, "tabs")
        {
        }

        
        // Property Definition
        private const int _TAB_ID_NONE = -1;
        /// <summary>
        /// An ID which represents the absence of a browser tab.
        /// </summary>
        public int TAB_ID_NONE => _TAB_ID_NONE;
        
        
        // Function Definition
        /// <summary>
        /// Retrieves details about the specified tab.
        /// </summary>
        /// <param name="tabId"></param>
        /// <returns></returns>
        public virtual ValueTask<Tab> Get(int tabId)
        {
            return InvokeAsync<Tab>("get", tabId);
        }
        
        // Function Definition
        /// <summary>
        /// Gets the tab that this script call is being made from. May be undefined if called from a non-tab context (for example: a background page or popup view).
        /// </summary>
        /// <returns></returns>
        public virtual ValueTask<Tab> GetCurrent()
        {
            return InvokeAsync<Tab>("getCurrent");
        }
        
        // Function Definition
        /// <summary>
        /// Connects to the content script(s) in the specified tab. The $(ref:runtime.onConnect) event is fired in each content script running in the specified tab for the current extension. For more details, see $(topic:messaging)[Content Script Messaging].
        /// </summary>
        /// <param name="tabId"></param>
        /// <param name="connectInfo"></param>
        /// <returns></returns>
        public virtual ValueTask<Runtime.Port> Connect(int tabId, object connectInfo)
        {
            return InvokeAsync<Runtime.Port>("connect", tabId, connectInfo);
        }
        
        // Function Definition
        /// <summary>
        /// Sends a single message to the content script(s) in the specified tab, with an optional callback to run when a response is sent back.  The $(ref:runtime.onMessage) event is fired in each content script running in the specified tab for the current extension.
        /// </summary>
        /// <param name="tabId"></param>
        /// <param name="message"></param>
        /// <param name="options"></param>
        /// <param name="responseCallback"></param>
        public virtual ValueTask SendMessage(int tabId, object message, object options, Action responseCallback)
        {
            return InvokeVoidAsync("sendMessage", tabId, message, options, responseCallback);
        }
        
        // Function Definition
        /// <summary>
        /// Creates a new tab.
        /// </summary>
        /// <param name="createProperties"></param>
        /// <returns></returns>
        public virtual ValueTask<Tab> Create(object createProperties)
        {
            return InvokeAsync<Tab>("create", createProperties);
        }
        
        // Function Definition
        /// <summary>
        /// Duplicates a tab.
        /// </summary>
        /// <param name="tabId">The ID of the tab which is to be duplicated.</param>
        /// <param name="duplicateProperties"></param>
        /// <returns></returns>
        public virtual ValueTask<Tab> Duplicate(int tabId, object duplicateProperties)
        {
            return InvokeAsync<Tab>("duplicate", tabId, duplicateProperties);
        }
        
        // Function Definition
        /// <summary>
        /// Gets all tabs that have the specified properties, or all tabs if no properties are specified.
        /// </summary>
        /// <param name="queryInfo"></param>
        /// <returns></returns>
        public virtual ValueTask<IEnumerable<Tab>> Query(object queryInfo)
        {
            return InvokeAsync<IEnumerable<Tab>>("query", queryInfo);
        }
        
        // Function Definition
        /// <summary>
        /// Highlights the given tabs.
        /// </summary>
        /// <param name="highlightInfo"></param>
        /// <returns></returns>
        public virtual ValueTask<Windows.Window> Highlight(object highlightInfo)
        {
            return InvokeAsync<Windows.Window>("highlight", highlightInfo);
        }
        
        // Function Definition
        /// <summary>
        /// Modifies the properties of a tab. Properties that are not specified in <var>updateProperties</var> are not modified.
        /// </summary>
        /// <param name="tabId">Defaults to the selected tab of the $(topic:current-window)[current window].</param>
        /// <param name="updateProperties"></param>
        /// <returns></returns>
        public virtual ValueTask<Tab> Update(int? tabId, object updateProperties)
        {
            return InvokeAsync<Tab>("update", tabId, updateProperties);
        }
        
        // Function Definition
        /// <summary>
        /// Moves one or more tabs to a new position within its window, or to a new window. Note that tabs can only be moved to and from normal (window.type === "normal") windows.
        /// </summary>
        /// <param name="tabIds">The tab or list of tabs to move.</param>
        /// <param name="moveProperties"></param>
        /// <returns></returns>
        public virtual ValueTask<JsonElement> Move(int tabIds, object moveProperties)
        {
            return InvokeAsync<JsonElement>("move", tabIds, moveProperties);
        }
        
        // Function Definition
        /// <summary>
        /// Moves one or more tabs to a new position within its window, or to a new window. Note that tabs can only be moved to and from normal (window.type === "normal") windows.
        /// </summary>
        /// <param name="tabIds">The tab or list of tabs to move.</param>
        /// <param name="moveProperties"></param>
        /// <returns></returns>
        public virtual ValueTask<JsonElement> Move(IEnumerable<int> tabIds, object moveProperties)
        {
            return InvokeAsync<JsonElement>("move", tabIds, moveProperties);
        }
        
        // Function Definition
        /// <summary>
        /// Reload a tab.
        /// </summary>
        /// <param name="tabId">The ID of the tab to reload; defaults to the selected tab of the current window.</param>
        /// <param name="reloadProperties"></param>
        public virtual ValueTask Reload(int? tabId, object reloadProperties)
        {
            return InvokeVoidAsync("reload", tabId, reloadProperties);
        }
        
        // Function Definition
        /// <summary>
        /// Warm up a tab
        /// </summary>
        /// <param name="tabId">The ID of the tab to warm up.</param>
        public virtual ValueTask Warmup(int tabId)
        {
            return InvokeVoidAsync("warmup", tabId);
        }
        
        // Function Definition
        /// <summary>
        /// Closes one or more tabs.
        /// </summary>
        /// <param name="tabIds">The tab or list of tabs to close.</param>
        public virtual ValueTask Remove(int tabIds)
        {
            return InvokeVoidAsync("remove", tabIds);
        }
        
        // Function Definition
        /// <summary>
        /// Closes one or more tabs.
        /// </summary>
        /// <param name="tabIds">The tab or list of tabs to close.</param>
        public virtual ValueTask Remove(IEnumerable<int> tabIds)
        {
            return InvokeVoidAsync("remove", tabIds);
        }
        
        // Function Definition
        /// <summary>
        /// discards one or more tabs.
        /// </summary>
        /// <param name="tabIds">The tab or list of tabs to discard.</param>
        public virtual ValueTask Discard(int tabIds)
        {
            return InvokeVoidAsync("discard", tabIds);
        }
        
        // Function Definition
        /// <summary>
        /// discards one or more tabs.
        /// </summary>
        /// <param name="tabIds">The tab or list of tabs to discard.</param>
        public virtual ValueTask Discard(IEnumerable<int> tabIds)
        {
            return InvokeVoidAsync("discard", tabIds);
        }
        
        // Function Definition
        /// <summary>
        /// Detects the primary language of the content in a tab.
        /// </summary>
        /// <param name="tabId">Defaults to the active tab of the $(topic:current-window)[current window].</param>
        /// <returns></returns>
        public virtual ValueTask<string> DetectLanguage(int? tabId)
        {
            return InvokeAsync<string>("detectLanguage", tabId);
        }
        
        // Function Definition
        /// <summary>
        /// Toggles reader mode for the document in the tab.
        /// </summary>
        /// <param name="tabId">Defaults to the active tab of the $(topic:current-window)[current window].</param>
        public virtual ValueTask ToggleReaderMode(int? tabId)
        {
            return InvokeVoidAsync("toggleReaderMode", tabId);
        }
        
        // Function Definition
        /// <summary>
        /// Captures an area of a specified tab. You must have $(topic:declare_permissions)[&amp;lt;all_urls&amp;gt;] permission to use this method.
        /// </summary>
        /// <param name="tabId">The tab to capture. Defaults to the active tab of the current window.</param>
        /// <param name="options"></param>
        public virtual ValueTask CaptureTab(int? tabId, ExtensionTypes.ImageDetails options)
        {
            return InvokeVoidAsync("captureTab", tabId, options);
        }
        
        // Function Definition
        /// <summary>
        /// Captures an area of the currently active tab in the specified window. You must have $(topic:declare_permissions)[&amp;lt;all_urls&amp;gt;] permission to use this method.
        /// </summary>
        /// <param name="windowId">The target window. Defaults to the $(topic:current-window)[current window].</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public virtual ValueTask<string> CaptureVisibleTab(int? windowId, ExtensionTypes.ImageDetails options)
        {
            return InvokeAsync<string>("captureVisibleTab", windowId, options);
        }
        
        // Function Definition
        /// <summary>
        /// Injects JavaScript code into a page. For details, see the $(topic:content_scripts)[programmatic injection] section of the content scripts doc.
        /// </summary>
        /// <param name="tabId">The ID of the tab in which to run the script; defaults to the active tab of the current window.</param>
        /// <param name="details">Details of the script to run.</param>
        /// <returns></returns>
        public virtual ValueTask<IEnumerable<object>> ExecuteScript(int? tabId, ExtensionTypes.InjectDetails details)
        {
            return InvokeAsync<IEnumerable<object>>("executeScript", tabId, details);
        }
        
        // Function Definition
        /// <summary>
        /// Injects CSS into a page. For details, see the $(topic:content_scripts)[programmatic injection] section of the content scripts doc.
        /// </summary>
        /// <param name="tabId">The ID of the tab in which to insert the CSS; defaults to the active tab of the current window.</param>
        /// <param name="details">Details of the CSS text to insert.</param>
        public virtual ValueTask InsertCSS(int? tabId, ExtensionTypes.InjectDetails details)
        {
            return InvokeVoidAsync("insertCSS", tabId, details);
        }
        
        // Function Definition
        /// <summary>
        /// Removes injected CSS from a page. For details, see the $(topic:content_scripts)[programmatic injection] section of the content scripts doc.
        /// </summary>
        /// <param name="tabId">The ID of the tab from which to remove the injected CSS; defaults to the active tab of the current window.</param>
        /// <param name="details">Details of the CSS text to remove.</param>
        public virtual ValueTask RemoveCSS(int? tabId, ExtensionTypes.InjectDetails details)
        {
            return InvokeVoidAsync("removeCSS", tabId, details);
        }
        
        // Function Definition
        /// <summary>
        /// Zooms a specified tab.
        /// </summary>
        /// <param name="tabId">The ID of the tab to zoom; defaults to the active tab of the current window.</param>
        /// <param name="zoomFactor">The new zoom factor. Use a value of 0 here to set the tab to its current default zoom factor. Values greater than zero specify a (possibly non-default) zoom factor for the tab.</param>
        public virtual ValueTask SetZoom(int? tabId, double zoomFactor)
        {
            return InvokeVoidAsync("setZoom", tabId, zoomFactor);
        }
        
        // Function Definition
        /// <summary>
        /// Gets the current zoom factor of a specified tab.
        /// </summary>
        /// <param name="tabId">The ID of the tab to get the current zoom factor from; defaults to the active tab of the current window.</param>
        /// <returns></returns>
        public virtual ValueTask<double> GetZoom(int? tabId)
        {
            return InvokeAsync<double>("getZoom", tabId);
        }
        
        // Function Definition
        /// <summary>
        /// Sets the zoom settings for a specified tab, which define how zoom changes are handled. These settings are reset to defaults upon navigating the tab.
        /// </summary>
        /// <param name="tabId">The ID of the tab to change the zoom settings for; defaults to the active tab of the current window.</param>
        /// <param name="zoomSettings">Defines how zoom changes are handled and at what scope.</param>
        public virtual ValueTask SetZoomSettings(int? tabId, ZoomSettings zoomSettings)
        {
            return InvokeVoidAsync("setZoomSettings", tabId, zoomSettings);
        }
        
        // Function Definition
        /// <summary>
        /// Gets the current zoom settings of a specified tab.
        /// </summary>
        /// <param name="tabId">The ID of the tab to get the current zoom settings from; defaults to the active tab of the current window.</param>
        /// <returns></returns>
        public virtual ValueTask<ZoomSettings> GetZoomSettings(int? tabId)
        {
            return InvokeAsync<ZoomSettings>("getZoomSettings", tabId);
        }
        
        // Function Definition
        /// <summary>
        /// Prints page in active tab.
        /// </summary>
        public virtual ValueTask Print()
        {
            return InvokeVoidAsync("print");
        }
        
        // Function Definition
        /// <summary>
        /// Shows print preview for page in active tab.
        /// </summary>
        public virtual ValueTask PrintPreview()
        {
            return InvokeVoidAsync("printPreview");
        }
        
        // Function Definition
        /// <summary>
        /// Saves page in active tab as a PDF file.
        /// </summary>
        /// <param name="pageSettings">The page settings used to save the PDF file.</param>
        /// <returns></returns>
        public virtual ValueTask<string> SaveAsPDF(PageSettings pageSettings)
        {
            return InvokeAsync<string>("saveAsPDF", pageSettings);
        }
        
        // Function Definition
        /// <summary>
        /// Shows one or more tabs.
        /// </summary>
        /// <param name="tabIds">The TAB ID or list of TAB IDs to show.</param>
        public virtual ValueTask Show(int tabIds)
        {
            return InvokeVoidAsync("show", tabIds);
        }
        
        // Function Definition
        /// <summary>
        /// Shows one or more tabs.
        /// </summary>
        /// <param name="tabIds">The TAB ID or list of TAB IDs to show.</param>
        public virtual ValueTask Show(IEnumerable<int> tabIds)
        {
            return InvokeVoidAsync("show", tabIds);
        }
        
        // Function Definition
        /// <summary>
        /// Hides one or more tabs. The <c>"tabHide"</c> permission is required to hide tabs.  Not all tabs are hidable.  Returns an array of hidden tabs.
        /// </summary>
        /// <param name="tabIds">The TAB ID or list of TAB IDs to hide.</param>
        public virtual ValueTask Hide(int tabIds)
        {
            return InvokeVoidAsync("hide", tabIds);
        }
        
        // Function Definition
        /// <summary>
        /// Hides one or more tabs. The <c>"tabHide"</c> permission is required to hide tabs.  Not all tabs are hidable.  Returns an array of hidden tabs.
        /// </summary>
        /// <param name="tabIds">The TAB ID or list of TAB IDs to hide.</param>
        public virtual ValueTask Hide(IEnumerable<int> tabIds)
        {
            return InvokeVoidAsync("hide", tabIds);
        }
        
        // Function Definition
        /// <summary>
        /// Removes an array of tabs from their lines of succession and prepends or appends them in a chain to another tab.
        /// </summary>
        /// <param name="tabIds">An array of tab IDs to move in the line of succession. For each tab in the array, the tab's current predecessors will have their successor set to the tab's current successor, and each tab will then be set to be the successor of the previous tab in the array. Any tabs not in the same window as the tab indicated by the second argument (or the first tab in the array, if no second argument) will be skipped.</param>
        /// <param name="tabId">The ID of a tab to set as the successor of the last tab in the array, or $(ref:tabs.TAB_ID_NONE) to leave the last tab without a successor. If options.append is true, then this tab is made the predecessor of the first tab in the array instead.</param>
        /// <param name="options"></param>
        public virtual ValueTask MoveInSuccession(IEnumerable<int> tabIds, int? tabId, object options)
        {
            return InvokeVoidAsync("moveInSuccession", tabIds, tabId, options);
        }
        
        // Function Definition
        /// <summary>
        /// Navigate to next page in tab's history, if available
        /// </summary>
        /// <param name="tabId">The ID of the tab to navigate forward.</param>
        public virtual ValueTask GoForward(int? tabId)
        {
            return InvokeVoidAsync("goForward", tabId);
        }
        
        // Function Definition
        /// <summary>
        /// Navigate to previous page in tab's history, if available.
        /// </summary>
        /// <param name="tabId">The ID of the tab to navigate backward.</param>
        public virtual ValueTask GoBack(int? tabId)
        {
            return InvokeVoidAsync("goBack", tabId);
        }
    }
}
