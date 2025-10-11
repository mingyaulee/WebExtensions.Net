using JsBind.Net;
using System;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.History;

// Type Class
/// <summary>Fired when the title of a URL is changed in the browser history.</summary>
[BindAllProperties]
public partial class OnTitleChangedEvent : Event
{
    /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
    /// <param name="callback">Fired when the title of a URL is changed in the browser history.</param>
    [JsAccessPath("addListener")]
    public virtual void AddListener(Action<Changed> callback)
        => InvokeVoid("addListener", callback);

    /// <summary></summary>
    /// <param name="callback">Listener whose registration status shall be tested.</param>
    /// <returns>True if <em>callback</em> is registered to the event.</returns>
    [JsAccessPath("hasListener")]
    public virtual bool HasListener(Action<Changed> callback)
        => Invoke<bool>("hasListener", callback);

    /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
    /// <param name="callback">Listener that shall be unregistered.</param>
    [JsAccessPath("removeListener")]
    public virtual void RemoveListener(Action<Changed> callback)
        => InvokeVoid("removeListener", callback);
}
