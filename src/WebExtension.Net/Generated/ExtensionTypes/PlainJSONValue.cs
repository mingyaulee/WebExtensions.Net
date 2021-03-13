/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.ExtensionTypes
{
    /// MultiType Definition
    /// <summary>A plain JSON value</summary>
    public class PlainJSONValue
    {
        public PlainJSONValue() { }
        
        private readonly double valuedouble;
        public PlainJSONValue(double valuedouble)
        {
            this.valuedouble = valuedouble;
        }
        
        private readonly string valuestring;
        public PlainJSONValue(string valuestring)
        {
            this.valuestring = valuestring;
        }
        
        private readonly bool valuebool;
        public PlainJSONValue(bool valuebool)
        {
            this.valuebool = valuebool;
        }
        
        private readonly IEnumerable<PlainJSONValue> valueIEnumerablePlainJSONValue;
        public PlainJSONValue(IEnumerable<PlainJSONValue> valueIEnumerablePlainJSONValue)
        {
            this.valueIEnumerablePlainJSONValue = valueIEnumerablePlainJSONValue;
        }
        
        private readonly object valueobject;
        public PlainJSONValue(object valueobject)
        {
            this.valueobject = valueobject;
        }
        
    }
}

