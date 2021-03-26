using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Events
{
    // Class Definition
    /// <summary>
    /// An object which allows the addition and removal of listeners for a Chrome event.
    /// </summary>
    public class Event : BaseObject
    {
        
        // Function Definition
        /// <summary>
        /// Registers an event listener <em>callback</em> to an event.
        /// </summary>
        public virtual ValueTask AddListener()
        {
            return InvokeVoidAsync("addListener");
        }
        
        // Function Definition
        /// <summary>
        /// Deregisters an event listener <em>callback</em> from an event.
        /// </summary>
        public virtual ValueTask RemoveListener()
        {
            return InvokeVoidAsync("removeListener");
        }
        
        // Function Definition
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual ValueTask<bool> HasListener()
        {
            return InvokeAsync<bool>("hasListener");
        }
        
        // Function Definition
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual ValueTask<bool> HasListeners()
        {
            return InvokeAsync<bool>("hasListeners");
        }
    }
}

