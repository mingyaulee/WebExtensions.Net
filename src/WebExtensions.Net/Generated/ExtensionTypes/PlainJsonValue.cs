using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.ExtensionTypes
{
    // Multitype Class
    /// <summary>A plain JSON value</summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<PlainJsonValue>))]
    public partial class PlainJsonValue : BaseMultiTypeObject
    {
        private readonly double valueDouble;
        private readonly string valueString;
        private readonly bool valueBool;

        /// <summary>Creates a new instance of <see cref="PlainJsonValue" />.</summary>
        public PlainJsonValue() : base(null, null)
        {
        }

        /// <summary>Creates a new instance of <see cref="PlainJsonValue" />.</summary>
        /// <param name="value">The value.</param>
        public PlainJsonValue(double value) : base(value, typeof(double))
        {
            valueDouble = value;
        }

        /// <summary>Creates a new instance of <see cref="PlainJsonValue" />.</summary>
        /// <param name="value">The value.</param>
        public PlainJsonValue(string value) : base(value, typeof(string))
        {
            valueString = value;
        }

        /// <summary>Creates a new instance of <see cref="PlainJsonValue" />.</summary>
        /// <param name="value">The value.</param>
        public PlainJsonValue(bool value) : base(value, typeof(bool))
        {
            valueBool = value;
        }

        /// <summary>Creates a new instance of <see cref="PlainJsonValue" />.</summary>
        /// <param name="value">The value.</param>
        public PlainJsonValue(IEnumerable<PlainJsonValue> value) : base(value, typeof(IEnumerable<PlainJsonValue>))
        {
        }

        /// <summary>Creates a new instance of <see cref="PlainJsonValue" />.</summary>
        /// <param name="value">The value.</param>
        public PlainJsonValue(object value) : base(value, typeof(object))
        {
        }

        /// <summary>Converts from <see cref="PlainJsonValue" /> to <see cref="double" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator double(PlainJsonValue value) => value.valueDouble;

        /// <summary>Converts from <see cref="double" /> to <see cref="PlainJsonValue" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator PlainJsonValue(double value) => new(value);

        /// <summary>Converts from <see cref="PlainJsonValue" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(PlainJsonValue value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="PlainJsonValue" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator PlainJsonValue(string value) => new(value);

        /// <summary>Converts from <see cref="PlainJsonValue" /> to <see cref="bool" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator bool(PlainJsonValue value) => value.valueBool;

        /// <summary>Converts from <see cref="bool" /> to <see cref="PlainJsonValue" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator PlainJsonValue(bool value) => new(value);
    }
}
