using JsBind.Net;
using System;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Alarms
{
    // Type Class
    /// <summary>Fired when an alarm has expired. Useful for transient background pages.</summary>
    [BindAllProperties]
    public partial class OnAlarmEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when an alarm has expired. Useful for transient background pages.</param>
        [JsAccessPath("addListener")]
        public virtual void AddListener(Action<Alarm> callback)
            => InvokeVoid("addListener", callback);

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        [JsAccessPath("hasListener")]
        public virtual bool HasListener(Action<Alarm> callback)
            => Invoke<bool>("hasListener", callback);

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        [JsAccessPath("removeListener")]
        public virtual void RemoveListener(Action<Alarm> callback)
            => InvokeVoid("removeListener", callback);
    }
}
