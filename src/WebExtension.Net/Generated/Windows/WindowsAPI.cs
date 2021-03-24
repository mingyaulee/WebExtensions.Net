// This file is auto generated at 2021-03-24T04:51:22

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtension.Net.Windows
{
    /// <inheritdoc />
    public class WindowsAPI : IWindowsAPI
    {
        private readonly WebExtensionJSRuntime webExtensionJSRuntime;
        /// <summary>Creates a new instance of WindowsAPI.</summary>
        /// <param name="webExtensionJSRuntime">Web Extension JS Runtime</param>
        public WindowsAPI(WebExtensionJSRuntime webExtensionJSRuntime)
        {
            this.webExtensionJSRuntime = webExtensionJSRuntime;
        }

        
        // Function Definition
        /// <summary>
        /// Gets details about a window.
        /// </summary>
        /// <param name="windowId"></param>
        /// <param name="getInfo"></param>
        /// <returns></returns>
        public virtual ValueTask<Window> Get(int windowId, GetInfo getInfo)
        {
            return webExtensionJSRuntime.InvokeAsync<Window>("windows.get", windowId, getInfo);
        }
        
        // Function Definition
        /// <summary>
        /// Gets the $(topic:current-window)[current window].
        /// </summary>
        /// <param name="getInfo"></param>
        /// <returns></returns>
        public virtual ValueTask<Window> GetCurrent(GetInfo getInfo)
        {
            return webExtensionJSRuntime.InvokeAsync<Window>("windows.getCurrent", getInfo);
        }
        
        // Function Definition
        /// <summary>
        /// Gets the window that was most recently focused - typically the window 'on top'.
        /// </summary>
        /// <param name="getInfo"></param>
        /// <returns></returns>
        public virtual ValueTask<Window> GetLastFocused(GetInfo getInfo)
        {
            return webExtensionJSRuntime.InvokeAsync<Window>("windows.getLastFocused", getInfo);
        }
        
        // Function Definition
        /// <summary>
        /// Gets all windows.
        /// </summary>
        /// <param name="getInfo">Specifies properties used to filter the $(ref:windows.Window) returned and to determine whether they should contain a list of the $(ref:tabs.Tab) objects.</param>
        /// <returns></returns>
        public virtual ValueTask<IEnumerable<Window>> GetAll(object getInfo)
        {
            return webExtensionJSRuntime.InvokeAsync<IEnumerable<Window>>("windows.getAll", getInfo);
        }
        
        // Function Definition
        /// <summary>
        /// Creates (opens) a new browser with any optional sizing, position or default URL provided.
        /// </summary>
        /// <param name="createData"></param>
        /// <returns></returns>
        public virtual ValueTask<Window> Create(object createData)
        {
            return webExtensionJSRuntime.InvokeAsync<Window>("windows.create", createData);
        }
        
        // Function Definition
        /// <summary>
        /// Updates the properties of a window. Specify only the properties that you want to change; unspecified properties will be left unchanged.
        /// </summary>
        /// <param name="windowId"></param>
        /// <param name="updateInfo"></param>
        /// <returns></returns>
        public virtual ValueTask<Window> Update(int windowId, object updateInfo)
        {
            return webExtensionJSRuntime.InvokeAsync<Window>("windows.update", windowId, updateInfo);
        }
        
        // Function Definition
        /// <summary>
        /// Removes (closes) a window, and all the tabs inside it.
        /// </summary>
        /// <param name="windowId"></param>
        public virtual ValueTask Remove(int windowId)
        {
            return webExtensionJSRuntime.InvokeVoidAsync("windows.remove", windowId);
        }
    }
}
