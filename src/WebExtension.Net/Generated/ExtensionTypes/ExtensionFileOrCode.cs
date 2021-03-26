using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.ExtensionTypes
{
    // MultiType Definition
    /// <summary>
    /// 
    /// </summary>
    public class ExtensionFileOrCode
    {
        private readonly object valueobject;
        /// <summary>Creates a new instance of ExtensionFileOrCode.</summary>
        public ExtensionFileOrCode(object valueobject)
        {
            this.valueobject = valueobject;
        }
        
    }
}

