﻿using JsBind.Net;
using System;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Tabs;

// Type Class
/// <summary>Fired when a tab is replaced with another tab due to prerendering or instant.</summary>
[BindAllProperties]
public partial class OnReplacedEvent : Event
{
    /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
    /// <param name="callback">Fired when a tab is replaced with another tab due to prerendering or instant.</param>
    [JsAccessPath("addListener")]
    public virtual void AddListener(Action<int, int> callback)
        => InvokeVoid("addListener", callback);

    /// <summary></summary>
    /// <param name="callback">Listener whose registration status shall be tested.</param>
    /// <returns>True if <em>callback</em> is registered to the event.</returns>
    [JsAccessPath("hasListener")]
    public virtual bool HasListener(Action<int, int> callback)
        => Invoke<bool>("hasListener", callback);

    /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
    /// <param name="callback">Listener that shall be unregistered.</param>
    [JsAccessPath("removeListener")]
    public virtual void RemoveListener(Action<int, int> callback)
        => InvokeVoid("removeListener", callback);
}
