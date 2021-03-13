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
    public class Permission
    {
        private readonly PermissionNoPrompt valuePermissionNoPrompt;
        public Permission(PermissionNoPrompt valuePermissionNoPrompt)
        {
            this.valuePermissionNoPrompt = valuePermissionNoPrompt;
        }
        
        private readonly OptionalPermission valueOptionalPermission;
        public Permission(OptionalPermission valueOptionalPermission)
        {
            this.valueOptionalPermission = valueOptionalPermission;
        }
        
    }
}

