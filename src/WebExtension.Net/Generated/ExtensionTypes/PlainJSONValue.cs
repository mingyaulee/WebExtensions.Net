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
        private readonly object currentValue = null;
    
        /// <summary>Creates a new instance of PlainJSONValue.</summary>
        public PlainJSONValue() { }
        
        private readonly double valuedouble;
        /// <summary>Creates a new instance of PlainJSONValue.</summary>
        public PlainJSONValue(double valuedouble)
        {
            this.valuedouble = valuedouble;
            currentValue = valuedouble;
        }
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator double(PlainJSONValue value) => value.valuedouble;
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator PlainJSONValue(double value) => new(value);
        
        private readonly string valuestring;
        /// <summary>Creates a new instance of PlainJSONValue.</summary>
        public PlainJSONValue(string valuestring)
        {
            this.valuestring = valuestring;
            currentValue = valuestring;
        }
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator string(PlainJSONValue value) => value.valuestring;
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator PlainJSONValue(string value) => new(value);
        
        private readonly bool valuebool;
        /// <summary>Creates a new instance of PlainJSONValue.</summary>
        public PlainJSONValue(bool valuebool)
        {
            this.valuebool = valuebool;
            currentValue = valuebool;
        }
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator bool(PlainJSONValue value) => value.valuebool;
        
        /// <summary></summary>
        /// <param name="value"></param>
        public static implicit operator PlainJSONValue(bool value) => new(value);
        
        /// <summary>Creates a new instance of PlainJSONValue.</summary>
        public PlainJSONValue(IEnumerable<PlainJSONValue> valueIEnumerablePlainJSONValue)
        {
            currentValue = valueIEnumerablePlainJSONValue;
        }
        
        /// <summary>Creates a new instance of PlainJSONValue.</summary>
        public PlainJSONValue(object valueobject)
        {
            currentValue = valueobject;
        }
        
    
        /// <inheritdoc />
        public override string ToString()
        {
            return currentValue?.ToString();
        }
    }
}

