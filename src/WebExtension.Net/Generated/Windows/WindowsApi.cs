using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtension.Net.Windows
{
    /// <inheritdoc />
    public partial class WindowsApi : BaseApi, IWindowsApi
    {
        private OnCreatedEvent _onCreated;
        private OnFocusChangedEvent _onFocusChanged;
        private OnRemovedEvent _onRemoved;

        /// <summary>Creates a new instance of <see cref="WindowsApi" />.</summary>
        /// <param name="webExtensionJSRuntime">Web Extension JS Runtime</param>
        public WindowsApi(WebExtensionJSRuntime webExtensionJSRuntime) : base(webExtensionJSRuntime, "windows")
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
                    InitializeProperty("onCreated", _onCreated);
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
                    InitializeProperty("onFocusChanged", _onFocusChanged);
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
                    InitializeProperty("onRemoved", _onRemoved);
                }
                return _onRemoved;
            }
        }

        /// <inheritdoc />
        public int WINDOW_ID_CURRENT => -2;

        /// <inheritdoc />
        public int WINDOW_ID_NONE => -1;

        /// <inheritdoc />
        public virtual ValueTask<Window> Create(CreateData createData)
        {
            return InvokeAsync<Window>("create", createData);
        }

        /// <inheritdoc />
        public virtual ValueTask<Window> Get(int windowId, GetInfo getInfo)
        {
            return InvokeAsync<Window>("get", windowId, getInfo);
        }

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<Window>> GetAll(GetAllGetInfo getInfo)
        {
            return InvokeAsync<IEnumerable<Window>>("getAll", getInfo);
        }

        /// <inheritdoc />
        public virtual ValueTask<Window> GetCurrent(GetInfo getInfo)
        {
            return InvokeAsync<Window>("getCurrent", getInfo);
        }

        /// <inheritdoc />
        public virtual ValueTask<Window> GetLastFocused(GetInfo getInfo)
        {
            return InvokeAsync<Window>("getLastFocused", getInfo);
        }

        /// <inheritdoc />
        public virtual ValueTask Remove(int windowId)
        {
            return InvokeVoidAsync("remove", windowId);
        }

        /// <inheritdoc />
        public virtual ValueTask<Window> Update(int windowId, UpdateInfo updateInfo)
        {
            return InvokeAsync<Window>("update", windowId, updateInfo);
        }
    }
}
