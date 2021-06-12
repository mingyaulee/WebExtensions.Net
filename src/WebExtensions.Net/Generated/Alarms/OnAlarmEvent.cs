using System;
using System.Threading.Tasks;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Alarms
{
    // Type Class
    /// <summary>Fired when an alarm has expired. Useful for transient background pages.</summary>
    public partial class OnAlarmEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when an alarm has expired. Useful for transient background pages.</param>
        public virtual ValueTask AddListener(Action<Alarm> callback)
        {
            return InvokeVoidAsync("addListener", callback);
        }

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        public virtual ValueTask<bool> HasListener(Action<Alarm> callback)
        {
            return InvokeAsync<bool>("hasListener", callback);
        }

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        public virtual ValueTask RemoveListener(Action<Alarm> callback)
        {
            return InvokeVoidAsync("removeListener", callback);
        }
    }
}
