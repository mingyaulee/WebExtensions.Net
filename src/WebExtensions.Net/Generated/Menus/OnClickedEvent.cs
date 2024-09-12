using JsBind.Net;
using System;
using WebExtensions.Net.Events;
using WebExtensions.Net.Tabs;

namespace WebExtensions.Net.Menus
{
    // Type Class
    /// <summary>Fired when a context menu item is clicked.</summary>
    [BindAllProperties]
    public partial class OnClickedEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when a context menu item is clicked.</param>
        [JsAccessPath("addListener")]
        public virtual void AddListener(Action<OnClickData, Tab> callback)
            => InvokeVoid("addListener", callback);

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        [JsAccessPath("hasListener")]
        public virtual bool HasListener(Action<OnClickData, Tab> callback)
            => Invoke<bool>("hasListener", callback);

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        [JsAccessPath("removeListener")]
        public virtual void RemoveListener(Action<OnClickData, Tab> callback)
            => InvokeVoid("removeListener", callback);
    }
}
