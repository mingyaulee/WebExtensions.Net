using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Manifest
{
    // MultiType Definition
    /// <summary>
    /// Mostly unrestricted match patterns for privileged add-ons. This should technically be rejected for unprivileged add-ons, but, reasons. The MatchPattern class will still refuse privileged schemes for those extensions.
    /// </summary>
    public class MatchPatternUnestricted
    {
        private readonly object currentValue = null;
    
        private readonly string valuestring;
        /// <summary>Creates a new instance of MatchPatternUnestricted.</summary>
        public MatchPatternUnestricted(string valuestring)
        {
            this.valuestring = valuestring;
            currentValue = valuestring;
        }
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator string(MatchPatternUnestricted value) => value.valuestring;
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator MatchPatternUnestricted(string value) => new(value);
        
    
        /// <inheritdoc />
        public override string ToString()
        {
            return currentValue?.ToString();
        }
    }
}

