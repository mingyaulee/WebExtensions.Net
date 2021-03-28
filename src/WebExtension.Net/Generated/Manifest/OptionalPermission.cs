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
    public class OptionalPermission
    {
        private readonly object currentValue = null;
    
        private readonly OptionalPermissionNoPrompt valueOptionalPermissionNoPrompt;
        /// <summary>Creates a new instance of OptionalPermission.</summary>
        public OptionalPermission(OptionalPermissionNoPrompt valueOptionalPermissionNoPrompt)
        {
            this.valueOptionalPermissionNoPrompt = valueOptionalPermissionNoPrompt;
            currentValue = valueOptionalPermissionNoPrompt;
        }
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator OptionalPermissionNoPrompt(OptionalPermission value) => value.valueOptionalPermissionNoPrompt;
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator OptionalPermission(OptionalPermissionNoPrompt value) => new(value);
        
        private readonly string valuestring;
        /// <summary>Creates a new instance of OptionalPermission.</summary>
        public OptionalPermission(string valuestring)
        {
            this.valuestring = valuestring;
            currentValue = valuestring;
        }
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator string(OptionalPermission value) => value.valuestring;
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator OptionalPermission(string value) => new(value);
        
    
        /// <inheritdoc />
        public override string ToString()
        {
            return currentValue?.ToString();
        }
    }
}

