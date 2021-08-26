using JsBind.Net;
using System;
using System.Threading.Tasks;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.History
{
    // Type Class
    /// <summary>Fired when the title of a URL is changed in the browser history.</summary>
    [BindAllProperties]
    public partial class OnTitleChangedEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when the title of a URL is changed in the browser history.</param>
        public virtual ValueTask AddListener(Action<AddListenerCallbackChanged> callback)
        {
            return InvokeVoidAsync("addListener", callback);
        }

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        public virtual ValueTask<bool> HasListener(Action<HasListenerCallbackChanged> callback)
        {
            return InvokeAsync<bool>("hasListener", callback);
        }

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        public virtual ValueTask RemoveListener(Action<RemoveListenerCallbackChanged> callback)
        {
            return InvokeVoidAsync("removeListener", callback);
        }
    }
}
