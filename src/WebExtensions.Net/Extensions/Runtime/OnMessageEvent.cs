using System;
using System.Threading.Tasks;
using JsBind.Net;

namespace WebExtensions.Net.Runtime
{
    public partial class OnMessageEvent
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when a message is sent from either an extension process or a content script.</param>
        [JsAccessPath("addListener")]
        public virtual ValueTask AddListener(Func<object, MessageSender, Action<object>, bool> callback)
        {
            return InvokeVoidAsync("addListener", callback);
        }

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        [JsAccessPath("hasListener")]
        public virtual ValueTask<bool> HasListener(Func<object, MessageSender, Action<object>, bool> callback)
        {
            return InvokeAsync<bool>("hasListener", callback);
        }

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        [JsAccessPath("removeListener")]
        public virtual ValueTask RemoveListener(Func<object, MessageSender, Action<object>, bool> callback)
        {
            return InvokeVoidAsync("removeListener", callback);
        }
    }
}
