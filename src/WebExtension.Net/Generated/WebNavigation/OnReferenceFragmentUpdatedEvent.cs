using System;
using System.Threading.Tasks;
using WebExtension.Net.Events;

namespace WebExtension.Net.WebNavigation
{
    // Type Class
    /// <summary>Fired when the reference fragment of a frame was updated. All future events for that frame will use the updated URL.</summary>
    public class OnReferenceFragmentUpdatedEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when the reference fragment of a frame was updated. All future events for that frame will use the updated URL.</param>
        public virtual ValueTask AddListener(Action<object> callback)
        {
            return InvokeVoidAsync("addListener", callback);
        }

        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when the reference fragment of a frame was updated. All future events for that frame will use the updated URL.</param>
        /// <param name="filters">Conditions that the URL being navigated to must satisfy. The 'schemes' and 'ports' fields of UrlFilter are ignored for this event.</param>
        public virtual ValueTask AddListener(Action<object> callback, EventUrlFilters filters)
        {
            return InvokeVoidAsync("addListener", callback, filters);
        }

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        public virtual ValueTask<bool> HasListener(Action<object> callback)
        {
            return InvokeAsync<bool>("hasListener", callback);
        }

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <param name="filters">Conditions that the URL being navigated to must satisfy. The 'schemes' and 'ports' fields of UrlFilter are ignored for this event.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        public virtual ValueTask<bool> HasListener(Action<object> callback, EventUrlFilters filters)
        {
            return InvokeAsync<bool>("hasListener", callback, filters);
        }

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        public virtual ValueTask RemoveListener(Action<object> callback)
        {
            return InvokeVoidAsync("removeListener", callback);
        }

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        /// <param name="filters">Conditions that the URL being navigated to must satisfy. The 'schemes' and 'ports' fields of UrlFilter are ignored for this event.</param>
        public virtual ValueTask RemoveListener(Action<object> callback, EventUrlFilters filters)
        {
            return InvokeVoidAsync("removeListener", callback, filters);
        }
    }
}
