// This file is auto generated at 2021-03-24T04:51:22

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.ExtensionTypes
{
    // MultiType Definition
    /// <summary>
    /// A plain JSON value
    /// </summary>
    public class PlainJSONValue
    {
        /// <summary>Creates a new instance of PlainJSONValue.</summary>
        public PlainJSONValue() { }
        
        private readonly double valuedouble;
        /// <summary>Creates a new instance of PlainJSONValue.</summary>
        public PlainJSONValue(double valuedouble)
        {
            this.valuedouble = valuedouble;
        }
        
        private readonly string valuestring;
        /// <summary>Creates a new instance of PlainJSONValue.</summary>
        public PlainJSONValue(string valuestring)
        {
            this.valuestring = valuestring;
        }
        
        private readonly bool valuebool;
        /// <summary>Creates a new instance of PlainJSONValue.</summary>
        public PlainJSONValue(bool valuebool)
        {
            this.valuebool = valuebool;
        }
        
        private readonly IEnumerable<PlainJSONValue> valueIEnumerablePlainJSONValue;
        /// <summary>Creates a new instance of PlainJSONValue.</summary>
        public PlainJSONValue(IEnumerable<PlainJSONValue> valueIEnumerablePlainJSONValue)
        {
            this.valueIEnumerablePlainJSONValue = valueIEnumerablePlainJSONValue;
        }
        
        private readonly object valueobject;
        /// <summary>Creates a new instance of PlainJSONValue.</summary>
        public PlainJSONValue(object valueobject)
        {
            this.valueobject = valueobject;
        }
        
    }
}

