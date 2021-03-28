using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Manifest
{
    // MultiType Definition
    /// <summary>
    /// 
    /// </summary>
    public class MatchPattern
    {
        private readonly object currentValue = null;
    
        private readonly string valuestring;
        /// <summary>Creates a new instance of MatchPattern.</summary>
        public MatchPattern(string valuestring)
        {
            this.valuestring = valuestring;
            currentValue = valuestring;
        }
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator string(MatchPattern value) => value.valuestring;
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator MatchPattern(string value) => new(value);
        
        private readonly MatchPatternRestricted valueMatchPatternRestricted;
        /// <summary>Creates a new instance of MatchPattern.</summary>
        public MatchPattern(MatchPatternRestricted valueMatchPatternRestricted)
        {
            this.valueMatchPatternRestricted = valueMatchPatternRestricted;
            currentValue = valueMatchPatternRestricted;
        }
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator MatchPatternRestricted(MatchPattern value) => value.valueMatchPatternRestricted;
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator MatchPattern(MatchPatternRestricted value) => new(value);
        
        private readonly MatchPatternUnestricted valueMatchPatternUnestricted;
        /// <summary>Creates a new instance of MatchPattern.</summary>
        public MatchPattern(MatchPatternUnestricted valueMatchPatternUnestricted)
        {
            this.valueMatchPatternUnestricted = valueMatchPatternUnestricted;
            currentValue = valueMatchPatternUnestricted;
        }
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator MatchPatternUnestricted(MatchPattern value) => value.valueMatchPatternUnestricted;
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator MatchPattern(MatchPatternUnestricted value) => new(value);
        
    
        /// <inheritdoc />
        public override string ToString()
        {
            return currentValue?.ToString();
        }
    }
}

