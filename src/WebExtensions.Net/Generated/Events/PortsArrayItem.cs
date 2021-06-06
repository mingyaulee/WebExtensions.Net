using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Events
{
    // Multitype Class
    /// <summary></summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<PortsArrayItem>))]
    public class PortsArrayItem : BaseMultiTypeObject
    {
        private readonly int valueInt;

        /// <summary>Creates a new instance of <see cref="PortsArrayItem" />.</summary>
        /// <param name="value">The value.</param>
        public PortsArrayItem(int value) : base(value, typeof(int))
        {
            valueInt = value;
        }

        /// <summary>Creates a new instance of <see cref="PortsArrayItem" />.</summary>
        /// <param name="value">The value.</param>
        public PortsArrayItem(IEnumerable<int> value) : base(value, typeof(IEnumerable<int>))
        {
        }

        /// <summary>Converts from <see cref="PortsArrayItem" /> to <see cref="int" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator int(PortsArrayItem value) => value.valueInt;

        /// <summary>Converts from <see cref="int" /> to <see cref="PortsArrayItem" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator PortsArrayItem(int value) => new(value);
    }
}
