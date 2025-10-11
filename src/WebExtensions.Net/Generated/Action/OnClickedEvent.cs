using JsBind.Net;
using System;
using WebExtensions.Net.Events;
using WebExtensions.Net.Tabs;

namespace WebExtensions.Net.ActionNs;

// Type Class
/// <summary>Fired when a browser action icon is clicked.  This event will not fire if the browser action has a popup.</summary>
[BindAllProperties]
public partial class OnClickedEvent : Event
{
    /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
    /// <param name="callback">Fired when a browser action icon is clicked.  This event will not fire if the browser action has a popup.</param>
    [JsAccessPath("addListener")]
    public virtual void AddListener(Action<Tab, OnClickData> callback)
        => InvokeVoid("addListener", callback);

    /// <summary></summary>
    /// <param name="callback">Listener whose registration status shall be tested.</param>
    /// <returns>True if <em>callback</em> is registered to the event.</returns>
    [JsAccessPath("hasListener")]
    public virtual bool HasListener(Action<Tab, OnClickData> callback)
        => Invoke<bool>("hasListener", callback);

    /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
    /// <param name="callback">Listener that shall be unregistered.</param>
    [JsAccessPath("removeListener")]
    public virtual void RemoveListener(Action<Tab, OnClickData> callback)
        => InvokeVoid("removeListener", callback);
}
