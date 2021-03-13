/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Manifest
{
    /// MultiType Definition
    /// <summary>Same as MatchPattern above, but excludes <all_urls></summary>
    public class MatchPatternRestricted
    {
        private readonly string valuestring;
        public MatchPatternRestricted(string valuestring)
        {
            this.valuestring = valuestring;
        }
        
    }
}

