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
    public class ExtensionURL : BaseStringFormat
    {
        private const string pattern = "strictRelativeUrl";
        /// <summary>Creates a new instance of ExtensionURL.</summary>
        public ExtensionURL(string value) : base(value, pattern)
        {
        }
    }
}

