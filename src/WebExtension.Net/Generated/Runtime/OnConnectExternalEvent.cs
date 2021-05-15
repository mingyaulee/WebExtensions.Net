using System;
using System.Threading.Tasks;
using WebExtension.Net.Events;

namespace WebExtension.Net.Runtime
{
    // Type Class
    /// <summary>Fired when a connection is made from another extension.</summary>
    public class OnConnectExternalEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when a connection is made from another extension.</param>
        public virtual ValueTask AddListener(Action<Port> callback)
        {
            return InvokeVoidAsync("addListener", callback);
        }

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        public virtual ValueTask<bool> HasListener(Action<Port> callback)
        {
            return InvokeAsync<bool>("hasListener", callback);
        }

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        public virtual ValueTask RemoveListener(Action<Port> callback)
        {
            return InvokeVoidAsync("removeListener", callback);
        }
    }
}
