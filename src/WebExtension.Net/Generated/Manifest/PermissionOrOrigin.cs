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
    public class PermissionOrOrigin
    {
        private readonly object currentValue = null;
    
        private readonly Permission valuePermission;
        /// <summary>Creates a new instance of PermissionOrOrigin.</summary>
        public PermissionOrOrigin(Permission valuePermission)
        {
            this.valuePermission = valuePermission;
            currentValue = valuePermission;
        }
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator Permission(PermissionOrOrigin value) => value.valuePermission;
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator PermissionOrOrigin(Permission value) => new(value);
        
        private readonly MatchPattern valueMatchPattern;
        /// <summary>Creates a new instance of PermissionOrOrigin.</summary>
        public PermissionOrOrigin(MatchPattern valueMatchPattern)
        {
            this.valueMatchPattern = valueMatchPattern;
            currentValue = valueMatchPattern;
        }
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator MatchPattern(PermissionOrOrigin value) => value.valueMatchPattern;
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator PermissionOrOrigin(MatchPattern value) => new(value);
        
    
        /// <inheritdoc />
        public override string ToString()
        {
            return currentValue?.ToString();
        }
    }
}

