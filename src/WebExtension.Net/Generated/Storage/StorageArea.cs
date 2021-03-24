// This file is auto generated at 2021-03-24T04:51:22

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Storage
{
    // Class Definition
    /// <summary>
    /// 
    /// </summary>
    public class StorageArea : BaseObject
    {
        
        // Function Definition
        /// <summary>
        /// Gets one or more items from storage.
        /// </summary>
        /// <param name="keys">A single key to get, list of keys to get, or a dictionary specifying default values (see description of the object).  An empty list or object will return an empty result object.  Pass in <c>null</c> to get the entire contents of storage.</param>
        /// <returns></returns>
        public virtual ValueTask<JsonElement> Get(string keys)
        {
            return webExtensionJSRuntime.InvokeAsync<JsonElement>("", keys);
        }
        
        // Function Definition
        /// <summary>
        /// Gets one or more items from storage.
        /// </summary>
        /// <param name="keys">A single key to get, list of keys to get, or a dictionary specifying default values (see description of the object).  An empty list or object will return an empty result object.  Pass in <c>null</c> to get the entire contents of storage.</param>
        /// <returns></returns>
        public virtual ValueTask<JsonElement> Get(IEnumerable<string> keys)
        {
            return webExtensionJSRuntime.InvokeAsync<JsonElement>("", keys);
        }
        
        // Function Definition
        /// <summary>
        /// Gets one or more items from storage.
        /// </summary>
        /// <param name="keys">A single key to get, list of keys to get, or a dictionary specifying default values (see description of the object).  An empty list or object will return an empty result object.  Pass in <c>null</c> to get the entire contents of storage.</param>
        /// <returns></returns>
        public virtual ValueTask<JsonElement> Get(object keys)
        {
            return webExtensionJSRuntime.InvokeAsync<JsonElement>("", keys);
        }
        
        // Function Definition
        /// <summary>
        /// Sets multiple items.
        /// </summary>
        /// <param name="items"><p>An object which gives each key/value pair to update storage with. Any other key/value pairs in storage will not be affected.</p><p>Primitive values such as numbers will serialize as expected. Values with a <c>typeof</c> <c>"object"</c> and <c>"function"</c> will typically serialize to <c>{}</c>, with the exception of <c>Array</c> (serializes as expected), <c>Date</c>, and <c>Regex</c> (serialize using their <c>String</c> representation).</p></param>
        public virtual ValueTask Set(object items)
        {
            return webExtensionJSRuntime.InvokeVoidAsync("", items);
        }
        
        // Function Definition
        /// <summary>
        /// Removes one or more items from storage.
        /// </summary>
        /// <param name="keys">A single key or a list of keys for items to remove.</param>
        public virtual ValueTask Remove(string keys)
        {
            return webExtensionJSRuntime.InvokeVoidAsync("", keys);
        }
        
        // Function Definition
        /// <summary>
        /// Removes one or more items from storage.
        /// </summary>
        /// <param name="keys">A single key or a list of keys for items to remove.</param>
        public virtual ValueTask Remove(IEnumerable<string> keys)
        {
            return webExtensionJSRuntime.InvokeVoidAsync("", keys);
        }
        
        // Function Definition
        /// <summary>
        /// Removes all items from storage.
        /// </summary>
        public virtual ValueTask Clear()
        {
            return webExtensionJSRuntime.InvokeVoidAsync("");
        }
    }
}

