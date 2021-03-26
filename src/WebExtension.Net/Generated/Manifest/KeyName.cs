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
    public class KeyName : BaseStringFormat
    {
        private const string pattern = "manifestShortcutKey";
        /// <summary>Creates a new instance of KeyName.</summary>
        public KeyName(string value) : base(value, pattern)
        {
        }
    }
}

