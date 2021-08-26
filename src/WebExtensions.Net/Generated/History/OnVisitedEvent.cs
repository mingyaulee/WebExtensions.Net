using JsBind.Net;
using System;
using System.Threading.Tasks;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.History
{
    // Type Class
    /// <summary>Fired when a URL is visited, providing the HistoryItem data for that URL.  This event fires before the page has loaded.</summary>
    [BindAllProperties]
    public partial class OnVisitedEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when a URL is visited, providing the HistoryItem data for that URL.  This event fires before the page has loaded.</param>
        public virtual ValueTask AddListener(Action<HistoryItem> callback)
        {
            return InvokeVoidAsync("addListener", callback);
        }

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        public virtual ValueTask<bool> HasListener(Action<HistoryItem> callback)
        {
            return InvokeAsync<bool>("hasListener", callback);
        }

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        public virtual ValueTask RemoveListener(Action<HistoryItem> callback)
        {
            return InvokeVoidAsync("removeListener", callback);
        }
    }
}
