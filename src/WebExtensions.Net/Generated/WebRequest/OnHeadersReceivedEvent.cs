using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebExtension.Net.Events;

namespace WebExtension.Net.WebRequest
{
    // Type Class
    /// <summary>Fired when HTTP response headers of a request have been received.</summary>
    public class OnHeadersReceivedEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when HTTP response headers of a request have been received.</param>
        public virtual ValueTask AddListener(Func<OnHeadersReceivedEventAddListenerCallbackDetails, BlockingResponse> callback)
        {
            return InvokeVoidAsync("addListener", callback);
        }

        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when HTTP response headers of a request have been received.</param>
        /// <param name="filter">A set of filters that restricts the events that will be sent to this listener.</param>
        /// <param name="extraInfoSpec">Array of extra information that should be passed to the listener function.</param>
        public virtual ValueTask AddListener(Func<OnHeadersReceivedEventAddListenerCallbackDetails, BlockingResponse> callback, RequestFilter filter, IEnumerable<OnHeadersReceivedOptions> extraInfoSpec)
        {
            return InvokeVoidAsync("addListener", callback, filter, extraInfoSpec);
        }

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        public virtual ValueTask<bool> HasListener(Func<OnHeadersReceivedEventHasListenerCallbackDetails, BlockingResponse> callback)
        {
            return InvokeAsync<bool>("hasListener", callback);
        }

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <param name="filter">A set of filters that restricts the events that will be sent to this listener.</param>
        /// <param name="extraInfoSpec">Array of extra information that should be passed to the listener function.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        public virtual ValueTask<bool> HasListener(Func<OnHeadersReceivedEventHasListenerCallbackDetails, BlockingResponse> callback, RequestFilter filter, IEnumerable<OnHeadersReceivedOptions> extraInfoSpec)
        {
            return InvokeAsync<bool>("hasListener", callback, filter, extraInfoSpec);
        }

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        public virtual ValueTask RemoveListener(Func<OnHeadersReceivedEventRemoveListenerCallbackDetails, BlockingResponse> callback)
        {
            return InvokeVoidAsync("removeListener", callback);
        }

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        /// <param name="filter">A set of filters that restricts the events that will be sent to this listener.</param>
        /// <param name="extraInfoSpec">Array of extra information that should be passed to the listener function.</param>
        public virtual ValueTask RemoveListener(Func<OnHeadersReceivedEventRemoveListenerCallbackDetails, BlockingResponse> callback, RequestFilter filter, IEnumerable<OnHeadersReceivedOptions> extraInfoSpec)
        {
            return InvokeVoidAsync("removeListener", callback, filter, extraInfoSpec);
        }
    }
}
