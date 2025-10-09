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
    /// <param name="jsRuntime">The JS runtime adapter.</param>
    /// <param name="accessPath">The base API access path.</param>
    public partial class TabsApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "tabs")), ITabsApi
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
        public virtual void CaptureTab(int? tabId = null, ImageDetails options = null)
            => InvokeVoid("captureTab", tabId, options);

        /// <inheritdoc />
        public virtual ValueTask<string> CaptureVisibleTab(int? windowId = null, ImageDetails options = null)
            => InvokeAsync<string>("captureVisibleTab", windowId, options);

        /// <inheritdoc />
        public virtual Port Connect(int tabId, ConnectInfo connectInfo = null)
            => Invoke<Port>("connect", tabId, connectInfo);

        /// <inheritdoc />
        public virtual ValueTask<Tab> Create(CreateProperties createProperties)
            => InvokeAsync<Tab>("create", createProperties);

        /// <inheritdoc />
        public virtual ValueTask<string> DetectLanguage(int? tabId = null)
            => InvokeAsync<string>("detectLanguage", tabId);

        /// <inheritdoc />
        public virtual void Discard(int tabIds)
            => InvokeVoid("discard", tabIds);

        /// <inheritdoc />
        public virtual void Discard(IEnumerable<int> tabIds)
            => InvokeVoid("discard", tabIds);

        /// <inheritdoc />
        public virtual ValueTask<Tab> Duplicate(int tabId, DuplicateProperties duplicateProperties = null)
            => InvokeAsync<Tab>("duplicate", tabId, duplicateProperties);

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<object>> ExecuteScript(InjectDetails details)
            => InvokeAsync<IEnumerable<object>>("executeScript", details);

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<object>> ExecuteScript(int? tabId, InjectDetails details)
            => InvokeAsync<IEnumerable<object>>("executeScript", tabId, details);

        /// <inheritdoc />
        public virtual ValueTask<Tab> Get(int tabId)
            => InvokeAsync<Tab>("get", tabId);

        /// <inheritdoc />
        public virtual ValueTask<Tab> GetCurrent()
            => InvokeAsync<Tab>("getCurrent");

        /// <inheritdoc />
        public virtual ValueTask<double> GetZoom(int? tabId = null)
            => InvokeAsync<double>("getZoom", tabId);

        /// <inheritdoc />
        public virtual ValueTask<ZoomSettings> GetZoomSettings(int? tabId = null)
            => InvokeAsync<ZoomSettings>("getZoomSettings", tabId);

        /// <inheritdoc />
        public virtual ValueTask GoBack(int? tabId = null)
            => InvokeVoidAsync("goBack", tabId);

        /// <inheritdoc />
        public virtual ValueTask GoForward(int? tabId = null)
            => InvokeVoidAsync("goForward", tabId);

        /// <inheritdoc />
        public virtual ValueTask<int> Group(GroupOptions options)
            => InvokeAsync<int>("group", options);

        /// <inheritdoc />
        public virtual void Hide(int tabIds)
            => InvokeVoid("hide", tabIds);

        /// <inheritdoc />
        public virtual void Hide(IEnumerable<int> tabIds)
            => InvokeVoid("hide", tabIds);

        /// <inheritdoc />
        public virtual ValueTask<Window> Highlight(HighlightHighlightInfo highlightInfo)
            => InvokeAsync<Window>("highlight", highlightInfo);

        /// <inheritdoc />
        public virtual ValueTask InsertCSS(InjectDetails details)
            => InvokeVoidAsync("insertCSS", details);

        /// <inheritdoc />
        public virtual ValueTask InsertCSS(int? tabId, InjectDetails details)
            => InvokeVoidAsync("insertCSS", tabId, details);

        /// <inheritdoc />
        public virtual ValueTask<CallbackTabs> Move(int tabIds, MoveProperties moveProperties)
            => InvokeAsync<CallbackTabs>("move", tabIds, moveProperties);

        /// <inheritdoc />
        public virtual ValueTask<CallbackTabs> Move(IEnumerable<int> tabIds, MoveProperties moveProperties)
            => InvokeAsync<CallbackTabs>("move", tabIds, moveProperties);

        /// <inheritdoc />
        public virtual void MoveInSuccession(IEnumerable<int> tabIds, int? tabId = null, MoveInSuccessionOptions options = null)
            => InvokeVoid("moveInSuccession", tabIds, tabId, options);

        /// <inheritdoc />
        public virtual void Print()
            => InvokeVoid("print");

        /// <inheritdoc />
        public virtual ValueTask PrintPreview()
            => InvokeVoidAsync("printPreview");

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<Tab>> Query(QueryInfo queryInfo)
            => InvokeAsync<IEnumerable<Tab>>("query", queryInfo);

        /// <inheritdoc />
        public virtual ValueTask Reload(int? tabId = null, ReloadProperties reloadProperties = null)
            => InvokeVoidAsync("reload", tabId, reloadProperties);

        /// <inheritdoc />
        public virtual ValueTask Remove(int tabIds)
            => InvokeVoidAsync("remove", tabIds);

        /// <inheritdoc />
        public virtual ValueTask Remove(IEnumerable<int> tabIds)
            => InvokeVoidAsync("remove", tabIds);

        /// <inheritdoc />
        public virtual ValueTask RemoveCSS(InjectDetails details)
            => InvokeVoidAsync("removeCSS", details);

        /// <inheritdoc />
        public virtual ValueTask RemoveCSS(int? tabId, InjectDetails details)
            => InvokeVoidAsync("removeCSS", tabId, details);

        /// <inheritdoc />
        public virtual ValueTask<string> SaveAsPDF(PageSettings pageSettings)
            => InvokeAsync<string>("saveAsPDF", pageSettings);

        /// <inheritdoc />
        public virtual ValueTask<JsonElement> SendMessage(int tabId, object message, SendMessageOptions options = null)
            => InvokeAsync<JsonElement>("sendMessage", tabId, message, options);

        /// <inheritdoc />
        public virtual ValueTask SetZoom(double zoomFactor)
            => InvokeVoidAsync("setZoom", zoomFactor);

        /// <inheritdoc />
        public virtual ValueTask SetZoom(int? tabId, double zoomFactor)
            => InvokeVoidAsync("setZoom", tabId, zoomFactor);

        /// <inheritdoc />
        public virtual ValueTask SetZoomSettings(ZoomSettings zoomSettings)
            => InvokeVoidAsync("setZoomSettings", zoomSettings);

        /// <inheritdoc />
        public virtual ValueTask SetZoomSettings(int? tabId, ZoomSettings zoomSettings)
            => InvokeVoidAsync("setZoomSettings", tabId, zoomSettings);

        /// <inheritdoc />
        public virtual void Show(int tabIds)
            => InvokeVoid("show", tabIds);

        /// <inheritdoc />
        public virtual void Show(IEnumerable<int> tabIds)
            => InvokeVoid("show", tabIds);

        /// <inheritdoc />
        public virtual void ToggleReaderMode(int? tabId = null)
            => InvokeVoid("toggleReaderMode", tabId);

        /// <inheritdoc />
        public virtual void Ungroup(int tabIds)
            => InvokeVoid("ungroup", tabIds);

        /// <inheritdoc />
        public virtual void Ungroup(IEnumerable<int> tabIds)
            => InvokeVoid("ungroup", tabIds);

        /// <inheritdoc />
        public virtual ValueTask<Tab> Update(UpdateProperties updateProperties)
            => InvokeAsync<Tab>("update", updateProperties);

        /// <inheritdoc />
        public virtual ValueTask<Tab> Update(int? tabId, UpdateProperties updateProperties)
            => InvokeAsync<Tab>("update", tabId, updateProperties);

        /// <inheritdoc />
        public virtual void Warmup(int? tabId = null)
            => InvokeVoid("warmup", tabId);
    }
}
