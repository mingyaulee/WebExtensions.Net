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
    public class OptionalPermission
    {
        private readonly OptionalPermissionNoPrompt valueOptionalPermissionNoPrompt;
        public OptionalPermission(OptionalPermissionNoPrompt valueOptionalPermissionNoPrompt)
        {
            this.valueOptionalPermissionNoPrompt = valueOptionalPermissionNoPrompt;
        }
        
        private readonly string valuestring;
        public OptionalPermission(string valuestring)
        {
            this.valuestring = valuestring;
        }
        
    }
}

