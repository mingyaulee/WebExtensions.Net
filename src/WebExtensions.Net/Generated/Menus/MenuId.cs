using System.Text.Json.Serialization;

namespace WebExtensions.Net.Menus
{
    // Multitype Class
    /// <summary></summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<MenuId>))]
    public partial class MenuId : BaseMultiTypeObject
    {
        private readonly int valueInt;
        private readonly string valueString;

        /// <summary>Creates a new instance of <see cref="MenuId" />.</summary>
        /// <param name="value">The value.</param>
        public MenuId(int value) : base(value, typeof(int))
        {
            valueInt = value;
        }

        /// <summary>Creates a new instance of <see cref="MenuId" />.</summary>
        /// <param name="value">The value.</param>
        public MenuId(string value) : base(value, typeof(string))
        {
            valueString = value;
        }

        /// <summary>Converts from <see cref="MenuId" /> to <see cref="int" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator int(MenuId value) => value.valueInt;

        /// <summary>Converts from <see cref="int" /> to <see cref="MenuId" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator MenuId(int value) => new(value);

        /// <summary>Converts from <see cref="MenuId" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(MenuId value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="MenuId" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator MenuId(string value) => new(value);
    }
}
