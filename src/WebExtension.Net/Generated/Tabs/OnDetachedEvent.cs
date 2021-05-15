using System;
using System.Threading.Tasks;
using WebExtension.Net.Events;

namespace WebExtension.Net.Tabs
{
    // Type Class
    /// <summary>Fired when a tab is detached from a window, for example because it is being moved between windows.</summary>
    public class OnDetachedEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when a tab is detached from a window, for example because it is being moved between windows.</param>
        public virtual ValueTask AddListener(Action<int, object> callback)
        {
            return InvokeVoidAsync("addListener", callback);
        }

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        public virtual ValueTask<bool> HasListener(Action<int, object> callback)
        {
            return InvokeAsync<bool>("hasListener", callback);
        }

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        public virtual ValueTask RemoveListener(Action<int, object> callback)
        {
            return InvokeVoidAsync("removeListener", callback);
        }
    }
}
