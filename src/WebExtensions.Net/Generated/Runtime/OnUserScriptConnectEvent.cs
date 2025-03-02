using JsBind.Net;
using System;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Runtime
{
    // Type Class
    /// <summary>Fired when a connection is made from a USER_SCRIPT world registered through the userScripts API.</summary>
    [BindAllProperties]
    public partial class OnUserScriptConnectEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when a connection is made from a USER_SCRIPT world registered through the userScripts API.</param>
        [JsAccessPath("addListener")]
        public virtual void AddListener(Action<Port> callback)
            => InvokeVoid("addListener", callback);

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        [JsAccessPath("hasListener")]
        public virtual bool HasListener(Action<Port> callback)
            => Invoke<bool>("hasListener", callback);

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        [JsAccessPath("removeListener")]
        public virtual void RemoveListener(Action<Port> callback)
            => InvokeVoid("removeListener", callback);
    }
}
