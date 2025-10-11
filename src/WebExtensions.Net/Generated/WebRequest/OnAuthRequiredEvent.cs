﻿using JsBind.Net;
using System;
using System.Collections.Generic;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.WebRequest;

// Type Class
/// <summary>Fired when an authentication failure is received. The listener has three options: it can provide authentication credentials, it can cancel the request and display the error page, or it can take no action on the challenge. If bad user credentials are provided, this may be called multiple times for the same request.</summary>
[BindAllProperties]
public partial class OnAuthRequiredEvent : Event
{
    /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
    /// <param name="callback">Fired when an authentication failure is received. The listener has three options: it can provide authentication credentials, it can cancel the request and display the error page, or it can take no action on the challenge. If bad user credentials are provided, this may be called multiple times for the same request.</param>
    [JsAccessPath("addListener")]
    public virtual void AddListener(Func<OnAuthRequiredEventCallbackDetails, Action<BlockingResponse>, BlockingResponse> callback)
        => InvokeVoid("addListener", callback);

    /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
    /// <param name="callback">Fired when an authentication failure is received. The listener has three options: it can provide authentication credentials, it can cancel the request and display the error page, or it can take no action on the challenge. If bad user credentials are provided, this may be called multiple times for the same request.</param>
    /// <param name="filter">A set of filters that restricts the events that will be sent to this listener.</param>
    /// <param name="extraInfoSpec">Array of extra information that should be passed to the listener function.</param>
    [JsAccessPath("addListener")]
    public virtual void AddListener(Func<OnAuthRequiredEventCallbackDetails, Action<BlockingResponse>, BlockingResponse> callback, RequestFilter filter, IEnumerable<OnAuthRequiredOptions> extraInfoSpec)
        => InvokeVoid("addListener", callback, filter, extraInfoSpec);

    /// <summary></summary>
    /// <param name="callback">Listener whose registration status shall be tested.</param>
    /// <returns>True if <em>callback</em> is registered to the event.</returns>
    [JsAccessPath("hasListener")]
    public virtual bool HasListener(Func<OnAuthRequiredEventCallbackDetails, Action<BlockingResponse>, BlockingResponse> callback)
        => Invoke<bool>("hasListener", callback);

    /// <summary></summary>
    /// <param name="callback">Listener whose registration status shall be tested.</param>
    /// <param name="filter">A set of filters that restricts the events that will be sent to this listener.</param>
    /// <param name="extraInfoSpec">Array of extra information that should be passed to the listener function.</param>
    /// <returns>True if <em>callback</em> is registered to the event.</returns>
    [JsAccessPath("hasListener")]
    public virtual bool HasListener(Func<OnAuthRequiredEventCallbackDetails, Action<BlockingResponse>, BlockingResponse> callback, RequestFilter filter, IEnumerable<OnAuthRequiredOptions> extraInfoSpec)
        => Invoke<bool>("hasListener", callback, filter, extraInfoSpec);

    /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
    /// <param name="callback">Listener that shall be unregistered.</param>
    [JsAccessPath("removeListener")]
    public virtual void RemoveListener(Func<OnAuthRequiredEventCallbackDetails, Action<BlockingResponse>, BlockingResponse> callback)
        => InvokeVoid("removeListener", callback);

    /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
    /// <param name="callback">Listener that shall be unregistered.</param>
    /// <param name="filter">A set of filters that restricts the events that will be sent to this listener.</param>
    /// <param name="extraInfoSpec">Array of extra information that should be passed to the listener function.</param>
    [JsAccessPath("removeListener")]
    public virtual void RemoveListener(Func<OnAuthRequiredEventCallbackDetails, Action<BlockingResponse>, BlockingResponse> callback, RequestFilter filter, IEnumerable<OnAuthRequiredOptions> extraInfoSpec)
        => InvokeVoid("removeListener", callback, filter, extraInfoSpec);
}
