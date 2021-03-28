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
    public class Permission
    {
        private readonly object currentValue = null;
    
        private readonly PermissionNoPrompt valuePermissionNoPrompt;
        /// <summary>Creates a new instance of Permission.</summary>
        public Permission(PermissionNoPrompt valuePermissionNoPrompt)
        {
            this.valuePermissionNoPrompt = valuePermissionNoPrompt;
            currentValue = valuePermissionNoPrompt;
        }
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator PermissionNoPrompt(Permission value) => value.valuePermissionNoPrompt;
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator Permission(PermissionNoPrompt value) => new(value);
        
        private readonly OptionalPermission valueOptionalPermission;
        /// <summary>Creates a new instance of Permission.</summary>
        public Permission(OptionalPermission valueOptionalPermission)
        {
            this.valueOptionalPermission = valueOptionalPermission;
            currentValue = valueOptionalPermission;
        }
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator OptionalPermission(Permission value) => value.valueOptionalPermission;
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator Permission(OptionalPermission value) => new(value);
        
    
        /// <inheritdoc />
        public override string ToString()
        {
            return currentValue?.ToString();
        }
    }
}

