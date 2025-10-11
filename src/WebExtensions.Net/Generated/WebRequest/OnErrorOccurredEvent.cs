using JsBind.Net;
using System;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.WebRequest;

// Type Class
/// <summary>Fired when an error occurs.</summary>
[BindAllProperties]
public partial class OnErrorOccurredEvent : Event
{
    /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
    /// <param name="callback">Fired when an error occurs.</param>
    [JsAccessPath("addListener")]
    public virtual void AddListener(Action<OnErrorOccurredEventCallbackDetails> callback)
        => InvokeVoid("addListener", callback);

    /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
    /// <param name="callback">Fired when an error occurs.</param>
    /// <param name="filter">A set of filters that restricts the events that will be sent to this listener.</param>
    [JsAccessPath("addListener")]
    public virtual void AddListener(Action<OnErrorOccurredEventCallbackDetails> callback, RequestFilter filter)
        => InvokeVoid("addListener", callback, filter);

    /// <summary></summary>
    /// <param name="callback">Listener whose registration status shall be tested.</param>
    /// <returns>True if <em>callback</em> is registered to the event.</returns>
    [JsAccessPath("hasListener")]
    public virtual bool HasListener(Action<OnErrorOccurredEventCallbackDetails> callback)
        => Invoke<bool>("hasListener", callback);

    /// <summary></summary>
    /// <param name="callback">Listener whose registration status shall be tested.</param>
    /// <param name="filter">A set of filters that restricts the events that will be sent to this listener.</param>
    /// <returns>True if <em>callback</em> is registered to the event.</returns>
    [JsAccessPath("hasListener")]
    public virtual bool HasListener(Action<OnErrorOccurredEventCallbackDetails> callback, RequestFilter filter)
        => Invoke<bool>("hasListener", callback, filter);

    /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
    /// <param name="callback">Listener that shall be unregistered.</param>
    [JsAccessPath("removeListener")]
    public virtual void RemoveListener(Action<OnErrorOccurredEventCallbackDetails> callback)
        => InvokeVoid("removeListener", callback);

    /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
    /// <param name="callback">Listener that shall be unregistered.</param>
    /// <param name="filter">A set of filters that restricts the events that will be sent to this listener.</param>
    [JsAccessPath("removeListener")]
    public virtual void RemoveListener(Action<OnErrorOccurredEventCallbackDetails> callback, RequestFilter filter)
        => InvokeVoid("removeListener", callback, filter);
}
