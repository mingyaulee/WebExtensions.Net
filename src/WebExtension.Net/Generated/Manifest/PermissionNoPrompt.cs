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
    public class PermissionNoPrompt
    {
        private readonly object currentValue = null;
    
        private readonly OptionalPermission valueOptionalPermission;
        /// <summary>Creates a new instance of PermissionNoPrompt.</summary>
        public PermissionNoPrompt(OptionalPermission valueOptionalPermission)
        {
            this.valueOptionalPermission = valueOptionalPermission;
            currentValue = valueOptionalPermission;
        }
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator OptionalPermission(PermissionNoPrompt value) => value.valueOptionalPermission;
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator PermissionNoPrompt(OptionalPermission value) => new(value);
        
        private readonly string valuestring;
        /// <summary>Creates a new instance of PermissionNoPrompt.</summary>
        public PermissionNoPrompt(string valuestring)
        {
            this.valuestring = valuestring;
            currentValue = valuestring;
        }
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator string(PermissionNoPrompt value) => value.valuestring;
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator PermissionNoPrompt(string value) => new(value);
        
    
        /// <inheritdoc />
        public override string ToString()
        {
            return currentValue?.ToString();
        }
    }
}

