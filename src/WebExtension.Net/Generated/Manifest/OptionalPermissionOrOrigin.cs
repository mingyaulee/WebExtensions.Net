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
    public class OptionalPermissionOrOrigin
    {
        private readonly OptionalPermission valueOptionalPermission;
        public OptionalPermissionOrOrigin(OptionalPermission valueOptionalPermission)
        {
            this.valueOptionalPermission = valueOptionalPermission;
        }
        
        private readonly MatchPattern valueMatchPattern;
        public OptionalPermissionOrOrigin(MatchPattern valueMatchPattern)
        {
            this.valueMatchPattern = valueMatchPattern;
        }
        
    }
}

