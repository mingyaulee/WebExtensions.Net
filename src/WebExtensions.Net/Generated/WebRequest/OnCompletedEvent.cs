using JsBind.Net;
using System;
using System.Collections.Generic;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.WebRequest
{
    // Type Class
    /// <summary>Fired when a request is completed.</summary>
    [BindAllProperties]
    public partial class OnCompletedEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when a request is completed.</param>
        [JsAccessPath("addListener")]
        public virtual void AddListener(Action<OnCompletedEventCallbackDetails> callback)
            => InvokeVoid("addListener", callback);

        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when a request is completed.</param>
        /// <param name="filter">A set of filters that restricts the events that will be sent to this listener.</param>
        /// <param name="extraInfoSpec">Array of extra information that should be passed to the listener function.</param>
        [JsAccessPath("addListener")]
        public virtual void AddListener(Action<OnCompletedEventCallbackDetails> callback, RequestFilter filter, IEnumerable<OnCompletedOptions> extraInfoSpec)
            => InvokeVoid("addListener", callback, filter, extraInfoSpec);

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        [JsAccessPath("hasListener")]
        public virtual bool HasListener(Action<OnCompletedEventCallbackDetails> callback)
            => Invoke<bool>("hasListener", callback);

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <param name="filter">A set of filters that restricts the events that will be sent to this listener.</param>
        /// <param name="extraInfoSpec">Array of extra information that should be passed to the listener function.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        [JsAccessPath("hasListener")]
        public virtual bool HasListener(Action<OnCompletedEventCallbackDetails> callback, RequestFilter filter, IEnumerable<OnCompletedOptions> extraInfoSpec)
            => Invoke<bool>("hasListener", callback, filter, extraInfoSpec);

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        [JsAccessPath("removeListener")]
        public virtual void RemoveListener(Action<OnCompletedEventCallbackDetails> callback)
            => InvokeVoid("removeListener", callback);

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        /// <param name="filter">A set of filters that restricts the events that will be sent to this listener.</param>
        /// <param name="extraInfoSpec">Array of extra information that should be passed to the listener function.</param>
        [JsAccessPath("removeListener")]
        public virtual void RemoveListener(Action<OnCompletedEventCallbackDetails> callback, RequestFilter filter, IEnumerable<OnCompletedOptions> extraInfoSpec)
            => InvokeVoid("removeListener", callback, filter, extraInfoSpec);
    }
}
