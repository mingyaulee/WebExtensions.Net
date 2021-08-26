using JsBind.Net;
using System;
using System.Threading.Tasks;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Omnibox
{
    // Type Class
    /// <summary>User has accepted what is typed into the omnibox.</summary>
    [BindAllProperties]
    public partial class OnInputEnteredEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">User has accepted what is typed into the omnibox.</param>
        public virtual ValueTask AddListener(Action<string, OnInputEnteredDisposition> callback)
        {
            return InvokeVoidAsync("addListener", callback);
        }

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        public virtual ValueTask<bool> HasListener(Action<string, OnInputEnteredDisposition> callback)
        {
            return InvokeAsync<bool>("hasListener", callback);
        }

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        public virtual ValueTask RemoveListener(Action<string, OnInputEnteredDisposition> callback)
        {
            return InvokeVoidAsync("removeListener", callback);
        }
    }
}
