using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using WebExtension.Net.ExtensionTypes;
using WebExtension.Net.Runtime;
using WebExtension.Net.Windows;

namespace WebExtension.Net.Tabs
{
    /// <inheritdoc />
    public class TabsApi : BaseApi, ITabsApi
    {
        /// <summary>Creates a new instance of <see cref="TabsApi" />.</summary>
        /// <param name="webExtensionJSRuntime">Web Extension JS Runtime</param>
        public TabsApi(WebExtensionJSRuntime webExtensionJSRuntime) : base(webExtensionJSRuntime, "tabs")
        {
        }

        /// <inheritdoc />
        public int TAB_ID_NONE => -1;

        /// <inheritdoc />
        public virtual ValueTask CaptureTab(int tabId, ImageDetails options)
        {
            return InvokeVoidAsync("captureTab", tabId, options);
        }

        /// <inheritdoc />
        public virtual ValueTask<string> CaptureVisibleTab(int windowId, ImageDetails options)
        {
            return InvokeAsync<string>("captureVisibleTab", windowId, options);
        }

        /// <inheritdoc />
        public virtual ValueTask<Port> Connect(int tabId, object connectInfo)
        {
            return InvokeAsync<Port>("connect", tabId, connectInfo);
        }

        /// <inheritdoc />
        public virtual ValueTask<Tab> Create(object createProperties)
        {
            return InvokeAsync<Tab>("create", createProperties);
        }

        /// <inheritdoc />
        public virtual ValueTask<string> DetectLanguage(int tabId)
        {
            return InvokeAsync<string>("detectLanguage", tabId);
        }

        /// <inheritdoc />
        public virtual ValueTask Discard(int tabIds)
        {
            return InvokeVoidAsync("discard", tabIds);
        }

        /// <inheritdoc />
        public virtual ValueTask Discard(IEnumerable<int> tabIds)
        {
            return InvokeVoidAsync("discard", tabIds);
        }

        /// <inheritdoc />
        public virtual ValueTask<Tab> Duplicate(int tabId, object duplicateProperties)
        {
            return InvokeAsync<Tab>("duplicate", tabId, duplicateProperties);
        }

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<object>> ExecuteScript(int tabId, InjectDetails details)
        {
            return InvokeAsync<IEnumerable<object>>("executeScript", tabId, details);
        }

        /// <inheritdoc />
        public virtual ValueTask<Tab> Get(int tabId)
        {
            return InvokeAsync<Tab>("get", tabId);
        }

        /// <inheritdoc />
        public virtual ValueTask<Tab> GetCurrent()
        {
            return InvokeAsync<Tab>("getCurrent");
        }

        /// <inheritdoc />
        public virtual ValueTask<double> GetZoom(int tabId)
        {
            return InvokeAsync<double>("getZoom", tabId);
        }

        /// <inheritdoc />
        public virtual ValueTask<ZoomSettings> GetZoomSettings(int tabId)
        {
            return InvokeAsync<ZoomSettings>("getZoomSettings", tabId);
        }

        /// <inheritdoc />
        public virtual ValueTask GoBack(int tabId)
        {
            return InvokeVoidAsync("goBack", tabId);
        }

        /// <inheritdoc />
        public virtual ValueTask GoForward(int tabId)
        {
            return InvokeVoidAsync("goForward", tabId);
        }

        /// <inheritdoc />
        public virtual ValueTask Hide(int tabIds)
        {
            return InvokeVoidAsync("hide", tabIds);
        }

        /// <inheritdoc />
        public virtual ValueTask Hide(IEnumerable<int> tabIds)
        {
            return InvokeVoidAsync("hide", tabIds);
        }

        /// <inheritdoc />
        public virtual ValueTask<Window> Highlight(object highlightInfo)
        {
            return InvokeAsync<Window>("highlight", highlightInfo);
        }

        /// <inheritdoc />
        public virtual ValueTask InsertCSS(int tabId, InjectDetails details)
        {
            return InvokeVoidAsync("insertCSS", tabId, details);
        }

        /// <inheritdoc />
        public virtual ValueTask<JsonElement> Move(int tabIds, object moveProperties)
        {
            return InvokeAsync<JsonElement>("move", tabIds, moveProperties);
        }

        /// <inheritdoc />
        public virtual ValueTask<JsonElement> Move(IEnumerable<int> tabIds, object moveProperties)
        {
            return InvokeAsync<JsonElement>("move", tabIds, moveProperties);
        }

        /// <inheritdoc />
        public virtual ValueTask MoveInSuccession(IEnumerable<int> tabIds, int tabId, object options)
        {
            return InvokeVoidAsync("moveInSuccession", tabIds, tabId, options);
        }

        /// <inheritdoc />
        public virtual ValueTask Print()
        {
            return InvokeVoidAsync("print");
        }

        /// <inheritdoc />
        public virtual ValueTask PrintPreview()
        {
            return InvokeVoidAsync("printPreview");
        }

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<Tab>> Query(object queryInfo)
        {
            return InvokeAsync<IEnumerable<Tab>>("query", queryInfo);
        }

        /// <inheritdoc />
        public virtual ValueTask Reload(int tabId, object reloadProperties)
        {
            return InvokeVoidAsync("reload", tabId, reloadProperties);
        }

        /// <inheritdoc />
        public virtual ValueTask Remove(int tabIds)
        {
            return InvokeVoidAsync("remove", tabIds);
        }

        /// <inheritdoc />
        public virtual ValueTask Remove(IEnumerable<int> tabIds)
        {
            return InvokeVoidAsync("remove", tabIds);
        }

        /// <inheritdoc />
        public virtual ValueTask RemoveCSS(int tabId, InjectDetails details)
        {
            return InvokeVoidAsync("removeCSS", tabId, details);
        }

        /// <inheritdoc />
        public virtual ValueTask<string> SaveAsPDF(PageSettings pageSettings)
        {
            return InvokeAsync<string>("saveAsPDF", pageSettings);
        }

        /// <inheritdoc />
        public virtual ValueTask<JsonElement> SendMessage(int tabId, object message, object options)
        {
            return InvokeAsync<JsonElement>("sendMessage", tabId, message, options);
        }

        /// <inheritdoc />
        public virtual ValueTask SetZoom(int tabId, double zoomFactor)
        {
            return InvokeVoidAsync("setZoom", tabId, zoomFactor);
        }

        /// <inheritdoc />
        public virtual ValueTask SetZoomSettings(int tabId, ZoomSettings zoomSettings)
        {
            return InvokeVoidAsync("setZoomSettings", tabId, zoomSettings);
        }

        /// <inheritdoc />
        public virtual ValueTask Show(int tabIds)
        {
            return InvokeVoidAsync("show", tabIds);
        }

        /// <inheritdoc />
        public virtual ValueTask Show(IEnumerable<int> tabIds)
        {
            return InvokeVoidAsync("show", tabIds);
        }

        /// <inheritdoc />
        public virtual ValueTask ToggleReaderMode(int tabId)
        {
            return InvokeVoidAsync("toggleReaderMode", tabId);
        }

        /// <inheritdoc />
        public virtual ValueTask<Tab> Update(int tabId, object updateProperties)
        {
            return InvokeAsync<Tab>("update", tabId, updateProperties);
        }

        /// <inheritdoc />
        public virtual ValueTask Warmup(int tabId)
        {
            return InvokeVoidAsync("warmup", tabId);
        }
    }
}
