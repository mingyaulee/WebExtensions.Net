/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Manifest
{
    /// MultiType Definition
    /// <summary>Mostly unrestricted match patterns for privileged add-ons. This should technically be rejected for unprivileged add-ons, but, reasons. The MatchPattern class will still refuse privileged schemes for those extensions.</summary>
    public class MatchPatternUnestricted
    {
        private readonly string valuestring;
        public MatchPatternUnestricted(string valuestring)
        {
            this.valuestring = valuestring;
        }
        
    }
}

