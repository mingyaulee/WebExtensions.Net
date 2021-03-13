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
    public class ThemeColor
    {
        private readonly string valuestring;
        public ThemeColor(string valuestring)
        {
            this.valuestring = valuestring;
        }
        
        private readonly IEnumerable<int> valueIEnumerableint;
        public ThemeColor(IEnumerable<int> valueIEnumerableint)
        {
            this.valueIEnumerableint = valueIEnumerableint;
        }
        
        private readonly IEnumerable<double> valueIEnumerabledouble;
        public ThemeColor(IEnumerable<double> valueIEnumerabledouble)
        {
            this.valueIEnumerabledouble = valueIEnumerabledouble;
        }
        
    }
}

