using System.Text.Json.Serialization;

namespace WebExtensions.Net.Menus
{
    // Multitype Class
    /// <summary>The parent ID, if any, for the item clicked.</summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<ParentMenuItemId>))]
    public partial class ParentMenuItemId : BaseMultiTypeObject
    {
        private readonly int valueInt;
        private readonly string valueString;

        /// <summary>Creates a new instance of <see cref="ParentMenuItemId" />.</summary>
        /// <param name="value">The value.</param>
        public ParentMenuItemId(int value) : base(value, typeof(int))
        {
            valueInt = value;
        }

        /// <summary>Creates a new instance of <see cref="ParentMenuItemId" />.</summary>
        /// <param name="value">The value.</param>
        public ParentMenuItemId(string value) : base(value, typeof(string))
        {
            valueString = value;
        }

        /// <summary>Converts from <see cref="ParentMenuItemId" /> to <see cref="int" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator int(ParentMenuItemId value) => value.valueInt;

        /// <summary>Converts from <see cref="int" /> to <see cref="ParentMenuItemId" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator ParentMenuItemId(int value) => new(value);

        /// <summary>Converts from <see cref="ParentMenuItemId" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(ParentMenuItemId value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="ParentMenuItemId" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator ParentMenuItemId(string value) => new(value);
    }
}
