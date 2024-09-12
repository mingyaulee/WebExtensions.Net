using JsBind.Net;
using System;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Downloads
{
    // Type Class
    /// <summary>When any of a <see href='#type-DownloadItem'>DownloadItem</see>'s properties except <c>bytesReceived</c> changes, this event fires with the <c>downloadId</c> and an object containing the properties that changed.</summary>
    [BindAllProperties]
    public partial class OnChangedEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">When any of a <see href='#type-DownloadItem'>DownloadItem</see>'s properties except <c>bytesReceived</c> changes, this event fires with the <c>downloadId</c> and an object containing the properties that changed.</param>
        [JsAccessPath("addListener")]
        public virtual void AddListener(Action<DownloadDelta> callback)
            => InvokeVoid("addListener", callback);

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        [JsAccessPath("hasListener")]
        public virtual bool HasListener(Action<DownloadDelta> callback)
            => Invoke<bool>("hasListener", callback);

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        [JsAccessPath("removeListener")]
        public virtual void RemoveListener(Action<DownloadDelta> callback)
            => InvokeVoid("removeListener", callback);
    }
}
