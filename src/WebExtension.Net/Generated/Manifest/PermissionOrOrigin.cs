/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Manifest
{
    /// MultiType Definition
    /// <summary></summary>
    public class PermissionOrOrigin
    {
        private readonly Permission valuePermission;
        public PermissionOrOrigin(Permission valuePermission)
        {
            this.valuePermission = valuePermission;
        }
        
        private readonly MatchPattern valueMatchPattern;
        public PermissionOrOrigin(MatchPattern valueMatchPattern)
        {
            this.valueMatchPattern = valueMatchPattern;
        }
        
    }
}

