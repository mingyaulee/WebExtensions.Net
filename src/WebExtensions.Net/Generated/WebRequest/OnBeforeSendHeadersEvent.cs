﻿using JsBind.Net;
using System;
using System.Collections.Generic;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.WebRequest;

// Type Class
/// <summary>Fired before sending an HTTP request, once the request headers are available. This may occur after a TCP connection is made to the server, but before any HTTP data is sent. </summary>
[BindAllProperties]
public partial class OnBeforeSendHeadersEvent : Event
{
    /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
    /// <param name="callback">Fired before sending an HTTP request, once the request headers are available. This may occur after a TCP connection is made to the server, but before any HTTP data is sent. </param>
    [JsAccessPath("addListener")]
    public virtual void AddListener(Func<OnBeforeSendHeadersEventCallbackDetails, BlockingResponse> callback)
        => InvokeVoid("addListener", callback);

    /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
    /// <param name="callback">Fired before sending an HTTP request, once the request headers are available. This may occur after a TCP connection is made to the server, but before any HTTP data is sent. </param>
    /// <param name="filter">A set of filters that restricts the events that will be sent to this listener.</param>
    /// <param name="extraInfoSpec">Array of extra information that should be passed to the listener function.</param>
    [JsAccessPath("addListener")]
    public virtual void AddListener(Func<OnBeforeSendHeadersEventCallbackDetails, BlockingResponse> callback, RequestFilter filter, IEnumerable<OnBeforeSendHeadersOptions> extraInfoSpec)
        => InvokeVoid("addListener", callback, filter, extraInfoSpec);

    /// <summary></summary>
    /// <param name="callback">Listener whose registration status shall be tested.</param>
    /// <returns>True if <em>callback</em> is registered to the event.</returns>
    [JsAccessPath("hasListener")]
    public virtual bool HasListener(Func<OnBeforeSendHeadersEventCallbackDetails, BlockingResponse> callback)
        => Invoke<bool>("hasListener", callback);

    /// <summary></summary>
    /// <param name="callback">Listener whose registration status shall be tested.</param>
    /// <param name="filter">A set of filters that restricts the events that will be sent to this listener.</param>
    /// <param name="extraInfoSpec">Array of extra information that should be passed to the listener function.</param>
    /// <returns>True if <em>callback</em> is registered to the event.</returns>
    [JsAccessPath("hasListener")]
    public virtual bool HasListener(Func<OnBeforeSendHeadersEventCallbackDetails, BlockingResponse> callback, RequestFilter filter, IEnumerable<OnBeforeSendHeadersOptions> extraInfoSpec)
        => Invoke<bool>("hasListener", callback, filter, extraInfoSpec);

    /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
    /// <param name="callback">Listener that shall be unregistered.</param>
    [JsAccessPath("removeListener")]
    public virtual void RemoveListener(Func<OnBeforeSendHeadersEventCallbackDetails, BlockingResponse> callback)
        => InvokeVoid("removeListener", callback);

    /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
    /// <param name="callback">Listener that shall be unregistered.</param>
    /// <param name="filter">A set of filters that restricts the events that will be sent to this listener.</param>
    /// <param name="extraInfoSpec">Array of extra information that should be passed to the listener function.</param>
    [JsAccessPath("removeListener")]
    public virtual void RemoveListener(Func<OnBeforeSendHeadersEventCallbackDetails, BlockingResponse> callback, RequestFilter filter, IEnumerable<OnBeforeSendHeadersOptions> extraInfoSpec)
        => InvokeVoid("removeListener", callback, filter, extraInfoSpec);
}
