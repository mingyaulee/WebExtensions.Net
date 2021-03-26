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
        private readonly OptionalPermission valueOptionalPermission;
        /// <summary>Creates a new instance of OptionalPermissionOrOrigin.</summary>
        public OptionalPermissionOrOrigin(OptionalPermission valueOptionalPermission)
        {
            this.valueOptionalPermission = valueOptionalPermission;
        }
        
        private readonly MatchPattern valueMatchPattern;
        /// <summary>Creates a new instance of OptionalPermissionOrOrigin.</summary>
        public OptionalPermissionOrOrigin(MatchPattern valueMatchPattern)
        {
            this.valueMatchPattern = valueMatchPattern;
        }
        
    }
}

