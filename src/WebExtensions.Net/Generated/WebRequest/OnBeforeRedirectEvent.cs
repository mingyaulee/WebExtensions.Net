using JsBind.Net;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.WebRequest
{
    // Type Class
    /// <summary>Fired when a server-initiated redirect is about to occur.</summary>
    [BindAllProperties]
    public partial class OnBeforeRedirectEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when a server-initiated redirect is about to occur.</param>
        public virtual ValueTask AddListener(Action<OnBeforeRedirectEventAddListenerCallbackDetails> callback)
        {
            return InvokeVoidAsync("addListener", callback);
        }

        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when a server-initiated redirect is about to occur.</param>
        /// <param name="filter">A set of filters that restricts the events that will be sent to this listener.</param>
        /// <param name="extraInfoSpec">Array of extra information that should be passed to the listener function.</param>
        public virtual ValueTask AddListener(Action<OnBeforeRedirectEventAddListenerCallbackDetails> callback, RequestFilter filter, IEnumerable<OnBeforeRedirectOptions> extraInfoSpec)
        {
            return InvokeVoidAsync("addListener", callback, filter, extraInfoSpec);
        }

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        public virtual ValueTask<bool> HasListener(Action<OnBeforeRedirectEventHasListenerCallbackDetails> callback)
        {
            return InvokeAsync<bool>("hasListener", callback);
        }

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <param name="filter">A set of filters that restricts the events that will be sent to this listener.</param>
        /// <param name="extraInfoSpec">Array of extra information that should be passed to the listener function.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        public virtual ValueTask<bool> HasListener(Action<OnBeforeRedirectEventHasListenerCallbackDetails> callback, RequestFilter filter, IEnumerable<OnBeforeRedirectOptions> extraInfoSpec)
        {
            return InvokeAsync<bool>("hasListener", callback, filter, extraInfoSpec);
        }

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        public virtual ValueTask RemoveListener(Action<OnBeforeRedirectEventRemoveListenerCallbackDetails> callback)
        {
            return InvokeVoidAsync("removeListener", callback);
        }

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        /// <param name="filter">A set of filters that restricts the events that will be sent to this listener.</param>
        /// <param name="extraInfoSpec">Array of extra information that should be passed to the listener function.</param>
        public virtual ValueTask RemoveListener(Action<OnBeforeRedirectEventRemoveListenerCallbackDetails> callback, RequestFilter filter, IEnumerable<OnBeforeRedirectOptions> extraInfoSpec)
        {
            return InvokeVoidAsync("removeListener", callback, filter, extraInfoSpec);
        }
    }
}
