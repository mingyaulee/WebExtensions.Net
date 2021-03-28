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
    public class ThemeColor
    {
        private readonly object currentValue = null;
    
        private readonly string valuestring;
        /// <summary>Creates a new instance of ThemeColor.</summary>
        public ThemeColor(string valuestring)
        {
            this.valuestring = valuestring;
            currentValue = valuestring;
        }
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator string(ThemeColor value) => value.valuestring;
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator ThemeColor(string value) => new(value);
        
        /// <summary>Creates a new instance of ThemeColor.</summary>
        public ThemeColor(IEnumerable<int> valueIEnumerableint)
        {
            currentValue = valueIEnumerableint;
        }
        
        /// <summary>Creates a new instance of ThemeColor.</summary>
        public ThemeColor(IEnumerable<double> valueIEnumerabledouble)
        {
            currentValue = valueIEnumerabledouble;
        }
        
    
        /// <inheritdoc />
        public override string ToString()
        {
            return currentValue?.ToString();
        }
    }
}

