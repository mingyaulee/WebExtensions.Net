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
    public class HttpURL : BaseStringFormat
    {
        private const string pattern = "url";
        /// <summary>Creates a new instance of HttpURL.</summary>
        public HttpURL(string value) : base(value, pattern)
        {
        }
    }
}

