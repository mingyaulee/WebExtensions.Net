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
    public class IconPath
    {
        private readonly object currentValue = null;
    
        /// <summary>Creates a new instance of IconPath.</summary>
        public IconPath(object valueobject)
        {
            currentValue = valueobject;
        }
        
        private readonly ExtensionFileUrl valueExtensionFileUrl;
        /// <summary>Creates a new instance of IconPath.</summary>
        public IconPath(ExtensionFileUrl valueExtensionFileUrl)
        {
            this.valueExtensionFileUrl = valueExtensionFileUrl;
            currentValue = valueExtensionFileUrl;
        }
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator ExtensionFileUrl(IconPath value) => value.valueExtensionFileUrl;
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator IconPath(ExtensionFileUrl value) => new(value);
        
    
        /// <inheritdoc />
        public override string ToString()
        {
            return currentValue?.ToString();
        }
    }
}

