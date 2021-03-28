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
    public class IconImageData
    {
        private readonly object currentValue = null;
    
        /// <summary>Creates a new instance of IconImageData.</summary>
        public IconImageData(object valueobject)
        {
            currentValue = valueobject;
        }
        
        /// <summary>Creates a new instance of IconImageData.</summary>
        public IconImageData(ImageData valueImageData)
        {
            currentValue = valueImageData;
        }
        
    
        /// <inheritdoc />
        public override string ToString()
        {
            return currentValue?.ToString();
        }
    }
}

