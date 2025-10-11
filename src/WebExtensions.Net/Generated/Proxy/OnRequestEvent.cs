﻿using JsBind.Net;
using System;
using System.Collections.Generic;
using WebExtensions.Net.Events;
using WebExtensions.Net.WebRequest;

namespace WebExtensions.Net.Proxy;

// Type Class
/// <summary>Fired when proxy data is needed for a request.</summary>
[BindAllProperties]
public partial class OnRequestEvent : Event
{
    /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
    /// <param name="callback">Fired when proxy data is needed for a request.</param>
    [JsAccessPath("addListener")]
    public virtual void AddListener(Action<Details> callback)
        => InvokeVoid("addListener", callback);

    /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
    /// <param name="callback">Fired when proxy data is needed for a request.</param>
    /// <param name="filter">A set of filters that restricts the events that will be sent to this listener.</param>
    /// <param name="extraInfoSpec">Array of extra information that should be passed to the listener function.</param>
    [JsAccessPath("addListener")]
    public virtual void AddListener(Action<Details> callback, RequestFilter filter, IEnumerable<ExtraInfoSpecArrayItem> extraInfoSpec)
        => InvokeVoid("addListener", callback, filter, extraInfoSpec);

    /// <summary></summary>
    /// <param name="callback">Listener whose registration status shall be tested.</param>
    /// <returns>True if <em>callback</em> is registered to the event.</returns>
    [JsAccessPath("hasListener")]
    public virtual bool HasListener(Action<Details> callback)
        => Invoke<bool>("hasListener", callback);

    /// <summary></summary>
    /// <param name="callback">Listener whose registration status shall be tested.</param>
    /// <param name="filter">A set of filters that restricts the events that will be sent to this listener.</param>
    /// <param name="extraInfoSpec">Array of extra information that should be passed to the listener function.</param>
    /// <returns>True if <em>callback</em> is registered to the event.</returns>
    [JsAccessPath("hasListener")]
    public virtual bool HasListener(Action<Details> callback, RequestFilter filter, IEnumerable<ExtraInfoSpecArrayItem> extraInfoSpec)
        => Invoke<bool>("hasListener", callback, filter, extraInfoSpec);

    /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
    /// <param name="callback">Listener that shall be unregistered.</param>
    [JsAccessPath("removeListener")]
    public virtual void RemoveListener(Action<Details> callback)
        => InvokeVoid("removeListener", callback);

    /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
    /// <param name="callback">Listener that shall be unregistered.</param>
    /// <param name="filter">A set of filters that restricts the events that will be sent to this listener.</param>
    /// <param name="extraInfoSpec">Array of extra information that should be passed to the listener function.</param>
    [JsAccessPath("removeListener")]
    public virtual void RemoveListener(Action<Details> callback, RequestFilter filter, IEnumerable<ExtraInfoSpecArrayItem> extraInfoSpec)
        => InvokeVoid("removeListener", callback, filter, extraInfoSpec);
}
