using System.Text.Json.Serialization;

namespace WebExtensions.Net.Menus
{
    // Multitype Class
    /// <summary>The ID of the menu item that was clicked.</summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<OnClickDataMenuItemId>))]
    public partial class OnClickDataMenuItemId : BaseMultiTypeObject
    {
        private readonly int valueInt;
        private readonly string valueString;

        /// <summary>Creates a new instance of <see cref="OnClickDataMenuItemId" />.</summary>
        /// <param name="value">The value.</param>
        public OnClickDataMenuItemId(int value) : base(value, typeof(int))
        {
            valueInt = value;
        }

        /// <summary>Creates a new instance of <see cref="OnClickDataMenuItemId" />.</summary>
        /// <param name="value">The value.</param>
        public OnClickDataMenuItemId(string value) : base(value, typeof(string))
        {
            valueString = value;
        }

        /// <summary>Converts from <see cref="OnClickDataMenuItemId" /> to <see cref="int" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator int(OnClickDataMenuItemId value) => value.valueInt;

        /// <summary>Converts from <see cref="int" /> to <see cref="OnClickDataMenuItemId" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator OnClickDataMenuItemId(int value) => new(value);

        /// <summary>Converts from <see cref="OnClickDataMenuItemId" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(OnClickDataMenuItemId value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="OnClickDataMenuItemId" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator OnClickDataMenuItemId(string value) => new(value);
    }
}
