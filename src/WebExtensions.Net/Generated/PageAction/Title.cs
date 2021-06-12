using System.Text.Json.Serialization;

namespace WebExtensions.Net.PageAction
{
    // Multitype Class
    /// <summary>The tooltip string.</summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<Title>))]
    public partial class Title : BaseMultiTypeObject
    {
        private readonly string valueString;

        /// <summary>Creates a new instance of <see cref="Title" />.</summary>
        public Title() : base(null, null)
        {
        }

        /// <summary>Creates a new instance of <see cref="Title" />.</summary>
        /// <param name="value">The value.</param>
        public Title(string value) : base(value, typeof(string))
        {
            valueString = value;
        }

        /// <summary>Converts from <see cref="Title" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(Title value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="Title" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator Title(string value) => new(value);
    }
}
