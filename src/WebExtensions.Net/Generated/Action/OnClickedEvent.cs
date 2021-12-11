using JsBind.Net;
using System;
using System.Threading.Tasks;
using WebExtensions.Net.Events;
using WebExtensions.Net.Tabs;

namespace WebExtensions.Net.ActionNs
{
    // Type Class
    /// <summary>Fired when a browser action icon is clicked.  This event will not fire if the browser action has a popup.</summary>
    [BindAllProperties]
    public partial class OnClickedEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when a browser action icon is clicked.  This event will not fire if the browser action has a popup.</param>
        public virtual ValueTask AddListener(Action<Tab, OnClickData> callback)
        {
            return InvokeVoidAsync("addListener", callback);
        }

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        public virtual ValueTask<bool> HasListener(Action<Tab, OnClickData> callback)
        {
            return InvokeAsync<bool>("hasListener", callback);
        }

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        public virtual ValueTask RemoveListener(Action<Tab, OnClickData> callback)
        {
            return InvokeVoidAsync("removeListener", callback);
        }
    }
}
