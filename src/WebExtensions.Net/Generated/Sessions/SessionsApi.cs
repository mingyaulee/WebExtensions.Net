using JsBind.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Sessions;

/// <inheritdoc />
/// <param name="jsRuntime">The JS runtime adapter.</param>
/// <param name="accessPath">The base API access path.</param>
public partial class SessionsApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "sessions")), ISessionsApi
{
    private Event _onChanged;

    /// <inheritdoc />
    public int MAX_SESSION_RESULTS => 25;

    /// <inheritdoc />
    public Event OnChanged
    {
        get
        {
            if (_onChanged is null)
            {
                _onChanged = new Event();
                _onChanged.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onChanged"));
            }
            return _onChanged;
        }
    }

    /// <inheritdoc />
    public virtual void ForgetClosedTab(int windowId, string sessionId)
        => InvokeVoid("forgetClosedTab", windowId, sessionId);

    /// <inheritdoc />
    public virtual void ForgetClosedWindow(string sessionId)
        => InvokeVoid("forgetClosedWindow", sessionId);

    /// <inheritdoc />
    public virtual ValueTask<IEnumerable<Session>> GetRecentlyClosed(Filter filter = null)
        => InvokeAsync<IEnumerable<Session>>("getRecentlyClosed", filter);

    /// <inheritdoc />
    public virtual void GetTabValue(int tabId, string key)
        => InvokeVoid("getTabValue", tabId, key);

    /// <inheritdoc />
    public virtual void GetWindowValue(int windowId, string key)
        => InvokeVoid("getWindowValue", windowId, key);

    /// <inheritdoc />
    public virtual void RemoveTabValue(int tabId, string key)
        => InvokeVoid("removeTabValue", tabId, key);

    /// <inheritdoc />
    public virtual void RemoveWindowValue(int windowId, string key)
        => InvokeVoid("removeWindowValue", windowId, key);

    /// <inheritdoc />
    public virtual ValueTask<Session> Restore(string sessionId = null)
        => InvokeAsync<Session>("restore", sessionId);

    /// <inheritdoc />
    public virtual void SetTabValue(int tabId, string key, object value)
        => InvokeVoid("setTabValue", tabId, key, value);

    /// <inheritdoc />
    public virtual void SetWindowValue(int windowId, string key, object value)
        => InvokeVoid("setWindowValue", windowId, key, value);
}
