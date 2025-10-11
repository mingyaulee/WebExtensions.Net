using JsBind.Net;
using System;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.CaptivePortal;

// Type Class
/// <summary>Fired when the captive portal state changes.</summary>
[BindAllProperties]
public partial class OnStateChangedEvent : Event
{
    /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
    /// <param name="callback">Fired when the captive portal state changes.</param>
    [JsAccessPath("addListener")]
    public virtual void AddListener(Action<Details> callback)
        => InvokeVoid("addListener", callback);

    /// <summary></summary>
    /// <param name="callback">Listener whose registration status shall be tested.</param>
    /// <returns>True if <em>callback</em> is registered to the event.</returns>
    [JsAccessPath("hasListener")]
    public virtual bool HasListener(Action<Details> callback)
        => Invoke<bool>("hasListener", callback);

    /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
    /// <param name="callback">Listener that shall be unregistered.</param>
    [JsAccessPath("removeListener")]
    public virtual void RemoveListener(Action<Details> callback)
        => InvokeVoid("removeListener", callback);
}
