using System.Collections.Generic;
using System.Threading.Tasks;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Sessions
{
    /// <inheritdoc />
    public partial class SessionsApi : BaseApi, ISessionsApi
    {
        private Event _onChanged;

        /// <summary>Creates a new instance of <see cref="SessionsApi" />.</summary>
        /// <param name="webExtensionsJSRuntime">Web Extension JS Runtime</param>
        public SessionsApi(IWebExtensionsJSRuntime webExtensionsJSRuntime) : base(webExtensionsJSRuntime, "sessions")
        {
        }

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
                    InitializeProperty("onChanged", _onChanged);
                }
                return _onChanged;
            }
        }

        /// <inheritdoc />
        public virtual ValueTask ForgetClosedTab(int windowId, string sessionId)
        {
            return InvokeVoidAsync("forgetClosedTab", windowId, sessionId);
        }

        /// <inheritdoc />
        public virtual ValueTask ForgetClosedWindow(string sessionId)
        {
            return InvokeVoidAsync("forgetClosedWindow", sessionId);
        }

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<Session>> GetRecentlyClosed(Filter filter)
        {
            return InvokeAsync<IEnumerable<Session>>("getRecentlyClosed", filter);
        }

        /// <inheritdoc />
        public virtual ValueTask GetTabValue(int tabId, string key)
        {
            return InvokeVoidAsync("getTabValue", tabId, key);
        }

        /// <inheritdoc />
        public virtual ValueTask GetWindowValue(int windowId, string key)
        {
            return InvokeVoidAsync("getWindowValue", windowId, key);
        }

        /// <inheritdoc />
        public virtual ValueTask RemoveTabValue(int tabId, string key)
        {
            return InvokeVoidAsync("removeTabValue", tabId, key);
        }

        /// <inheritdoc />
        public virtual ValueTask RemoveWindowValue(int windowId, string key)
        {
            return InvokeVoidAsync("removeWindowValue", windowId, key);
        }

        /// <inheritdoc />
        public virtual ValueTask<Session> Restore(string sessionId)
        {
            return InvokeAsync<Session>("restore", sessionId);
        }

        /// <inheritdoc />
        public virtual ValueTask SetTabValue(int tabId, string key, object value)
        {
            return InvokeVoidAsync("setTabValue", tabId, key, value);
        }

        /// <inheritdoc />
        public virtual ValueTask SetWindowValue(int windowId, string key, object value)
        {
            return InvokeVoidAsync("setWindowValue", windowId, key, value);
        }
    }
}
