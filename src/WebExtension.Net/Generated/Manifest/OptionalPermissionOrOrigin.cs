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
    public class OptionalPermissionOrOrigin
    {
        private readonly object currentValue = null;
    
        private readonly OptionalPermission valueOptionalPermission;
        /// <summary>Creates a new instance of OptionalPermissionOrOrigin.</summary>
        public OptionalPermissionOrOrigin(OptionalPermission valueOptionalPermission)
        {
            this.valueOptionalPermission = valueOptionalPermission;
            currentValue = valueOptionalPermission;
        }
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator OptionalPermission(OptionalPermissionOrOrigin value) => value.valueOptionalPermission;
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator OptionalPermissionOrOrigin(OptionalPermission value) => new(value);
        
        private readonly MatchPattern valueMatchPattern;
        /// <summary>Creates a new instance of OptionalPermissionOrOrigin.</summary>
        public OptionalPermissionOrOrigin(MatchPattern valueMatchPattern)
        {
            this.valueMatchPattern = valueMatchPattern;
            currentValue = valueMatchPattern;
        }
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator MatchPattern(OptionalPermissionOrOrigin value) => value.valueMatchPattern;
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator OptionalPermissionOrOrigin(MatchPattern value) => new(value);
        
    
        /// <inheritdoc />
        public override string ToString()
        {
            return currentValue?.ToString();
        }
    }
}

