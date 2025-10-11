using JsBind.Net;
using System;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.History;

// Type Class
/// <summary>Fired when one or more URLs are removed from the history service.  When all visits have been removed the URL is purged from history.</summary>
[BindAllProperties]
public partial class OnVisitRemovedEvent : Event
{
    /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
    /// <param name="callback">Fired when one or more URLs are removed from the history service.  When all visits have been removed the URL is purged from history.</param>
    [JsAccessPath("addListener")]
    public virtual void AddListener(Action<Removed> callback)
        => InvokeVoid("addListener", callback);

    /// <summary></summary>
    /// <param name="callback">Listener whose registration status shall be tested.</param>
    /// <returns>True if <em>callback</em> is registered to the event.</returns>
    [JsAccessPath("hasListener")]
    public virtual bool HasListener(Action<Removed> callback)
        => Invoke<bool>("hasListener", callback);

    /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
    /// <param name="callback">Listener that shall be unregistered.</param>
    [JsAccessPath("removeListener")]
    public virtual void RemoveListener(Action<Removed> callback)
        => InvokeVoid("removeListener", callback);
}
