using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Multitype Class
    /// <summary>True for any screen sharing, or a string to specify type of screen sharing.</summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<Screen>))]
    public class Screen : BaseMultiTypeObject
    {
        private readonly string valueString;
        private readonly bool valueBool;

        /// <summary>Creates a new instance of <see cref="Screen" />.</summary>
        /// <param name="value">The value.</param>
        public Screen(string value) : base(value, typeof(string))
        {
            valueString = value;
        }

        /// <summary>Creates a new instance of <see cref="Screen" />.</summary>
        /// <param name="value">The value.</param>
        public Screen(bool value) : base(value, typeof(bool))
        {
            valueBool = value;
        }

        /// <summary>Converts from <see cref="Screen" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(Screen value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="Screen" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator Screen(string value) => new(value);

        /// <summary>Converts from <see cref="Screen" /> to <see cref="bool" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator bool(Screen value) => value.valueBool;

        /// <summary>Converts from <see cref="bool" /> to <see cref="Screen" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator Screen(bool value) => new(value);
    }
}
