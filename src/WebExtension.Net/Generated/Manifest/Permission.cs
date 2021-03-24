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
    public class Permission
    {
        private readonly PermissionNoPrompt valuePermissionNoPrompt;
        /// <summary>Creates a new instance of Permission.</summary>
        public Permission(PermissionNoPrompt valuePermissionNoPrompt)
        {
            this.valuePermissionNoPrompt = valuePermissionNoPrompt;
        }
        
        private readonly OptionalPermission valueOptionalPermission;
        /// <summary>Creates a new instance of Permission.</summary>
        public Permission(OptionalPermission valueOptionalPermission)
        {
            this.valueOptionalPermission = valueOptionalPermission;
        }
        
    }
}

