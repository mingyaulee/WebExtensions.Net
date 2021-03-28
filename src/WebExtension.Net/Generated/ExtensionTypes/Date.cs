using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.ExtensionTypes
{
    // MultiType Definition
    /// <summary>
    /// 
    /// </summary>
    public class Date
    {
        private readonly object currentValue = null;
    
        private readonly string valuestring;
        /// <summary>Creates a new instance of Date.</summary>
        public Date(string valuestring)
        {
            this.valuestring = valuestring;
            currentValue = valuestring;
        }
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator string(Date value) => value.valuestring;
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator Date(string value) => new(value);
        
        private readonly int valueint;
        /// <summary>Creates a new instance of Date.</summary>
        public Date(int valueint)
        {
            this.valueint = valueint;
            currentValue = valueint;
        }
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator int(Date value) => value.valueint;
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator Date(int value) => new(value);
        
        /// <summary>Creates a new instance of Date.</summary>
        public Date(object valueobject)
        {
            currentValue = valueobject;
        }
        
    
        /// <inheritdoc />
        public override string ToString()
        {
            return currentValue?.ToString();
        }
    }
}

