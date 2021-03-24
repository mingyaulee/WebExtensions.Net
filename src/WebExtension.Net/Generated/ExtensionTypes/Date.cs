// This file is auto generated at 2021-03-24T04:51:22

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
    public class Date
    {
        private readonly string valuestring;
        /// <summary>Creates a new instance of Date.</summary>
        public Date(string valuestring)
        {
            this.valuestring = valuestring;
        }
        
        private readonly int valueint;
        /// <summary>Creates a new instance of Date.</summary>
        public Date(int valueint)
        {
            this.valueint = valueint;
        }
        
        private readonly object valueobject;
        /// <summary>Creates a new instance of Date.</summary>
        public Date(object valueobject)
        {
            this.valueobject = valueobject;
        }
        
    }
}

