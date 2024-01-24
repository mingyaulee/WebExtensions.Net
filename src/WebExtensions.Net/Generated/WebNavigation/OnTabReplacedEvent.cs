using JsBind.Net;
using System;
using System.Threading.Tasks;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.WebNavigation
{
    // Type Class
    /// <summary>Fired when the contents of the tab is replaced by a different (usually previously pre-rendered) tab.</summary>
    [BindAllProperties]
    public partial class OnTabReplacedEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when the contents of the tab is replaced by a different (usually previously pre-rendered) tab.</param>
        public virtual ValueTask AddListener(Action<OnTabReplacedEventCallbackDetails> callback)
        {
            return InvokeVoidAsync("addListener", callback);
        }

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        public virtual ValueTask<bool> HasListener(Action<OnTabReplacedEventCallbackDetails> callback)
        {
            return InvokeAsync<bool>("hasListener", callback);
        }

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        public virtual ValueTask RemoveListener(Action<OnTabReplacedEventCallbackDetails> callback)
        {
            return InvokeVoidAsync("removeListener", callback);
        }
    }
}
