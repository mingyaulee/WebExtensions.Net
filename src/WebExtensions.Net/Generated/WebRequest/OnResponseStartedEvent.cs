using JsBind.Net;
using System;
using System.Collections.Generic;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.WebRequest
{
    // Type Class
    /// <summary>Fired when the first byte of the response body is received. For HTTP requests, this means that the status line and response headers are available.</summary>
    [BindAllProperties]
    public partial class OnResponseStartedEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when the first byte of the response body is received. For HTTP requests, this means that the status line and response headers are available.</param>
        [JsAccessPath("addListener")]
        public virtual void AddListener(Action<OnResponseStartedEventCallbackDetails> callback)
            => InvokeVoid("addListener", callback);

        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when the first byte of the response body is received. For HTTP requests, this means that the status line and response headers are available.</param>
        /// <param name="filter">A set of filters that restricts the events that will be sent to this listener.</param>
        /// <param name="extraInfoSpec">Array of extra information that should be passed to the listener function.</param>
        [JsAccessPath("addListener")]
        public virtual void AddListener(Action<OnResponseStartedEventCallbackDetails> callback, RequestFilter filter, IEnumerable<OnResponseStartedOptions> extraInfoSpec)
            => InvokeVoid("addListener", callback, filter, extraInfoSpec);

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        [JsAccessPath("hasListener")]
        public virtual bool HasListener(Action<OnResponseStartedEventCallbackDetails> callback)
            => Invoke<bool>("hasListener", callback);

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <param name="filter">A set of filters that restricts the events that will be sent to this listener.</param>
        /// <param name="extraInfoSpec">Array of extra information that should be passed to the listener function.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        [JsAccessPath("hasListener")]
        public virtual bool HasListener(Action<OnResponseStartedEventCallbackDetails> callback, RequestFilter filter, IEnumerable<OnResponseStartedOptions> extraInfoSpec)
            => Invoke<bool>("hasListener", callback, filter, extraInfoSpec);

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        [JsAccessPath("removeListener")]
        public virtual void RemoveListener(Action<OnResponseStartedEventCallbackDetails> callback)
            => InvokeVoid("removeListener", callback);

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        /// <param name="filter">A set of filters that restricts the events that will be sent to this listener.</param>
        /// <param name="extraInfoSpec">Array of extra information that should be passed to the listener function.</param>
        [JsAccessPath("removeListener")]
        public virtual void RemoveListener(Action<OnResponseStartedEventCallbackDetails> callback, RequestFilter filter, IEnumerable<OnResponseStartedOptions> extraInfoSpec)
            => InvokeVoid("removeListener", callback, filter, extraInfoSpec);
    }
}
