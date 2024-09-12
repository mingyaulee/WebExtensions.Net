using JsBind.Net;
using System;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Downloads
{
    // Type Class
    /// <summary>This event fires with the <see href='#type-DownloadItem'>DownloadItem</see> object when a download begins.</summary>
    [BindAllProperties]
    public partial class OnCreatedEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">This event fires with the <see href='#type-DownloadItem'>DownloadItem</see> object when a download begins.</param>
        [JsAccessPath("addListener")]
        public virtual void AddListener(Action<DownloadItem> callback)
            => InvokeVoid("addListener", callback);

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        [JsAccessPath("hasListener")]
        public virtual bool HasListener(Action<DownloadItem> callback)
            => Invoke<bool>("hasListener", callback);

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        [JsAccessPath("removeListener")]
        public virtual void RemoveListener(Action<DownloadItem> callback)
            => InvokeVoid("removeListener", callback);
    }
}
