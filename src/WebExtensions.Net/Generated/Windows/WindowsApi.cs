using JsBind.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.Windows
{
    /// <inheritdoc />
    public partial class WindowsApi : BaseApi, IWindowsApi
    {
        private OnCreatedEvent _onCreated;
        private OnFocusChangedEvent _onFocusChanged;
        private OnRemovedEvent _onRemoved;

        /// <summary>Creates a new instance of <see cref="WindowsApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public WindowsApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "windows"))
        {
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
        public OnFocusChangedEvent OnFocusChanged
        {
            get
            {
                if (_onFocusChanged is null)
                {
                    _onFocusChanged = new OnFocusChangedEvent();
                    _onFocusChanged.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onFocusChanged"));
                }
                return _onFocusChanged;
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
        public int WINDOW_ID_CURRENT => -2;

        /// <inheritdoc />
        public int WINDOW_ID_NONE => -1;

        /// <inheritdoc />
        public virtual ValueTask<Window> Create(CreateData createData = null)
            => InvokeAsync<Window>("create", createData);

        /// <inheritdoc />
        public virtual ValueTask<Window> Get(int windowId, GetInfo getInfo = null)
            => InvokeAsync<Window>("get", windowId, getInfo);

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<Window>> GetAll(GetAllGetInfo getInfo = null)
            => InvokeAsync<IEnumerable<Window>>("getAll", getInfo);

        /// <inheritdoc />
        public virtual ValueTask<Window> GetCurrent(GetInfo getInfo = null)
            => InvokeAsync<Window>("getCurrent", getInfo);

        /// <inheritdoc />
        public virtual ValueTask<Window> GetLastFocused(GetInfo getInfo = null)
            => InvokeAsync<Window>("getLastFocused", getInfo);

        /// <inheritdoc />
        public virtual ValueTask Remove(int windowId)
            => InvokeVoidAsync("remove", windowId);

        /// <inheritdoc />
        public virtual ValueTask<Window> Update(int windowId, UpdateInfo updateInfo)
            => InvokeAsync<Window>("update", windowId, updateInfo);
    }
}
