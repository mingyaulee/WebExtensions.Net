using JsBind.Net;
using System;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.CaptivePortal
{
    // Type Class
    /// <summary>This notification will be emitted when the captive portal service has determined that we can connect to the internet. The service will pass either `captive` if there is an unlocked captive portal present, or `clear` if no captive portal was detected.</summary>
    [BindAllProperties]
    public partial class OnConnectivityAvailableEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">This notification will be emitted when the captive portal service has determined that we can connect to the internet. The service will pass either `captive` if there is an unlocked captive portal present, or `clear` if no captive portal was detected.</param>
        [JsAccessPath("addListener")]
        public virtual void AddListener(Action<Status> callback)
            => InvokeVoid("addListener", callback);

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        [JsAccessPath("hasListener")]
        public virtual bool HasListener(Action<Status> callback)
            => Invoke<bool>("hasListener", callback);

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        [JsAccessPath("removeListener")]
        public virtual void RemoveListener(Action<Status> callback)
            => InvokeVoid("removeListener", callback);
    }
}
