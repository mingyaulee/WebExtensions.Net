using System;
using System.Threading.Tasks;

namespace WebExtensions.Net.Events
{
    public partial class Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Called when an event occurs. The parameters of this function depend on the type of event.</param>
        public virtual ValueTask AddListener(Delegate callback)
        {
            return InvokeVoidAsync("addListener", callback);
        }

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        public virtual ValueTask<bool> HasListener(Delegate callback)
        {
            return InvokeAsync<bool>("hasListener", callback);
        }

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        public virtual ValueTask RemoveListener(Delegate callback)
        {
            return InvokeVoidAsync("removeListener", callback);
        }
    }
}
