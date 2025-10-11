using JsBind.Net;
using System;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.UserScripts;

// Type Class
/// <summary>Event called when a new userScript global has been created</summary>
[BindAllProperties]
public partial class OnBeforeScriptEvent : Event
{
    /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
    /// <param name="callback">Event called when a new userScript global has been created</param>
    [JsAccessPath("addListener")]
    public virtual void AddListener(Action<UserScript> callback)
        => InvokeVoid("addListener", callback);

    /// <summary></summary>
    /// <param name="callback">Listener whose registration status shall be tested.</param>
    /// <returns>True if <em>callback</em> is registered to the event.</returns>
    [JsAccessPath("hasListener")]
    public virtual bool HasListener(Action<UserScript> callback)
        => Invoke<bool>("hasListener", callback);

    /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
    /// <param name="callback">Listener that shall be unregistered.</param>
    [JsAccessPath("removeListener")]
    public virtual void RemoveListener(Action<UserScript> callback)
        => InvokeVoid("removeListener", callback);
}
