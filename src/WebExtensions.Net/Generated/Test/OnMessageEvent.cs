using JsBind.Net;
using System;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Test;

// Type Class
/// <summary>Used to test sending messages to extensions.</summary>
[BindAllProperties]
public partial class OnMessageEvent : Event
{
    /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
    /// <param name="callback">Used to test sending messages to extensions.</param>
    [JsAccessPath("addListener")]
    public virtual void AddListener(Action<string, object> callback)
        => InvokeVoid("addListener", callback);

    /// <summary></summary>
    /// <param name="callback">Listener whose registration status shall be tested.</param>
    /// <returns>True if <em>callback</em> is registered to the event.</returns>
    [JsAccessPath("hasListener")]
    public virtual bool HasListener(Action<string, object> callback)
        => Invoke<bool>("hasListener", callback);

    /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
    /// <param name="callback">Listener that shall be unregistered.</param>
    [JsAccessPath("removeListener")]
    public virtual void RemoveListener(Action<string, object> callback)
        => InvokeVoid("removeListener", callback);
}
