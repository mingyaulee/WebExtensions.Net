using System;
using System.Threading.Tasks;
using WebExtension.Net.Events;

namespace WebExtension.Net.Bookmarks
{
    // Type Class
    /// <summary>Fired when a bookmark or folder is removed.  When a folder is removed recursively, a single notification is fired for the folder, and none for its contents.</summary>
    public class OnRemovedEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when a bookmark or folder is removed.  When a folder is removed recursively, a single notification is fired for the folder, and none for its contents.</param>
        public virtual ValueTask AddListener(Action<string, AddListenerCallbackRemoveInfo> callback)
        {
            return InvokeVoidAsync("addListener", callback);
        }

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        public virtual ValueTask<bool> HasListener(Action<string, HasListenerCallbackRemoveInfo> callback)
        {
            return InvokeAsync<bool>("hasListener", callback);
        }

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        public virtual ValueTask RemoveListener(Action<string, RemoveListenerCallbackRemoveInfo> callback)
        {
            return InvokeVoidAsync("removeListener", callback);
        }
    }
}
