/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Manifest
{
    /// MultiType Definition
    /// <summary></summary>
    public class MatchPattern
    {
        private readonly string valuestring;
        public MatchPattern(string valuestring)
        {
            this.valuestring = valuestring;
        }
        
        private readonly MatchPatternRestricted valueMatchPatternRestricted;
        public MatchPattern(MatchPatternRestricted valueMatchPatternRestricted)
        {
            this.valueMatchPatternRestricted = valueMatchPatternRestricted;
        }
        
        private readonly MatchPatternUnestricted valueMatchPatternUnestricted;
        public MatchPattern(MatchPatternUnestricted valueMatchPatternUnestricted)
        {
            this.valueMatchPatternUnestricted = valueMatchPatternUnestricted;
        }
        
    }
}

