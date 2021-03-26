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
        private readonly object valueobject;
        /// <summary>Creates a new instance of IconPath.</summary>
        public IconPath(object valueobject)
        {
            this.valueobject = valueobject;
        }
        
        private readonly ExtensionFileUrl valueExtensionFileUrl;
        /// <summary>Creates a new instance of IconPath.</summary>
        public IconPath(ExtensionFileUrl valueExtensionFileUrl)
        {
            this.valueExtensionFileUrl = valueExtensionFileUrl;
        }
        
    }
}

