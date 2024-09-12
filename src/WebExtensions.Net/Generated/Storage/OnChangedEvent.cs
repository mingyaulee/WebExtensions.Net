using JsBind.Net;
using System;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Storage
{
    // Type Class
    /// <summary>Fired when one or more items change.</summary>
    [BindAllProperties]
    public partial class OnChangedEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when one or more items change.</param>
        [JsAccessPath("addListener")]
        public virtual void AddListener(Action<object, string> callback)
            => InvokeVoid("addListener", callback);

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        [JsAccessPath("hasListener")]
        public virtual bool HasListener(Action<object, string> callback)
            => Invoke<bool>("hasListener", callback);

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        [JsAccessPath("removeListener")]
        public virtual void RemoveListener(Action<object, string> callback)
            => InvokeVoid("removeListener", callback);
    }
}
