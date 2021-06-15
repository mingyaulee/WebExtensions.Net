using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Devtools.InspectedWindow
{
    // Type Class
    /// <summary>An object providing details if an exception occurred while evaluating the expression.</summary>
    public partial class ExceptionInfo : BaseObject
    {
        private string _code;
        private string _description;
        private IEnumerable<object> _details;
        private bool _isError;
        private bool _isException;
        private string _value;

        /// <summary>Set if the error occurred on the DevTools side before the expression is evaluated.</summary>
        [JsonPropertyName("code")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Code
        {
            get
            {
                InitializeProperty("code", _code);
                return _code;
            }
            set
            {
                _code = value;
            }
        }

        /// <summary>Set if the error occurred on the DevTools side before the expression is evaluated.</summary>
        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Description
        {
            get
            {
                InitializeProperty("description", _description);
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        /// <summary>Set if the error occurred on the DevTools side before the expression is evaluated, contains the array of the values that may be substituted into the description string to provide more information about the cause of the error.</summary>
        [JsonPropertyName("details")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<object> Details
        {
            get
            {
                InitializeProperty("details", _details);
                return _details;
            }
            set
            {
                _details = value;
            }
        }

        /// <summary>Set if the error occurred on the DevTools side before the expression is evaluated.</summary>
        [JsonPropertyName("isError")]
        public bool IsError
        {
            get
            {
                InitializeProperty("isError", _isError);
                return _isError;
            }
            set
            {
                _isError = value;
            }
        }

        /// <summary>Set if the evaluated code produces an unhandled exception.</summary>
        [JsonPropertyName("isException")]
        public bool IsException
        {
            get
            {
                InitializeProperty("isException", _isException);
                return _isException;
            }
            set
            {
                _isException = value;
            }
        }

        /// <summary>Set if the evaluated code produces an unhandled exception.</summary>
        [JsonPropertyName("value")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Value
        {
            get
            {
                InitializeProperty("value", _value);
                return _value;
            }
            set
            {
                _value = value;
            }
        }
    }
}
