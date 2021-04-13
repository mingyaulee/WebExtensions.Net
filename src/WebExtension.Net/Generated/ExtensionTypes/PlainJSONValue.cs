using System.Collections.Generic;

namespace WebExtension.Net.ExtensionTypes
{
    // Multitype Class
    /// <summary>A plain JSON value</summary>
    public class PlainJSONValue
    {
        private readonly double valueDouble;
        private readonly string valueString;
        private readonly bool valueBool;
        private readonly object currentValue = null;

        /// <summary>Creates a new instance of <see cref="PlainJSONValue" />.</summary>
        public PlainJSONValue()
        {
        }

        /// <summary>Creates a new instance of <see cref="PlainJSONValue" />.</summary>
        /// <param name="value">The value.</param>
        public PlainJSONValue(double value)
        {
            valueDouble = value;
            currentValue = value;
        }

        /// <summary>Creates a new instance of <see cref="PlainJSONValue" />.</summary>
        /// <param name="value">The value.</param>
        public PlainJSONValue(string value)
        {
            valueString = value;
            currentValue = value;
        }

        /// <summary>Creates a new instance of <see cref="PlainJSONValue" />.</summary>
        /// <param name="value">The value.</param>
        public PlainJSONValue(bool value)
        {
            valueBool = value;
            currentValue = value;
        }

        /// <summary>Creates a new instance of <see cref="PlainJSONValue" />.</summary>
        /// <param name="value">The value.</param>
        public PlainJSONValue(IEnumerable<PlainJSONValue> value)
        {
            currentValue = value;
        }

        /// <summary>Creates a new instance of <see cref="PlainJSONValue" />.</summary>
        /// <param name="value">The value.</param>
        public PlainJSONValue(object value)
        {
            currentValue = value;
        }

        /// <summary>Converts from <see cref="PlainJSONValue" /> to <see cref="double" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator double(PlainJSONValue value) => value.valueDouble;

        /// <summary>Converts from <see cref="double" /> to <see cref="PlainJSONValue" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator PlainJSONValue(double value) => new(value);

        /// <summary>Converts from <see cref="PlainJSONValue" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(PlainJSONValue value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="PlainJSONValue" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator PlainJSONValue(string value) => new(value);

        /// <summary>Converts from <see cref="PlainJSONValue" /> to <see cref="bool" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator bool(PlainJSONValue value) => value.valueBool;

        /// <summary>Converts from <see cref="bool" /> to <see cref="PlainJSONValue" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator PlainJSONValue(bool value) => new(value);

        /// <inheritdoc />
        public override string ToString()
        {
            return currentValue?.ToString();
        }
    }
}
