using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using WebExtensions.Net.ExtensionTypes;
using WebExtensions.Net.Runtime;
using WebExtensions.Net.Windows;

namespace WebExtensions.Net.Tabs
{
    /// <inheritdoc />
    public partial class TabsApi : BaseApi, ITabsApi
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
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public TabsApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "tabs"))
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
                    _onActivated.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onActivated"));
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
                    _onAttached.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onAttached"));
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
                    _onCreated.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onCreated"));
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
                    _onDetached.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onDetached"));
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
                    _onHighlighted.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onHighlighted"));
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
                    _onMoved.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onMoved"));
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
                    _onRemoved.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onRemoved"));
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
                    _onReplaced.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onReplaced"));
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
                    _onUpdated.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onUpdated"));
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
                    _onZoomChange.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onZoomChange"));
                }
                return _onZoomChange;
            }
        }

        /// <inheritdoc />
        public int TAB_ID_NONE => -1;

        /// <inheritdoc />
        public virtual ValueTask CaptureTab(int? tabId = null, ImageDetails options = null)
        {
            return InvokeVoidAsync("captureTab", tabId, options);
        }

        /// <inheritdoc />
        public virtual ValueTask<string> CaptureVisibleTab(int? windowId = null, ImageDetails options = null)
        {
            return InvokeAsync<string>("captureVisibleTab", windowId, options);
        }

        /// <inheritdoc />
        public virtual ValueTask<Port> Connect(int tabId, ConnectInfo connectInfo = null)
        {
            return InvokeAsync<Port>("connect", tabId, connectInfo);
        }

        /// <inheritdoc />
        public virtual ValueTask<Tab> Create(CreateProperties createProperties)
        {
            return InvokeAsync<Tab>("create", createProperties);
        }

        /// <inheritdoc />
        public virtual ValueTask<string> DetectLanguage(int? tabId = null)
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
        public virtual ValueTask<Tab> Duplicate(int tabId, DuplicateProperties duplicateProperties = null)
        {
            return InvokeAsync<Tab>("duplicate", tabId, duplicateProperties);
        }

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<object>> ExecuteScript(InjectDetails details)
        {
            return InvokeAsync<IEnumerable<object>>("executeScript", details);
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
        public virtual ValueTask<double> GetZoom(int? tabId = null)
        {
            return InvokeAsync<double>("getZoom", tabId);
        }

        /// <inheritdoc />
        public virtual ValueTask<ZoomSettings> GetZoomSettings(int? tabId = null)
        {
            return InvokeAsync<ZoomSettings>("getZoomSettings", tabId);
        }

        /// <inheritdoc />
        public virtual ValueTask GoBack(int? tabId = null)
        {
            return InvokeVoidAsync("goBack", tabId);
        }

        /// <inheritdoc />
        public virtual ValueTask GoForward(int? tabId = null)
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
        public virtual ValueTask InsertCSS(InjectDetails details)
        {
            return InvokeVoidAsync("insertCSS", details);
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
        public virtual ValueTask MoveInSuccession(IEnumerable<int> tabIds, int? tabId = null, MoveInSuccessionOptions options = null)
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
        public virtual ValueTask Reload(int? tabId = null, ReloadProperties reloadProperties = null)
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
        public virtual ValueTask RemoveCSS(InjectDetails details)
        {
            return InvokeVoidAsync("removeCSS", details);
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
        public virtual ValueTask<JsonElement> SendMessage(int tabId, object message, SendMessageOptions options = null)
        {
            return InvokeAsync<JsonElement>("sendMessage", tabId, message, options);
        }

        /// <inheritdoc />
        public virtual ValueTask SetZoom(double zoomFactor)
        {
            return InvokeVoidAsync("setZoom", zoomFactor);
        }

        /// <inheritdoc />
        public virtual ValueTask SetZoom(int? tabId, double zoomFactor)
        {
            return InvokeVoidAsync("setZoom", tabId, zoomFactor);
        }

        /// <inheritdoc />
        public virtual ValueTask SetZoomSettings(ZoomSettings zoomSettings)
        {
            return InvokeVoidAsync("setZoomSettings", zoomSettings);
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
        public virtual ValueTask ToggleReaderMode(int? tabId = null)
        {
            return InvokeVoidAsync("toggleReaderMode", tabId);
        }

        /// <inheritdoc />
        public virtual ValueTask<Tab> Update(UpdateProperties updateProperties)
        {
            return InvokeAsync<Tab>("update", updateProperties);
        }

        /// <inheritdoc />
        public virtual ValueTask<Tab> Update(int? tabId, UpdateProperties updateProperties)
        {
            return InvokeAsync<Tab>("update", tabId, updateProperties);
        }

        /// <inheritdoc />
        public virtual ValueTask Warmup(int? tabId = null)
        {
            return InvokeVoidAsync("warmup", tabId);
        }
    }
}
