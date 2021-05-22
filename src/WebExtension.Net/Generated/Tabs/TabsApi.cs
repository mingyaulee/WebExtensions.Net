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
        private OnActivatedEvent _onActivated;
        private OnAttachedEvent _onAttached;
        private OnCreatedEvent _onCreated;
        private OnDetachedEvent _onDetached;
        private OnHighlightedEvent _onHighlighted;
        private OnMovedEvent _onMoved;
        private OnRemovedEvent _onRemoved;
        private OnReplacedEvent _onReplaced;
        private OnUpdatedEvent _onUpdated;
        private OnZoomChangeEvent _onZoomChange;

        /// <summary>Creates a new instance of <see cref="TabsApi" />.</summary>
        /// <param name="webExtensionJSRuntime">Web Extension JS Runtime</param>
        public TabsApi(WebExtensionJSRuntime webExtensionJSRuntime) : base(webExtensionJSRuntime, "tabs")
        {
        }

        /// <inheritdoc />
        public OnActivatedEvent OnActivated
        {
            get
            {
                if (_onActivated is null)
                {
                    _onActivated = new OnActivatedEvent();
                    InitializeProperty("onActivated", _onActivated);
                }
                return _onActivated;
            }
        }

        /// <inheritdoc />
        public OnAttachedEvent OnAttached
        {
            get
            {
                if (_onAttached is null)
                {
                    _onAttached = new OnAttachedEvent();
                    InitializeProperty("onAttached", _onAttached);
                }
                return _onAttached;
            }
        }

        /// <inheritdoc />
        public OnCreatedEvent OnCreated
        {
            get
            {
                if (_onCreated is null)
                {
                    _onCreated = new OnCreatedEvent();
                    InitializeProperty("onCreated", _onCreated);
                }
                return _onCreated;
            }
        }

        /// <inheritdoc />
        public OnDetachedEvent OnDetached
        {
            get
            {
                if (_onDetached is null)
                {
                    _onDetached = new OnDetachedEvent();
                    InitializeProperty("onDetached", _onDetached);
                }
                return _onDetached;
            }
        }

        /// <inheritdoc />
        public OnHighlightedEvent OnHighlighted
        {
            get
            {
                if (_onHighlighted is null)
                {
                    _onHighlighted = new OnHighlightedEvent();
                    InitializeProperty("onHighlighted", _onHighlighted);
                }
                return _onHighlighted;
            }
        }

        /// <inheritdoc />
        public OnMovedEvent OnMoved
        {
            get
            {
                if (_onMoved is null)
                {
                    _onMoved = new OnMovedEvent();
                    InitializeProperty("onMoved", _onMoved);
                }
                return _onMoved;
            }
        }

        /// <inheritdoc />
        public OnRemovedEvent OnRemoved
        {
            get
            {
                if (_onRemoved is null)
                {
                    _onRemoved = new OnRemovedEvent();
                    InitializeProperty("onRemoved", _onRemoved);
                }
                return _onRemoved;
            }
        }

        /// <inheritdoc />
        public OnReplacedEvent OnReplaced
        {
            get
            {
                if (_onReplaced is null)
                {
                    _onReplaced = new OnReplacedEvent();
                    InitializeProperty("onReplaced", _onReplaced);
                }
                return _onReplaced;
            }
        }

        /// <inheritdoc />
        public OnUpdatedEvent OnUpdated
        {
            get
            {
                if (_onUpdated is null)
                {
                    _onUpdated = new OnUpdatedEvent();
                    InitializeProperty("onUpdated", _onUpdated);
                }
                return _onUpdated;
            }
        }

        /// <inheritdoc />
        public OnZoomChangeEvent OnZoomChange
        {
            get
            {
                if (_onZoomChange is null)
                {
                    _onZoomChange = new OnZoomChangeEvent();
                    InitializeProperty("onZoomChange", _onZoomChange);
                }
                return _onZoomChange;
            }
        }

        /// <inheritdoc />
        public int TAB_ID_NONE => -1;

        /// <inheritdoc />
        public virtual ValueTask CaptureTab(int? tabId, ImageDetails options)
        {
            return InvokeVoidAsync("captureTab", tabId, options);
        }

        /// <inheritdoc />
        public virtual ValueTask<string> CaptureVisibleTab(int? windowId, ImageDetails options)
        {
            return InvokeAsync<string>("captureVisibleTab", windowId, options);
        }

        /// <inheritdoc />
        public virtual ValueTask<Port> Connect(int tabId, ConnectInfo connectInfo)
        {
            return InvokeAsync<Port>("connect", tabId, connectInfo);
        }

        /// <inheritdoc />
        public virtual ValueTask<Tab> Create(CreateProperties createProperties)
        {
            return InvokeAsync<Tab>("create", createProperties);
        }

        /// <inheritdoc />
        public virtual ValueTask<string> DetectLanguage(int? tabId)
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
        public virtual ValueTask<Tab> Duplicate(int tabId, DuplicateProperties duplicateProperties)
        {
            return InvokeAsync<Tab>("duplicate", tabId, duplicateProperties);
        }

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<object>> ExecuteScript(int? tabId, InjectDetails details)
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
        public virtual ValueTask<double> GetZoom(int? tabId)
        {
            return InvokeAsync<double>("getZoom", tabId);
        }

        /// <inheritdoc />
        public virtual ValueTask<ZoomSettings> GetZoomSettings(int? tabId)
        {
            return InvokeAsync<ZoomSettings>("getZoomSettings", tabId);
        }

        /// <inheritdoc />
        public virtual ValueTask GoBack(int? tabId)
        {
            return InvokeVoidAsync("goBack", tabId);
        }

        /// <inheritdoc />
        public virtual ValueTask GoForward(int? tabId)
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
        public virtual ValueTask<Window> Highlight(HighlightHighlightInfo highlightInfo)
        {
            return InvokeAsync<Window>("highlight", highlightInfo);
        }

        /// <inheritdoc />
        public virtual ValueTask InsertCSS(int? tabId, InjectDetails details)
        {
            return InvokeVoidAsync("insertCSS", tabId, details);
        }

        /// <inheritdoc />
        public virtual ValueTask<CallbackTabs> Move(int tabIds, MoveProperties moveProperties)
        {
            return InvokeAsync<CallbackTabs>("move", tabIds, moveProperties);
        }

        /// <inheritdoc />
        public virtual ValueTask<CallbackTabs> Move(IEnumerable<int> tabIds, MoveProperties moveProperties)
        {
            return InvokeAsync<CallbackTabs>("move", tabIds, moveProperties);
        }

        /// <inheritdoc />
        public virtual ValueTask MoveInSuccession(IEnumerable<int> tabIds, int? tabId, MoveInSuccessionOptions options)
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
        public virtual ValueTask<IEnumerable<Tab>> Query(QueryInfo queryInfo)
        {
            return InvokeAsync<IEnumerable<Tab>>("query", queryInfo);
        }

        /// <inheritdoc />
        public virtual ValueTask Reload(int? tabId, ReloadProperties reloadProperties)
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
        public virtual ValueTask RemoveCSS(int? tabId, InjectDetails details)
        {
            return InvokeVoidAsync("removeCSS", tabId, details);
        }

        /// <inheritdoc />
        public virtual ValueTask<string> SaveAsPDF(PageSettings pageSettings)
        {
            return InvokeAsync<string>("saveAsPDF", pageSettings);
        }

        /// <inheritdoc />
        public virtual ValueTask<JsonElement> SendMessage(int tabId, object message, SendMessageOptions options)
        {
            return InvokeAsync<JsonElement>("sendMessage", tabId, message, options);
        }

        /// <inheritdoc />
        public virtual ValueTask SetZoom(int? tabId, double zoomFactor)
        {
            return InvokeVoidAsync("setZoom", tabId, zoomFactor);
        }

        /// <inheritdoc />
        public virtual ValueTask SetZoomSettings(int? tabId, ZoomSettings zoomSettings)
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
        public virtual ValueTask ToggleReaderMode(int? tabId)
        {
            return InvokeVoidAsync("toggleReaderMode", tabId);
        }

        /// <inheritdoc />
        public virtual ValueTask<Tab> Update(int? tabId, UpdateProperties updateProperties)
        {
            return InvokeAsync<Tab>("update", tabId, updateProperties);
        }

        /// <inheritdoc />
        public virtual ValueTask Warmup(int? tabId)
        {
            return InvokeVoidAsync("warmup", tabId);
        }
    }
}
