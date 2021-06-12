using System;
using System.Threading.Tasks;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Downloads
{
    // Type Class
    /// <summary>This event fires with the <see href='#type-DownloadItem'>DownloadItem</see> object when a download begins.</summary>
    public partial class OnCreatedEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">This event fires with the <see href='#type-DownloadItem'>DownloadItem</see> object when a download begins.</param>
        public virtual ValueTask AddListener(Action<DownloadItem> callback)
        {
            return InvokeVoidAsync("addListener", callback);
        }

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        public virtual ValueTask<bool> HasListener(Action<DownloadItem> callback)
        {
            return InvokeAsync<bool>("hasListener", callback);
        }

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        public virtual ValueTask RemoveListener(Action<DownloadItem> callback)
        {
            return InvokeVoidAsync("removeListener", callback);
        }
    }
}
