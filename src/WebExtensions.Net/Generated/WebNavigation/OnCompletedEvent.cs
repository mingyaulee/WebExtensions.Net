using JsBind.Net;
using System;
using System.Threading.Tasks;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.WebNavigation
{
    // Type Class
    /// <summary>Fired when a document, including the resources it refers to, is completely loaded and initialized.</summary>
    [BindAllProperties]
    public partial class OnCompletedEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when a document, including the resources it refers to, is completely loaded and initialized.</param>
        [JsAccessPath("addListener")]
        public virtual ValueTask AddListener(Action<OnCompletedEventCallbackDetails> callback)
        {
            return InvokeVoidAsync("addListener", callback);
        }

        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when a document, including the resources it refers to, is completely loaded and initialized.</param>
        /// <param name="filters">Conditions that the URL being navigated to must satisfy. The 'schemes' and 'ports' fields of UrlFilter are ignored for this event.</param>
        [JsAccessPath("addListener")]
        public virtual ValueTask AddListener(Action<OnCompletedEventCallbackDetails> callback, EventUrlFilters filters)
        {
            return InvokeVoidAsync("addListener", callback, filters);
        }

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        [JsAccessPath("hasListener")]
        public virtual ValueTask<bool> HasListener(Action<OnCompletedEventCallbackDetails> callback)
        {
            return InvokeAsync<bool>("hasListener", callback);
        }

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <param name="filters">Conditions that the URL being navigated to must satisfy. The 'schemes' and 'ports' fields of UrlFilter are ignored for this event.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        [JsAccessPath("hasListener")]
        public virtual ValueTask<bool> HasListener(Action<OnCompletedEventCallbackDetails> callback, EventUrlFilters filters)
        {
            return InvokeAsync<bool>("hasListener", callback, filters);
        }

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        [JsAccessPath("removeListener")]
        public virtual ValueTask RemoveListener(Action<OnCompletedEventCallbackDetails> callback)
        {
            return InvokeVoidAsync("removeListener", callback);
        }

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        /// <param name="filters">Conditions that the URL being navigated to must satisfy. The 'schemes' and 'ports' fields of UrlFilter are ignored for this event.</param>
        [JsAccessPath("removeListener")]
        public virtual ValueTask RemoveListener(Action<OnCompletedEventCallbackDetails> callback, EventUrlFilters filters)
        {
            return InvokeVoidAsync("removeListener", callback, filters);
        }
    }
}
