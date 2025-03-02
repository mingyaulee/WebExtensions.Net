using System.Text.Json.Serialization;

namespace WebExtensions.Net.Test
{
    // Multitype Class
    /// <summary></summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<Promise>))]
    public partial class Promise : BaseMultiTypeObject
    {
        private readonly PromiseType1 valuePromiseType1;

        /// <summary>Creates a new instance of <see cref="Promise" />.</summary>
        /// <param name="value">The value.</param>
        public Promise(PromiseType1 value) : base(value, typeof(PromiseType1))
        {
            valuePromiseType1 = value;
        }

        /// <summary>Creates a new instance of <see cref="Promise" />.</summary>
        /// <param name="value">The value.</param>
        public Promise(object value) : base(value, typeof(object))
        {
        }

        /// <summary>Converts from <see cref="Promise" /> to <see cref="PromiseType1" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator PromiseType1(Promise value) => value.valuePromiseType1;

        /// <summary>Converts from <see cref="PromiseType1" /> to <see cref="Promise" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator Promise(PromiseType1 value) => new(value);
    }
}
