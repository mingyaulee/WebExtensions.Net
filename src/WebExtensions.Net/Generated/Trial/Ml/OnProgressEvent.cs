using JsBind.Net;
using System;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Trial.Ml
{
    // Type Class
    /// <summary>Events from the inference engine.</summary>
    [BindAllProperties]
    public partial class OnProgressEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Events from the inference engine.</param>
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
