using System;
using System.Threading.Tasks;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Downloads
{
    // Type Class
    /// <summary>Fires with the <c>downloadId</c> when a download is erased from history.</summary>
    public partial class OnErasedEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fires with the <c>downloadId</c> when a download is erased from history.</param>
        public virtual ValueTask AddListener(Action<int> callback)
        {
            return InvokeVoidAsync("addListener", callback);
        }

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        public virtual ValueTask<bool> HasListener(Action<int> callback)
        {
            return InvokeAsync<bool>("hasListener", callback);
        }

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        public virtual ValueTask RemoveListener(Action<int> callback)
        {
            return InvokeVoidAsync("removeListener", callback);
        }
    }
}
