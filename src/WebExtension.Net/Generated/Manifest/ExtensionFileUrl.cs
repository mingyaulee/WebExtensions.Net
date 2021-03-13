/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Manifest
{
    /// String Format Definition
    /// <summary></summary>
    public class ExtensionFileUrl : BaseStringFormat
    {
        private const string pattern = "strictRelativeUrl";
        public ExtensionFileUrl(string value) : base(value, pattern)
        {
        }
    }
}

