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
    public class OptionalPermission
    {
        private readonly OptionalPermissionNoPrompt valueOptionalPermissionNoPrompt;
        /// <summary>Creates a new instance of OptionalPermission.</summary>
        public OptionalPermission(OptionalPermissionNoPrompt valueOptionalPermissionNoPrompt)
        {
            this.valueOptionalPermissionNoPrompt = valueOptionalPermissionNoPrompt;
        }
        
        private readonly string valuestring;
        /// <summary>Creates a new instance of OptionalPermission.</summary>
        public OptionalPermission(string valuestring)
        {
            this.valuestring = valuestring;
        }
        
    }
}

