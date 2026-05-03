using JsBind.Net;
using System;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.ActionNs;

// Type Class
/// <summary>Fired when user-specified settings relating to an extension's action change.</summary>
[BindAllProperties]
public partial class OnUserSettingsChangedEvent : Event
{
    /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
    /// <param name="callback">Fired when user-specified settings relating to an extension's action change.</param>
    [JsAccessPath("addListener")]
    public virtual void AddListener(Action<Change> callback)
        => InvokeVoid("addListener", callback);

    /// <summary></summary>
    /// <param name="callback">Listener whose registration status shall be tested.</param>
    /// <returns>True if <em>callback</em> is registered to the event.</returns>
    [JsAccessPath("hasListener")]
    public virtual bool HasListener(Action<Change> callback)
        => Invoke<bool>("hasListener", callback);

    /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
    /// <param name="callback">Listener that shall be unregistered.</param>
    [JsAccessPath("removeListener")]
    public virtual void RemoveListener(Action<Change> callback)
        => InvokeVoid("removeListener", callback);
}
