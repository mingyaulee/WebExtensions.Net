using JsBind.Net;
using System;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Devtools.Network
{
    // Type Class
    /// <summary>Fired when a network request is finished and all request data are available.</summary>
    [BindAllProperties]
    public partial class OnRequestFinishedEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when a network request is finished and all request data are available.</param>
        [JsAccessPath("addListener")]
        public virtual void AddListener(Action<Request> callback)
            => InvokeVoid("addListener", callback);

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        [JsAccessPath("hasListener")]
        public virtual bool HasListener(Action<Request> callback)
            => Invoke<bool>("hasListener", callback);

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        [JsAccessPath("removeListener")]
        public virtual void RemoveListener(Action<Request> callback)
            => InvokeVoid("removeListener", callback);
    }
}
