using System.Text.Json.Serialization;

namespace WebExtensions.Net.Menus
{
    // Multitype Class
    /// <summary>The ID of the newly created item.</summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<CreateReturnType>))]
    public partial class CreateReturnType : BaseMultiTypeObject
    {
        private readonly int valueInt;
        private readonly string valueString;

        /// <summary>Creates a new instance of <see cref="CreateReturnType" />.</summary>
        /// <param name="value">The value.</param>
        public CreateReturnType(int value) : base(value, typeof(int))
        {
            valueInt = value;
        }

        /// <summary>Creates a new instance of <see cref="CreateReturnType" />.</summary>
        /// <param name="value">The value.</param>
        public CreateReturnType(string value) : base(value, typeof(string))
        {
            valueString = value;
        }

        /// <summary>Converts from <see cref="CreateReturnType" /> to <see cref="int" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator int(CreateReturnType value) => value.valueInt;

        /// <summary>Converts from <see cref="int" /> to <see cref="CreateReturnType" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator CreateReturnType(int value) => new(value);

        /// <summary>Converts from <see cref="CreateReturnType" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(CreateReturnType value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="CreateReturnType" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator CreateReturnType(string value) => new(value);
    }
}
