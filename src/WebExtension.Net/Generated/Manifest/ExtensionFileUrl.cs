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
    public class ExtensionFileUrl : BaseStringFormat
    {
        private const string pattern = "strictRelativeUrl";
        /// <summary>Creates a new instance of ExtensionFileUrl.</summary>
        public ExtensionFileUrl(string value) : base(value, pattern)
        {
        }
    }
}

