using JsBind.Net;
using System;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Windows;

// Type Class
/// <summary>Fired when a window is created.</summary>
[BindAllProperties]
public partial class OnCreatedEvent : Event
{
    /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
    /// <param name="callback">Fired when a window is created.</param>
    [JsAccessPath("addListener")]
    public virtual void AddListener(Action<Window> callback)
        => InvokeVoid("addListener", callback);

    /// <summary></summary>
    /// <param name="callback">Listener whose registration status shall be tested.</param>
    /// <returns>True if <em>callback</em> is registered to the event.</returns>
    [JsAccessPath("hasListener")]
    public virtual bool HasListener(Action<Window> callback)
        => Invoke<bool>("hasListener", callback);

    /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
    /// <param name="callback">Listener that shall be unregistered.</param>
    [JsAccessPath("removeListener")]
    public virtual void RemoveListener(Action<Window> callback)
        => InvokeVoid("removeListener", callback);
}
