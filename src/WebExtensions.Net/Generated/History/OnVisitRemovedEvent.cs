using JsBind.Net;
using System;
using System.Threading.Tasks;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.History
{
    // Type Class
    /// <summary>Fired when one or more URLs are removed from the history service.  When all visits have been removed the URL is purged from history.</summary>
    [BindAllProperties]
    public partial class OnVisitRemovedEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when one or more URLs are removed from the history service.  When all visits have been removed the URL is purged from history.</param>
        public virtual ValueTask AddListener(Action<Removed> callback)
        {
            return InvokeVoidAsync("addListener", callback);
        }

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        public virtual ValueTask<bool> HasListener(Action<Removed> callback)
        {
            return InvokeAsync<bool>("hasListener", callback);
        }

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        public virtual ValueTask RemoveListener(Action<Removed> callback)
        {
            return InvokeVoidAsync("removeListener", callback);
        }
    }
}
