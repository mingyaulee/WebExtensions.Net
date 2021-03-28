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
    public class OptionalPermissionNoPrompt
    {
        private readonly object currentValue = null;
    
        private readonly string valuestring;
        /// <summary>Creates a new instance of OptionalPermissionNoPrompt.</summary>
        public OptionalPermissionNoPrompt(string valuestring)
        {
            this.valuestring = valuestring;
            currentValue = valuestring;
        }
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator string(OptionalPermissionNoPrompt value) => value.valuestring;
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator OptionalPermissionNoPrompt(string value) => new(value);
        
    
        /// <inheritdoc />
        public override string ToString()
        {
            return currentValue?.ToString();
        }
    }
}

