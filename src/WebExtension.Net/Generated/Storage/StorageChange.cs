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
    public class StorageChange
    {
        
        // Property Definition
        /// <summary>
        /// The old value of the item, if there was an old value.
        /// </summary>
        [JsonPropertyName("oldValue")]
        public object OldValue { get; set; }
        
        // Property Definition
        /// <summary>
        /// The new value of the item, if there is a new value.
        /// </summary>
        [JsonPropertyName("newValue")]
        public object NewValue { get; set; }
    }
}

