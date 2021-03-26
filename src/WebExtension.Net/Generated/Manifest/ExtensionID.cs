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
    public class ExtensionID
    {
        private readonly string valuestring;
        /// <summary>Creates a new instance of ExtensionID.</summary>
        public ExtensionID(string valuestring)
        {
            this.valuestring = valuestring;
        }
        
    }
}

