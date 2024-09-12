using JsBind.Net;
using System;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Proxy
{
    // Type Class
    /// <summary>Notifies about errors caused by the invalid use of the proxy API.</summary>
    [BindAllProperties]
    public partial class OnErrorEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Notifies about errors caused by the invalid use of the proxy API.</param>
        [JsAccessPath("addListener")]
        public virtual void AddListener(Action<object> callback)
            => InvokeVoid("addListener", callback);

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        [JsAccessPath("hasListener")]
        public virtual bool HasListener(Action<object> callback)
            => Invoke<bool>("hasListener", callback);

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        [JsAccessPath("removeListener")]
        public virtual void RemoveListener(Action<object> callback)
            => InvokeVoid("removeListener", callback);
    }
}
