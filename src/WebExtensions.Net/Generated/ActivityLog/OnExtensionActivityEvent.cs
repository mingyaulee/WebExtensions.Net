using JsBind.Net;
using System;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.ActivityLog;

// Type Class
/// <summary>Receives an activityItem for each logging event.</summary>
[BindAllProperties]
public partial class OnExtensionActivityEvent : Event
{
    /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
    /// <param name="callback">Receives an activityItem for each logging event.</param>
    [JsAccessPath("addListener")]
    public virtual void AddListener(Action<Details> callback)
        => InvokeVoid("addListener", callback);

    /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
    /// <param name="callback">Receives an activityItem for each logging event.</param>
    /// <param name="id"></param>
    [JsAccessPath("addListener")]
    public virtual void AddListener(Action<Details> callback, string id)
        => InvokeVoid("addListener", callback, id);

    /// <summary></summary>
    /// <param name="callback">Listener whose registration status shall be tested.</param>
    /// <returns>True if <em>callback</em> is registered to the event.</returns>
    [JsAccessPath("hasListener")]
    public virtual bool HasListener(Action<Details> callback)
        => Invoke<bool>("hasListener", callback);

    /// <summary></summary>
    /// <param name="callback">Listener whose registration status shall be tested.</param>
    /// <param name="id"></param>
    /// <returns>True if <em>callback</em> is registered to the event.</returns>
    [JsAccessPath("hasListener")]
    public virtual bool HasListener(Action<Details> callback, string id)
        => Invoke<bool>("hasListener", callback, id);

    /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
    /// <param name="callback">Listener that shall be unregistered.</param>
    [JsAccessPath("removeListener")]
    public virtual void RemoveListener(Action<Details> callback)
        => InvokeVoid("removeListener", callback);

    /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
    /// <param name="callback">Listener that shall be unregistered.</param>
    /// <param name="id"></param>
    [JsAccessPath("removeListener")]
    public virtual void RemoveListener(Action<Details> callback, string id)
        => InvokeVoid("removeListener", callback, id);
}
