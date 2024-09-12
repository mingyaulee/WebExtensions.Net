using JsBind.Net;
using System;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Omnibox
{
    // Type Class
    /// <summary>User has deleted a suggested result.</summary>
    [BindAllProperties]
    public partial class OnDeleteSuggestionEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">User has deleted a suggested result.</param>
        [JsAccessPath("addListener")]
        public virtual void AddListener(Action<string> callback)
            => InvokeVoid("addListener", callback);

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        [JsAccessPath("hasListener")]
        public virtual bool HasListener(Action<string> callback)
            => Invoke<bool>("hasListener", callback);

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        [JsAccessPath("removeListener")]
        public virtual void RemoveListener(Action<string> callback)
            => InvokeVoid("removeListener", callback);
    }
}
