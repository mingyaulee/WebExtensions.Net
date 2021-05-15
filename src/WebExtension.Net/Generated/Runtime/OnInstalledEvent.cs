using System;
using System.Threading.Tasks;
using WebExtension.Net.Events;

namespace WebExtension.Net.Runtime
{
    // Type Class
    /// <summary>Fired when the extension is first installed, when the extension is updated to a new version, and when the browser is updated to a new version.</summary>
    public class OnInstalledEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when the extension is first installed, when the extension is updated to a new version, and when the browser is updated to a new version.</param>
        public virtual ValueTask AddListener(Action<object> callback)
        {
            return InvokeVoidAsync("addListener", callback);
        }

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        public virtual ValueTask<bool> HasListener(Action<object> callback)
        {
            return InvokeAsync<bool>("hasListener", callback);
        }

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        public virtual ValueTask RemoveListener(Action<object> callback)
        {
            return InvokeVoidAsync("removeListener", callback);
        }
    }
}
