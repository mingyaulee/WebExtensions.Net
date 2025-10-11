using JsBind.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Sessions;

/// <summary>Use the <c>chrome.sessions</c> API to query and restore tabs and windows from a browsing session.</summary>
[JsAccessPath("sessions")]
public partial interface ISessionsApi
{
    /// <summary>The maximum number of $(ref:sessions.Session) that will be included in a requested list.</summary>
    [JsAccessPath("MAX_SESSION_RESULTS")]
    int MAX_SESSION_RESULTS { get; }

    /// <summary>Fired when recently closed tabs and/or windows are changed. This event does not monitor synced sessions changes.</summary>
    [JsAccessPath("onChanged")]
    Event OnChanged { get; }

    /// <summary>Forget a recently closed tab.</summary>
    /// <param name="windowId">The windowId of the window to which the recently closed tab to be forgotten belongs.</param>
    /// <param name="sessionId">The sessionId (closedId) of the recently closed tab to be forgotten.</param>
    [JsAccessPath("forgetClosedTab")]
    void ForgetClosedTab(int windowId, string sessionId);

    /// <summary>Forget a recently closed window.</summary>
    /// <param name="sessionId">The sessionId (closedId) of the recently closed window to be forgotten.</param>
    [JsAccessPath("forgetClosedWindow")]
    void ForgetClosedWindow(string sessionId);

    /// <summary>Gets the list of recently closed tabs and/or windows.</summary>
    /// <param name="filter"></param>
    /// <returns>The list of closed entries in reverse order that they were closed (the most recently closed tab or window will be at index <c>0</c>). The entries may contain either tabs or windows.</returns>
    [JsAccessPath("getRecentlyClosed")]
    ValueTask<IEnumerable<Session>> GetRecentlyClosed(Filter filter = null);

    /// <summary>Retrieve a value that was set for a given key on a given tab.</summary>
    /// <param name="tabId">The id of the tab whose value is being retrieved from.</param>
    /// <param name="key">The key which corresponds to the value.</param>
    [JsAccessPath("getTabValue")]
    void GetTabValue(int tabId, string key);

    /// <summary>Retrieve a value that was set for a given key on a given window.</summary>
    /// <param name="windowId">The id of the window whose value is being retrieved from.</param>
    /// <param name="key">The key which corresponds to the value.</param>
    [JsAccessPath("getWindowValue")]
    void GetWindowValue(int windowId, string key);

    /// <summary>Remove a key/value pair that was set on a given tab.</summary>
    /// <param name="tabId">The id of the tab whose key/value pair is being removed.</param>
    /// <param name="key">The key which corresponds to the value.</param>
    [JsAccessPath("removeTabValue")]
    void RemoveTabValue(int tabId, string key);

    /// <summary>Remove a key/value pair that was set on a given window.</summary>
    /// <param name="windowId">The id of the window whose key/value pair is being removed.</param>
    /// <param name="key">The key which corresponds to the value.</param>
    [JsAccessPath("removeWindowValue")]
    void RemoveWindowValue(int windowId, string key);

    /// <summary>Reopens a $(ref:windows.Window) or $(ref:tabs.Tab), with an optional callback to run when the entry has been restored.</summary>
    /// <param name="sessionId">The $(ref:windows.Window.sessionId), or $(ref:tabs.Tab.sessionId) to restore. If this parameter is not specified, the most recently closed session is restored.</param>
    /// <returns>A $(ref:sessions.Session) containing the restored $(ref:windows.Window) or $(ref:tabs.Tab) object.</returns>
    [JsAccessPath("restore")]
    ValueTask<Session> Restore(string sessionId = null);

    /// <summary>Set a key/value pair on a given tab.</summary>
    /// <param name="tabId">The id of the tab that the key/value pair is being set on.</param>
    /// <param name="key">The key which corresponds to the value being set.</param>
    /// <param name="value">The value being set.</param>
    [JsAccessPath("setTabValue")]
    void SetTabValue(int tabId, string key, object value);

    /// <summary>Set a key/value pair on a given window.</summary>
    /// <param name="windowId">The id of the window that the key/value pair is being set on.</param>
    /// <param name="key">The key which corresponds to the value being set.</param>
    /// <param name="value">The value being set.</param>
    [JsAccessPath("setWindowValue")]
    void SetWindowValue(int windowId, string key, object value);
}
