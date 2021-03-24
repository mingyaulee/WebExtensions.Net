// This file is auto generated at 2021-03-24T04:51:22

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
        private readonly string valuestring;
        /// <summary>Creates a new instance of ThemeColor.</summary>
        public ThemeColor(string valuestring)
        {
            this.valuestring = valuestring;
        }
        
        private readonly IEnumerable<int> valueIEnumerableint;
        /// <summary>Creates a new instance of ThemeColor.</summary>
        public ThemeColor(IEnumerable<int> valueIEnumerableint)
        {
            this.valueIEnumerableint = valueIEnumerableint;
        }
        
        private readonly IEnumerable<double> valueIEnumerabledouble;
        /// <summary>Creates a new instance of ThemeColor.</summary>
        public ThemeColor(IEnumerable<double> valueIEnumerabledouble)
        {
            this.valueIEnumerabledouble = valueIEnumerabledouble;
        }
        
    }
}

