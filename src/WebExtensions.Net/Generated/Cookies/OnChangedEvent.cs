using JsBind.Net;
using System;
using System.Threading.Tasks;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Cookies
{
    // Type Class
    /// <summary>Fired when a cookie is set or removed. As a special case, note that updating a cookie's properties is implemented as a two step process: the cookie to be updated is first removed entirely, generating a notification with "cause" of "overwrite" .  Afterwards, a new cookie is written with the updated values, generating a second notification with "cause" "explicit".</summary>
    [BindAllProperties]
    public partial class OnChangedEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when a cookie is set or removed. As a special case, note that updating a cookie's properties is implemented as a two step process: the cookie to be updated is first removed entirely, generating a notification with "cause" of "overwrite" .  Afterwards, a new cookie is written with the updated values, generating a second notification with "cause" "explicit".</param>
        public virtual ValueTask AddListener(Action<AddListenerCallbackChangeInfo> callback)
        {
            return InvokeVoidAsync("addListener", callback);
        }

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        public virtual ValueTask<bool> HasListener(Action<HasListenerCallbackChangeInfo> callback)
        {
            return InvokeAsync<bool>("hasListener", callback);
        }

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        public virtual ValueTask RemoveListener(Action<RemoveListenerCallbackChangeInfo> callback)
        {
            return InvokeVoidAsync("removeListener", callback);
        }
    }
}
