using System.Text.Json.Serialization;

namespace WebExtensions.Net.Action
{
    // Multitype Class
    /// <summary>Any number of characters can be passed, but only about four can fit in the space.</summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<Text>))]
    public partial class Text : BaseMultiTypeObject
    {
        private readonly string valueString;

        /// <summary>Creates a new instance of <see cref="Text" />.</summary>
        public Text() : base(null, null)
        {
        }

        /// <summary>Creates a new instance of <see cref="Text" />.</summary>
        /// <param name="value">The value.</param>
        public Text(string value) : base(value, typeof(string))
        {
            valueString = value;
        }

        /// <summary>Converts from <see cref="Text" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(Text value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="Text" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator Text(string value) => new(value);
    }
}
