using JsBind.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.Windows
{
    /// <summary>Use the <c>browser.windows</c> API to interact with browser windows. You can use this API to create, modify, and rearrange windows in the browser.</summary>
    [JsAccessPath("windows")]
    public partial interface IWindowsApi
    {
        /// <summary>Fired when a window is created.</summary>
        [JsAccessPath("onCreated")]
        OnCreatedEvent OnCreated { get; }

        /// <summary>Fired when the currently focused window changes. Will be $(ref:windows.WINDOW_ID_NONE) if all browser windows have lost focus. Note: On some Linux window managers, WINDOW_ID_NONE will always be sent immediately preceding a switch from one browser window to another.</summary>
        [JsAccessPath("onFocusChanged")]
        OnFocusChangedEvent OnFocusChanged { get; }

        /// <summary>Fired when a window is removed (closed).</summary>
        [JsAccessPath("onRemoved")]
        OnRemovedEvent OnRemoved { get; }

        /// <summary>The windowId value that represents the $(topic:current-window)[current window].</summary>
        [JsAccessPath("WINDOW_ID_CURRENT")]
        int WINDOW_ID_CURRENT { get; }

        /// <summary>The windowId value that represents the absence of a browser window.</summary>
        [JsAccessPath("WINDOW_ID_NONE")]
        int WINDOW_ID_NONE { get; }

        /// <summary>Creates (opens) a new browser with any optional sizing, position or default URL provided.</summary>
        /// <param name="createData"></param>
        /// <returns>Contains details about the created window.</returns>
        [JsAccessPath("create")]
        ValueTask<Window> Create(CreateData createData = null);

        /// <summary>Gets details about a window.</summary>
        /// <param name="windowId"></param>
        /// <param name="getInfo"></param>
        /// <returns></returns>
        [JsAccessPath("get")]
        ValueTask<Window> Get(int windowId, GetInfo getInfo = null);

        /// <summary>Gets all windows.</summary>
        /// <param name="getInfo">Specifies properties used to filter the $(ref:windows.Window) returned and to determine whether they should contain a list of the $(ref:tabs.Tab) objects.</param>
        /// <returns></returns>
        [JsAccessPath("getAll")]
        ValueTask<IEnumerable<Window>> GetAll(GetAllGetInfo getInfo = null);

        /// <summary>Gets the $(topic:current-window)[current window].</summary>
        /// <param name="getInfo"></param>
        /// <returns></returns>
        [JsAccessPath("getCurrent")]
        ValueTask<Window> GetCurrent(GetInfo getInfo = null);

        /// <summary>Gets the window that was most recently focused - typically the window 'on top'.</summary>
        /// <param name="getInfo"></param>
        /// <returns></returns>
        [JsAccessPath("getLastFocused")]
        ValueTask<Window> GetLastFocused(GetInfo getInfo = null);

        /// <summary>Removes (closes) a window, and all the tabs inside it.</summary>
        /// <param name="windowId"></param>
        [JsAccessPath("remove")]
        ValueTask Remove(int windowId);

        /// <summary>Updates the properties of a window. Specify only the properties that you want to change; unspecified properties will be left unchanged.</summary>
        /// <param name="windowId"></param>
        /// <param name="updateInfo"></param>
        /// <returns></returns>
        [JsAccessPath("update")]
        ValueTask<Window> Update(int windowId, UpdateInfo updateInfo);
    }
}
