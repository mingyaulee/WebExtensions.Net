using System;
using System.Threading.Tasks;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Notifications
{
    // Type Class
    /// <summary>Fired when the notification closed, either by the system or by user action.</summary>
    public class OnClosedEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when the notification closed, either by the system or by user action.</param>
        public virtual ValueTask AddListener(Action<string, bool> callback)
        {
            return InvokeVoidAsync("addListener", callback);
        }

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        public virtual ValueTask<bool> HasListener(Action<string, bool> callback)
        {
            return InvokeAsync<bool>("hasListener", callback);
        }

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        public virtual ValueTask RemoveListener(Action<string, bool> callback)
        {
            return InvokeVoidAsync("removeListener", callback);
        }
    }
}
