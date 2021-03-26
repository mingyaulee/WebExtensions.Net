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
    public class PersistentBackgroundProperty
    {
        private readonly bool valuebool;
        /// <summary>Creates a new instance of PersistentBackgroundProperty.</summary>
        public PersistentBackgroundProperty(bool valuebool)
        {
            this.valuebool = valuebool;
        }
        
    }
}

