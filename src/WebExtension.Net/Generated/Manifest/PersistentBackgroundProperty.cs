using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Manifest
{
    // MultiType Definition
    /// <summary>
    /// 
    /// </summary>
    public class PersistentBackgroundProperty
    {
        private readonly object currentValue = null;
    
        private readonly bool valuebool;
        /// <summary>Creates a new instance of PersistentBackgroundProperty.</summary>
        public PersistentBackgroundProperty(bool valuebool)
        {
            this.valuebool = valuebool;
            currentValue = valuebool;
        }
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator bool(PersistentBackgroundProperty value) => value.valuebool;
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator PersistentBackgroundProperty(bool value) => new(value);
        
    
        /// <inheritdoc />
        public override string ToString()
        {
            return currentValue?.ToString();
        }
    }
}

