using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Manifest
{
    // MultiType Definition
    /// <summary>
    /// Represents a native manifest file
    /// </summary>
    public class NativeManifest
    {
        private readonly object currentValue = null;
    
        /// <summary>Creates a new instance of NativeManifest.</summary>
        public NativeManifest(object valueobject)
        {
            currentValue = valueobject;
        }
        
    
        /// <inheritdoc />
        public override string ToString()
        {
            return currentValue?.ToString();
        }
    }
}

