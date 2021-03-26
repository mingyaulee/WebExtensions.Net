using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Manifest
{
    // String Format Definition
    /// <summary>
    /// 
    /// </summary>
    public class ImageDataOrExtensionURL : BaseStringFormat
    {
        private const string pattern = "imageDataOrStrictRelativeUrl";
        /// <summary>Creates a new instance of ImageDataOrExtensionURL.</summary>
        public ImageDataOrExtensionURL(string value) : base(value, pattern)
        {
        }
    }
}

