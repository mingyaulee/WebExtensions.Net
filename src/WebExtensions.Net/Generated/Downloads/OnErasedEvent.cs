using JsBind.Net;
using System;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Downloads
{
    // Type Class
    /// <summary>Fires with the <c>downloadId</c> when a download is erased from history.</summary>
    [BindAllProperties]
    public partial class OnErasedEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fires with the <c>downloadId</c> when a download is erased from history.</param>
        [JsAccessPath("addListener")]
        public virtual void AddListener(Action<int> callback)
            => InvokeVoid("addListener", callback);

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        [JsAccessPath("hasListener")]
        public virtual bool HasListener(Action<int> callback)
            => Invoke<bool>("hasListener", callback);

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        [JsAccessPath("removeListener")]
        public virtual void RemoveListener(Action<int> callback)
            => InvokeVoid("removeListener", callback);
    }
}
