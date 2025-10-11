using JsBind.Net;
using System;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Runtime;

// Type Class
/// <summary>Fired when a message is sent from either an extension process or a content script.</summary>
[BindAllProperties]
public partial class OnMessageEvent : Event
{
    /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
    /// <param name="callback">Fired when a message is sent from either an extension process or a content script.</param>
    [JsAccessPath("addListener")]
    public virtual void AddListener(Func<object, MessageSender, Action, bool> callback)
        => InvokeVoid("addListener", callback);

    /// <summary></summary>
    /// <param name="callback">Listener whose registration status shall be tested.</param>
    /// <returns>True if <em>callback</em> is registered to the event.</returns>
    [JsAccessPath("hasListener")]
    public virtual bool HasListener(Func<object, MessageSender, Action, bool> callback)
        => Invoke<bool>("hasListener", callback);

    /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
    /// <param name="callback">Listener that shall be unregistered.</param>
    [JsAccessPath("removeListener")]
    public virtual void RemoveListener(Func<object, MessageSender, Action, bool> callback)
        => InvokeVoid("removeListener", callback);
}
