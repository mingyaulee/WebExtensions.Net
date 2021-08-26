using JsBind.Net;
using System;
using System.Threading.Tasks;
using WebExtensions.Net.Events;
using WebExtensions.Net.Tabs;

namespace WebExtensions.Net.Menus
{
    // Type Class
    /// <summary>Fired when a menu is shown. The extension can add, modify or remove menu items and call menus.refresh() to update the menu.</summary>
    [BindAllProperties]
    public partial class OnShownEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when a menu is shown. The extension can add, modify or remove menu items and call menus.refresh() to update the menu.</param>
        public virtual ValueTask AddListener(Action<AddListenerCallbackInfo, Tab> callback)
        {
            return InvokeVoidAsync("addListener", callback);
        }

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        public virtual ValueTask<bool> HasListener(Action<HasListenerCallbackInfo, Tab> callback)
        {
            return InvokeAsync<bool>("hasListener", callback);
        }

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        public virtual ValueTask RemoveListener(Action<RemoveListenerCallbackInfo, Tab> callback)
        {
            return InvokeVoidAsync("removeListener", callback);
        }
    }
}
