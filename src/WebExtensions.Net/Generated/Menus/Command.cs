using System.Text.Json.Serialization;

namespace WebExtensions.Net.Menus
{
    // Multitype Class
    /// <summary>Specifies a command to issue for the context click.</summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<Command>))]
    public partial class Command : BaseMultiTypeObject
    {
        private readonly string valueString;
        private readonly CommandType2 valueCommandType2;
        private readonly CommandType3 valueCommandType3;

        /// <summary>Creates a new instance of <see cref="Command" />.</summary>
        /// <param name="value">The value.</param>
        public Command(string value) : base(value, typeof(string))
        {
            valueString = value;
        }

        /// <summary>Creates a new instance of <see cref="Command" />.</summary>
        /// <param name="value">The value.</param>
        public Command(CommandType2 value) : base(value, typeof(CommandType2))
        {
            valueCommandType2 = value;
        }

        /// <summary>Creates a new instance of <see cref="Command" />.</summary>
        /// <param name="value">The value.</param>
        public Command(CommandType3 value) : base(value, typeof(CommandType3))
        {
            valueCommandType3 = value;
        }

        /// <summary>Converts from <see cref="Command" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(Command value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="Command" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator Command(string value) => new(value);

        /// <summary>Converts from <see cref="Command" /> to <see cref="CommandType2" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator CommandType2(Command value) => value.valueCommandType2;

        /// <summary>Converts from <see cref="CommandType2" /> to <see cref="Command" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator Command(CommandType2 value) => new(value);

        /// <summary>Converts from <see cref="Command" /> to <see cref="CommandType3" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator CommandType3(Command value) => value.valueCommandType3;

        /// <summary>Converts from <see cref="CommandType3" /> to <see cref="Command" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator Command(CommandType3 value) => new(value);
    }
}
