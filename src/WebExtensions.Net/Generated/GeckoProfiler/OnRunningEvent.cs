using JsBind.Net;
using System;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.GeckoProfiler
{
    // Type Class
    /// <summary>Fires when the profiler starts/stops running.</summary>
    [BindAllProperties]
    public partial class OnRunningEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fires when the profiler starts/stops running.</param>
        [JsAccessPath("addListener")]
        public virtual void AddListener(Action<bool> callback)
            => InvokeVoid("addListener", callback);

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        [JsAccessPath("hasListener")]
        public virtual bool HasListener(Action<bool> callback)
            => Invoke<bool>("hasListener", callback);

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        [JsAccessPath("removeListener")]
        public virtual void RemoveListener(Action<bool> callback)
            => InvokeVoid("removeListener", callback);
    }
}
