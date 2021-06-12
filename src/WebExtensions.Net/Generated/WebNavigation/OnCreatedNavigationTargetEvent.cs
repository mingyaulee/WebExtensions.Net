using System;
using System.Threading.Tasks;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.WebNavigation
{
    // Type Class
    /// <summary>Fired when a new window, or a new tab in an existing window, is created to host a navigation.</summary>
    public partial class OnCreatedNavigationTargetEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when a new window, or a new tab in an existing window, is created to host a navigation.</param>
        public virtual ValueTask AddListener(Action<OnCreatedNavigationTargetEventAddListenerCallbackDetails> callback)
        {
            return InvokeVoidAsync("addListener", callback);
        }

        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when a new window, or a new tab in an existing window, is created to host a navigation.</param>
        /// <param name="filters">Conditions that the URL being navigated to must satisfy. The 'schemes' and 'ports' fields of UrlFilter are ignored for this event.</param>
        public virtual ValueTask AddListener(Action<OnCreatedNavigationTargetEventAddListenerCallbackDetails> callback, EventUrlFilters filters)
        {
            return InvokeVoidAsync("addListener", callback, filters);
        }

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        public virtual ValueTask<bool> HasListener(Action<OnCreatedNavigationTargetEventHasListenerCallbackDetails> callback)
        {
            return InvokeAsync<bool>("hasListener", callback);
        }

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <param name="filters">Conditions that the URL being navigated to must satisfy. The 'schemes' and 'ports' fields of UrlFilter are ignored for this event.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        public virtual ValueTask<bool> HasListener(Action<OnCreatedNavigationTargetEventHasListenerCallbackDetails> callback, EventUrlFilters filters)
        {
            return InvokeAsync<bool>("hasListener", callback, filters);
        }

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        public virtual ValueTask RemoveListener(Action<OnCreatedNavigationTargetEventRemoveListenerCallbackDetails> callback)
        {
            return InvokeVoidAsync("removeListener", callback);
        }

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        /// <param name="filters">Conditions that the URL being navigated to must satisfy. The 'schemes' and 'ports' fields of UrlFilter are ignored for this event.</param>
        public virtual ValueTask RemoveListener(Action<OnCreatedNavigationTargetEventRemoveListenerCallbackDetails> callback, EventUrlFilters filters)
        {
            return InvokeVoidAsync("removeListener", callback, filters);
        }
    }
}
