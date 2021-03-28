using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Manifest
{
    // MultiType Definition
    /// <summary>
    /// Same as MatchPattern above, but excludes all_urls
    /// </summary>
    public class MatchPatternRestricted
    {
        private readonly object currentValue = null;
    
        private readonly string valuestring;
        /// <summary>Creates a new instance of MatchPatternRestricted.</summary>
        public MatchPatternRestricted(string valuestring)
        {
            this.valuestring = valuestring;
            currentValue = valuestring;
        }
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator string(MatchPatternRestricted value) => value.valuestring;
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator MatchPatternRestricted(string value) => new(value);
        
    
        /// <inheritdoc />
        public override string ToString()
        {
            return currentValue?.ToString();
        }
    }
}

