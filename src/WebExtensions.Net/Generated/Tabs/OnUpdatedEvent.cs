using JsBind.Net;
using System;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary>Fired when a tab is updated.</summary>
    [BindAllProperties]
    public partial class OnUpdatedEvent : Event
    {
        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when a tab is updated.</param>
        [JsAccessPath("addListener")]
        public virtual void AddListener(Action<int, ChangeInfo, Tab> callback)
            => InvokeVoid("addListener", callback);

        /// <summary>Registers an event listener <em>callback</em> to an event.</summary>
        /// <param name="callback">Fired when a tab is updated.</param>
        /// <param name="filter">A set of filters that restricts the events that will be sent to this listener.</param>
        [JsAccessPath("addListener")]
        public virtual void AddListener(Action<int, ChangeInfo, Tab> callback, UpdateFilter filter)
            => InvokeVoid("addListener", callback, filter);

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        [JsAccessPath("hasListener")]
        public virtual bool HasListener(Action<int, ChangeInfo, Tab> callback)
            => Invoke<bool>("hasListener", callback);

        /// <summary></summary>
        /// <param name="callback">Listener whose registration status shall be tested.</param>
        /// <param name="filter">A set of filters that restricts the events that will be sent to this listener.</param>
        /// <returns>True if <em>callback</em> is registered to the event.</returns>
        [JsAccessPath("hasListener")]
        public virtual bool HasListener(Action<int, ChangeInfo, Tab> callback, UpdateFilter filter)
            => Invoke<bool>("hasListener", callback, filter);

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        [JsAccessPath("removeListener")]
        public virtual void RemoveListener(Action<int, ChangeInfo, Tab> callback)
            => InvokeVoid("removeListener", callback);

        /// <summary>Deregisters an event listener <em>callback</em> from an event.</summary>
        /// <param name="callback">Listener that shall be unregistered.</param>
        /// <param name="filter">A set of filters that restricts the events that will be sent to this listener.</param>
        [JsAccessPath("removeListener")]
        public virtual void RemoveListener(Action<int, ChangeInfo, Tab> callback, UpdateFilter filter)
            => InvokeVoid("removeListener", callback, filter);
    }
}
