using JsBind.Net;
using System;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Permissions
{
    // Type Class
    /// <summary>Fired when the extension acquires new permissions.</summary>
    [BindAllProperties]
    public partial class OnAddedEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when the extension acquires new permissions.</param>
        [JsAccessPath("addListener")]
        public virtual void AddListener(Action<PermissionsType> callback)
            => InvokeVoid("addListener", callback);

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        [JsAccessPath("hasListener")]
        public virtual bool HasListener(Action<PermissionsType> callback)
            => Invoke<bool>("hasListener", callback);

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        [JsAccessPath("removeListener")]
        public virtual void RemoveListener(Action<PermissionsType> callback)
            => InvokeVoid("removeListener", callback);
    }
}
