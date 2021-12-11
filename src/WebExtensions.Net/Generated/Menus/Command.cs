using System.Text.Json.Serialization;

namespace WebExtensions.Net.Menus
{
    // Multitype Class
    /// <summary>Specifies a command to issue for the context click.</summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<Command>))]
    public partial class Command : BaseMultiTypeObject
    {
        private readonly string valueString;

        /// <summary>Creates a new instance of <see cref="Command" />.</summary>
        /// <param name="value">The value.</param>
        public Command(string value) : base(value, typeof(string))
        {
            valueString = value;
        }

        /// <summary>Converts from <see cref="Command" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(Command value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="Command" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator Command(string value) => new(value);
    }
}
