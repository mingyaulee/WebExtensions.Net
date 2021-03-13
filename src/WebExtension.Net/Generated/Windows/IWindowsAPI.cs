/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtension.Net.Windows
{
    /// <summary>Use the <code>browser.windows</code> API to interact with browser windows. You can use this API to create, modify, and rearrange windows in the browser.</summary>
    public interface IWindowsAPI
    {
        
        /// Function Definition Interface
        /// <summary>
        /// Gets details about a window.
        /// </summary>
        /// <param name="windowId"></param>
        /// <param name="getInfo"></param>
        ValueTask<Window> Get(int windowId, GetInfo getInfo);
        
        /// Function Definition Interface
        /// <summary>
        /// Gets the $(topic:current-window)[current window].
        /// </summary>
        /// <param name="getInfo"></param>
        ValueTask<Window> GetCurrent(GetInfo getInfo);
        
        /// Function Definition Interface
        /// <summary>
        /// Gets the window that was most recently focused &mdash; typically the window 'on top'.
        /// </summary>
        /// <param name="getInfo"></param>
        ValueTask<Window> GetLastFocused(GetInfo getInfo);
        
        /// Function Definition Interface
        /// <summary>
        /// Gets all windows.
        /// </summary>
        /// <param name="getInfo">Specifies properties used to filter the $(ref:windows.Window) returned and to determine whether they should contain a list of the $(ref:tabs.Tab) objects.</param>
        ValueTask<IEnumerable<Window>> GetAll(object getInfo);
        
        /// Function Definition Interface
        /// <summary>
        /// Creates (opens) a new browser with any optional sizing, position or default URL provided.
        /// </summary>
        /// <param name="createData"></param>
        ValueTask<Window> Create(object createData);
        
        /// Function Definition Interface
        /// <summary>
        /// Updates the properties of a window. Specify only the properties that you want to change; unspecified properties will be left unchanged.
        /// </summary>
        /// <param name="windowId"></param>
        /// <param name="updateInfo"></param>
        ValueTask<Window> Update(int windowId, object updateInfo);
        
        /// Function Definition Interface
        /// <summary>
        /// Removes (closes) a window, and all the tabs inside it.
        /// </summary>
        /// <param name="windowId"></param>
        ValueTask Remove(int windowId);
    }
}
