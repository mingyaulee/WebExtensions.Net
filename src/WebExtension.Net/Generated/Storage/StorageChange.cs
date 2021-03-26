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
    public class StorageChange : BaseObject
    {
        
        // Property Definition
        private object _oldValue;
        /// <summary>
        /// The old value of the item, if there was an old value.
        /// </summary>
        [JsonPropertyName("oldValue")]
        public object OldValue
        {
            get
            {
                InitializeProperty("oldValue", _oldValue);
                return _oldValue;
            }
            set
            {
                _oldValue = value;
            }
        }
        
        // Property Definition
        private object _newValue;
        /// <summary>
        /// The new value of the item, if there is a new value.
        /// </summary>
        [JsonPropertyName("newValue")]
        public object NewValue
        {
            get
            {
                InitializeProperty("newValue", _newValue);
                return _newValue;
            }
            set
            {
                _newValue = value;
            }
        }
    }
}

