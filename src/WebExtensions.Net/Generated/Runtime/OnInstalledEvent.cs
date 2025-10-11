﻿using JsBind.Net;
using System;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Runtime;

// Type Class
/// <summary>Fired when the extension is first installed, when the extension is updated to a new version, and when the browser is updated to a new version.</summary>
[BindAllProperties]
public partial class OnInstalledEvent : Event
{
    /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
    /// <param name="callback">Fired when the extension is first installed, when the extension is updated to a new version, and when the browser is updated to a new version.</param>
    [JsAccessPath("addListener")]
    public virtual void AddListener(Action<OnInstalledEventCallbackDetails> callback)
        => InvokeVoid("addListener", callback);

    /// <summary></summary>
    /// <param name="callback">Listener whose registration status shall be tested.</param>
    /// <returns>True if <em>callback</em> is registered to the event.</returns>
    [JsAccessPath("hasListener")]
    public virtual bool HasListener(Action<OnInstalledEventCallbackDetails> callback)
        => Invoke<bool>("hasListener", callback);

    /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
    /// <param name="callback">Listener that shall be unregistered.</param>
    [JsAccessPath("removeListener")]
    public virtual void RemoveListener(Action<OnInstalledEventCallbackDetails> callback)
        => InvokeVoid("removeListener", callback);
}
