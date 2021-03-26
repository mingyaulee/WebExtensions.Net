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
    public class OptionalPermissionNoPrompt
    {
        private readonly string valuestring;
        /// <summary>Creates a new instance of OptionalPermissionNoPrompt.</summary>
        public OptionalPermissionNoPrompt(string valuestring)
        {
            this.valuestring = valuestring;
        }
        
    }
}

