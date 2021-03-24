// This file is auto generated at 2021-03-24T04:51:22

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
        private readonly Permission valuePermission;
        /// <summary>Creates a new instance of PermissionOrOrigin.</summary>
        public PermissionOrOrigin(Permission valuePermission)
        {
            this.valuePermission = valuePermission;
        }
        
        private readonly MatchPattern valueMatchPattern;
        /// <summary>Creates a new instance of PermissionOrOrigin.</summary>
        public PermissionOrOrigin(MatchPattern valueMatchPattern)
        {
            this.valueMatchPattern = valueMatchPattern;
        }
        
    }
}

