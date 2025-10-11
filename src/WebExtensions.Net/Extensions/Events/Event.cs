using System;
using JsBind.Net;

namespace WebExtensions.Net.Events;

public partial class Event
{
    /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
    /// <param name="callback">Called when an event occurs. The parameters of this function depend on the type of event.</param>
    [JsAccessPath("addListener")]
    public virtual void AddListener(Delegate callback)
        => InvokeVoid("addListener", callback);

    /// <summary></summary>
    /// <param name="callback">Listener whose registration status shall be tested.</param>
    /// <returns>True if <em>callback</em> is registered to the event.</returns>
    [JsAccessPath("hasListener")]
    public virtual bool HasListener(Delegate callback)
        => Invoke<bool>("hasListener", callback);

    /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
    /// <param name="callback">Listener that shall be unregistered.</param>
    [JsAccessPath("removeListener")]
    public virtual void RemoveListener(Delegate callback)
        => InvokeVoid("removeListener", callback);
}
