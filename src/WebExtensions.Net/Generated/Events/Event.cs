using JsBind.Net;
using System;

namespace WebExtensions.Net.Events;

// Type Class
/// <summary>An object which allows the addition and removal of listeners for a Chrome event.</summary>
[BindAllProperties]
public partial class Event : BaseObject
{
    /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
    /// <param name="callback">Called when an event occurs. The parameters of this function depend on the type of event.</param>
    [JsAccessPath("addListener")]
    public virtual void AddListener(Action callback)
        => InvokeVoid("addListener", callback);

    /// <summary></summary>
    /// <param name="callback">Listener whose registration status shall be tested.</param>
    /// <returns>True if <em>callback</em> is registered to the event.</returns>
    [JsAccessPath("hasListener")]
    public virtual bool HasListener(Action callback)
        => Invoke<bool>("hasListener", callback);

    /// <summary></summary>
    /// <returns>True if any event listeners are registered to the event.</returns>
    [JsAccessPath("hasListeners")]
    public virtual bool HasListeners()
        => Invoke<bool>("hasListeners");

    /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
    /// <param name="callback">Listener that shall be unregistered.</param>
    [JsAccessPath("removeListener")]
    public virtual void RemoveListener(Action callback)
        => InvokeVoid("removeListener", callback);
}
