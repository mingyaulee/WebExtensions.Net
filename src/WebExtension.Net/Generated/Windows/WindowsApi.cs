using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtension.Net.Windows
{
    /// <inheritdoc />
    public class WindowsApi : BaseApi, IWindowsApi
    {
        /// <summary>Creates a new instance of <see cref="WindowsApi" />.</summary>
        /// <param name="webExtensionJSRuntime">Web Extension JS Runtime</param>
        public WindowsApi(WebExtensionJSRuntime webExtensionJSRuntime) : base(webExtensionJSRuntime, "windows")
        {
        }

        /// <inheritdoc />
        public int WINDOW_ID_CURRENT => -2;

        /// <inheritdoc />
        public int WINDOW_ID_NONE => -1;

        /// <inheritdoc />
        public virtual ValueTask<Window> Create(object createData)
        {
            return InvokeAsync<Window>("create", createData);
        }

        /// <inheritdoc />
        public virtual ValueTask<Window> Get(int windowId, GetInfo getInfo)
        {
            return InvokeAsync<Window>("get", windowId, getInfo);
        }

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<Window>> GetAll(object getInfo)
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
        public virtual ValueTask<Window> Update(int windowId, object updateInfo)
        {
            return InvokeAsync<Window>("update", windowId, updateInfo);
        }
    }
}
