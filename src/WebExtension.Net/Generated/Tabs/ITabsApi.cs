using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtension.Net.Tabs
{
    /// <summary>
    /// Use the <c>browser.tabs</c> API to interact with the browser's tab system. You can use this API to create, modify, and rearrange tabs in the browser.
    /// </summary>
    public interface ITabsApi
    {
        
        // Property Definition Interface
        /// <summary>
        /// An ID which represents the absence of a browser tab.
        /// </summary>
        int TAB_ID_NONE { get; }
        
        
        // Function Definition Interface
        /// <summary>
        /// Retrieves details about the specified tab.
        /// </summary>
        /// <param name="tabId"></param>
        /// <returns></returns>
        ValueTask<Tab> Get(int tabId);
        
        // Function Definition Interface
        /// <summary>
        /// Gets the tab that this script call is being made from. May be undefined if called from a non-tab context (for example: a background page or popup view).
        /// </summary>
        /// <returns></returns>
        ValueTask<Tab> GetCurrent();
        
        // Function Definition Interface
        /// <summary>
        /// Connects to the content script(s) in the specified tab. The $(ref:runtime.onConnect) event is fired in each content script running in the specified tab for the current extension. For more details, see $(topic:messaging)[Content Script Messaging].
        /// </summary>
        /// <param name="tabId"></param>
        /// <param name="connectInfo"></param>
        /// <returns></returns>
        ValueTask<Runtime.Port> Connect(int tabId, object connectInfo);
        
        // Function Definition Interface
        /// <summary>
        /// Sends a single message to the content script(s) in the specified tab, with an optional callback to run when a response is sent back.  The $(ref:runtime.onMessage) event is fired in each content script running in the specified tab for the current extension.
        /// </summary>
        /// <param name="tabId"></param>
        /// <param name="message"></param>
        /// <param name="options"></param>
        /// <param name="responseCallback"></param>
        ValueTask SendMessage(int tabId, object message, object options, Action responseCallback);
        
        // Function Definition Interface
        /// <summary>
        /// Creates a new tab.
        /// </summary>
        /// <param name="createProperties"></param>
        /// <returns></returns>
        ValueTask<Tab> Create(object createProperties);
        
        // Function Definition Interface
        /// <summary>
        /// Duplicates a tab.
        /// </summary>
        /// <param name="tabId">The ID of the tab which is to be duplicated.</param>
        /// <param name="duplicateProperties"></param>
        /// <returns></returns>
        ValueTask<Tab> Duplicate(int tabId, object duplicateProperties);
        
        // Function Definition Interface
        /// <summary>
        /// Gets all tabs that have the specified properties, or all tabs if no properties are specified.
        /// </summary>
        /// <param name="queryInfo"></param>
        /// <returns></returns>
        ValueTask<IEnumerable<Tab>> Query(object queryInfo);
        
        // Function Definition Interface
        /// <summary>
        /// Highlights the given tabs.
        /// </summary>
        /// <param name="highlightInfo"></param>
        /// <returns></returns>
        ValueTask<Windows.Window> Highlight(object highlightInfo);
        
        // Function Definition Interface
        /// <summary>
        /// Modifies the properties of a tab. Properties that are not specified in <var>updateProperties</var> are not modified.
        /// </summary>
        /// <param name="tabId">Defaults to the selected tab of the $(topic:current-window)[current window].</param>
        /// <param name="updateProperties"></param>
        /// <returns></returns>
        ValueTask<Tab> Update(int? tabId, object updateProperties);
        
        // Function Definition Interface
        /// <summary>
        /// Moves one or more tabs to a new position within its window, or to a new window. Note that tabs can only be moved to and from normal (window.type === "normal") windows.
        /// </summary>
        /// <param name="tabIds">The tab or list of tabs to move.</param>
        /// <param name="moveProperties"></param>
        /// <returns></returns>
        ValueTask<JsonElement> Move(int tabIds, object moveProperties);
        
        // Function Definition Interface
        /// <summary>
        /// Moves one or more tabs to a new position within its window, or to a new window. Note that tabs can only be moved to and from normal (window.type === "normal") windows.
        /// </summary>
        /// <param name="tabIds">The tab or list of tabs to move.</param>
        /// <param name="moveProperties"></param>
        /// <returns></returns>
        ValueTask<JsonElement> Move(IEnumerable<int> tabIds, object moveProperties);
        
        // Function Definition Interface
        /// <summary>
        /// Reload a tab.
        /// </summary>
        /// <param name="tabId">The ID of the tab to reload; defaults to the selected tab of the current window.</param>
        /// <param name="reloadProperties"></param>
        ValueTask Reload(int? tabId, object reloadProperties);
        
        // Function Definition Interface
        /// <summary>
        /// Warm up a tab
        /// </summary>
        /// <param name="tabId">The ID of the tab to warm up.</param>
        ValueTask Warmup(int tabId);
        
        // Function Definition Interface
        /// <summary>
        /// Closes one or more tabs.
        /// </summary>
        /// <param name="tabIds">The tab or list of tabs to close.</param>
        ValueTask Remove(int tabIds);
        
        // Function Definition Interface
        /// <summary>
        /// Closes one or more tabs.
        /// </summary>
        /// <param name="tabIds">The tab or list of tabs to close.</param>
        ValueTask Remove(IEnumerable<int> tabIds);
        
        // Function Definition Interface
        /// <summary>
        /// discards one or more tabs.
        /// </summary>
        /// <param name="tabIds">The tab or list of tabs to discard.</param>
        ValueTask Discard(int tabIds);
        
        // Function Definition Interface
        /// <summary>
        /// discards one or more tabs.
        /// </summary>
        /// <param name="tabIds">The tab or list of tabs to discard.</param>
        ValueTask Discard(IEnumerable<int> tabIds);
        
        // Function Definition Interface
        /// <summary>
        /// Detects the primary language of the content in a tab.
        /// </summary>
        /// <param name="tabId">Defaults to the active tab of the $(topic:current-window)[current window].</param>
        /// <returns></returns>
        ValueTask<string> DetectLanguage(int? tabId);
        
        // Function Definition Interface
        /// <summary>
        /// Toggles reader mode for the document in the tab.
        /// </summary>
        /// <param name="tabId">Defaults to the active tab of the $(topic:current-window)[current window].</param>
        ValueTask ToggleReaderMode(int? tabId);
        
        // Function Definition Interface
        /// <summary>
        /// Captures an area of a specified tab. You must have $(topic:declare_permissions)[&amp;lt;all_urls&amp;gt;] permission to use this method.
        /// </summary>
        /// <param name="tabId">The tab to capture. Defaults to the active tab of the current window.</param>
        /// <param name="options"></param>
        ValueTask CaptureTab(int? tabId, ExtensionTypes.ImageDetails options);
        
        // Function Definition Interface
        /// <summary>
        /// Captures an area of the currently active tab in the specified window. You must have $(topic:declare_permissions)[&amp;lt;all_urls&amp;gt;] permission to use this method.
        /// </summary>
        /// <param name="windowId">The target window. Defaults to the $(topic:current-window)[current window].</param>
        /// <param name="options"></param>
        /// <returns></returns>
        ValueTask<string> CaptureVisibleTab(int? windowId, ExtensionTypes.ImageDetails options);
        
        // Function Definition Interface
        /// <summary>
        /// Injects JavaScript code into a page. For details, see the $(topic:content_scripts)[programmatic injection] section of the content scripts doc.
        /// </summary>
        /// <param name="tabId">The ID of the tab in which to run the script; defaults to the active tab of the current window.</param>
        /// <param name="details">Details of the script to run.</param>
        /// <returns></returns>
        ValueTask<IEnumerable<object>> ExecuteScript(int? tabId, ExtensionTypes.InjectDetails details);
        
        // Function Definition Interface
        /// <summary>
        /// Injects CSS into a page. For details, see the $(topic:content_scripts)[programmatic injection] section of the content scripts doc.
        /// </summary>
        /// <param name="tabId">The ID of the tab in which to insert the CSS; defaults to the active tab of the current window.</param>
        /// <param name="details">Details of the CSS text to insert.</param>
        ValueTask InsertCSS(int? tabId, ExtensionTypes.InjectDetails details);
        
        // Function Definition Interface
        /// <summary>
        /// Removes injected CSS from a page. For details, see the $(topic:content_scripts)[programmatic injection] section of the content scripts doc.
        /// </summary>
        /// <param name="tabId">The ID of the tab from which to remove the injected CSS; defaults to the active tab of the current window.</param>
        /// <param name="details">Details of the CSS text to remove.</param>
        ValueTask RemoveCSS(int? tabId, ExtensionTypes.InjectDetails details);
        
        // Function Definition Interface
        /// <summary>
        /// Zooms a specified tab.
        /// </summary>
        /// <param name="tabId">The ID of the tab to zoom; defaults to the active tab of the current window.</param>
        /// <param name="zoomFactor">The new zoom factor. Use a value of 0 here to set the tab to its current default zoom factor. Values greater than zero specify a (possibly non-default) zoom factor for the tab.</param>
        ValueTask SetZoom(int? tabId, double zoomFactor);
        
        // Function Definition Interface
        /// <summary>
        /// Gets the current zoom factor of a specified tab.
        /// </summary>
        /// <param name="tabId">The ID of the tab to get the current zoom factor from; defaults to the active tab of the current window.</param>
        /// <returns></returns>
        ValueTask<double> GetZoom(int? tabId);
        
        // Function Definition Interface
        /// <summary>
        /// Sets the zoom settings for a specified tab, which define how zoom changes are handled. These settings are reset to defaults upon navigating the tab.
        /// </summary>
        /// <param name="tabId">The ID of the tab to change the zoom settings for; defaults to the active tab of the current window.</param>
        /// <param name="zoomSettings">Defines how zoom changes are handled and at what scope.</param>
        ValueTask SetZoomSettings(int? tabId, ZoomSettings zoomSettings);
        
        // Function Definition Interface
        /// <summary>
        /// Gets the current zoom settings of a specified tab.
        /// </summary>
        /// <param name="tabId">The ID of the tab to get the current zoom settings from; defaults to the active tab of the current window.</param>
        /// <returns></returns>
        ValueTask<ZoomSettings> GetZoomSettings(int? tabId);
        
        // Function Definition Interface
        /// <summary>
        /// Prints page in active tab.
        /// </summary>
        ValueTask Print();
        
        // Function Definition Interface
        /// <summary>
        /// Shows print preview for page in active tab.
        /// </summary>
        ValueTask PrintPreview();
        
        // Function Definition Interface
        /// <summary>
        /// Saves page in active tab as a PDF file.
        /// </summary>
        /// <param name="pageSettings">The page settings used to save the PDF file.</param>
        /// <returns></returns>
        ValueTask<string> SaveAsPDF(PageSettings pageSettings);
        
        // Function Definition Interface
        /// <summary>
        /// Shows one or more tabs.
        /// </summary>
        /// <param name="tabIds">The TAB ID or list of TAB IDs to show.</param>
        ValueTask Show(int tabIds);
        
        // Function Definition Interface
        /// <summary>
        /// Shows one or more tabs.
        /// </summary>
        /// <param name="tabIds">The TAB ID or list of TAB IDs to show.</param>
        ValueTask Show(IEnumerable<int> tabIds);
        
        // Function Definition Interface
        /// <summary>
        /// Hides one or more tabs. The <c>"tabHide"</c> permission is required to hide tabs.  Not all tabs are hidable.  Returns an array of hidden tabs.
        /// </summary>
        /// <param name="tabIds">The TAB ID or list of TAB IDs to hide.</param>
        ValueTask Hide(int tabIds);
        
        // Function Definition Interface
        /// <summary>
        /// Hides one or more tabs. The <c>"tabHide"</c> permission is required to hide tabs.  Not all tabs are hidable.  Returns an array of hidden tabs.
        /// </summary>
        /// <param name="tabIds">The TAB ID or list of TAB IDs to hide.</param>
        ValueTask Hide(IEnumerable<int> tabIds);
        
        // Function Definition Interface
        /// <summary>
        /// Removes an array of tabs from their lines of succession and prepends or appends them in a chain to another tab.
        /// </summary>
        /// <param name="tabIds">An array of tab IDs to move in the line of succession. For each tab in the array, the tab's current predecessors will have their successor set to the tab's current successor, and each tab will then be set to be the successor of the previous tab in the array. Any tabs not in the same window as the tab indicated by the second argument (or the first tab in the array, if no second argument) will be skipped.</param>
        /// <param name="tabId">The ID of a tab to set as the successor of the last tab in the array, or $(ref:tabs.TAB_ID_NONE) to leave the last tab without a successor. If options.append is true, then this tab is made the predecessor of the first tab in the array instead.</param>
        /// <param name="options"></param>
        ValueTask MoveInSuccession(IEnumerable<int> tabIds, int? tabId, object options);
        
        // Function Definition Interface
        /// <summary>
        /// Navigate to next page in tab's history, if available
        /// </summary>
        /// <param name="tabId">The ID of the tab to navigate forward.</param>
        ValueTask GoForward(int? tabId);
        
        // Function Definition Interface
        /// <summary>
        /// Navigate to previous page in tab's history, if available.
        /// </summary>
        /// <param name="tabId">The ID of the tab to navigate backward.</param>
        ValueTask GoBack(int? tabId);
    }
}
