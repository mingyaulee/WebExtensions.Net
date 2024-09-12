using JsBind.Net;
using System;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.WebNavigation
{
    // Type Class
    /// <summary>Fired when the frame's history was updated to a new URL. All future events for that frame will use the updated URL.</summary>
    [BindAllProperties]
    public partial class OnHistoryStateUpdatedEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when the frame's history was updated to a new URL. All future events for that frame will use the updated URL.</param>
        [JsAccessPath("addListener")]
        public virtual void AddListener(Action<OnHistoryStateUpdatedEventCallbackDetails> callback)
            => InvokeVoid("addListener", callback);

        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when the frame's history was updated to a new URL. All future events for that frame will use the updated URL.</param>
        /// <param name="filters">Conditions that the URL being navigated to must satisfy. The 'schemes' and 'ports' fields of UrlFilter are ignored for this event.</param>
        [JsAccessPath("addListener")]
        public virtual void AddListener(Action<OnHistoryStateUpdatedEventCallbackDetails> callback, EventUrlFilters filters)
            => InvokeVoid("addListener", callback, filters);

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        [JsAccessPath("hasListener")]
        public virtual bool HasListener(Action<OnHistoryStateUpdatedEventCallbackDetails> callback)
            => Invoke<bool>("hasListener", callback);

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <param name="filters">Conditions that the URL being navigated to must satisfy. The 'schemes' and 'ports' fields of UrlFilter are ignored for this event.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        [JsAccessPath("hasListener")]
        public virtual bool HasListener(Action<OnHistoryStateUpdatedEventCallbackDetails> callback, EventUrlFilters filters)
            => Invoke<bool>("hasListener", callback, filters);

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        [JsAccessPath("removeListener")]
        public virtual void RemoveListener(Action<OnHistoryStateUpdatedEventCallbackDetails> callback)
            => InvokeVoid("removeListener", callback);

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        /// <param name="filters">Conditions that the URL being navigated to must satisfy. The 'schemes' and 'ports' fields of UrlFilter are ignored for this event.</param>
        [JsAccessPath("removeListener")]
        public virtual void RemoveListener(Action<OnHistoryStateUpdatedEventCallbackDetails> callback, EventUrlFilters filters)
            => InvokeVoid("removeListener", callback, filters);
    }
}
