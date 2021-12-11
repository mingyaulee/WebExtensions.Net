using System.Text.Json.Serialization;

namespace WebExtensions.Net.ActionNs
{
    // Multitype Class
    /// <summary>The html file to show in a popup.  If set to the empty string (''), no popup is shown.</summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<Popup>))]
    public partial class Popup : BaseMultiTypeObject
    {
        private readonly string valueString;

        /// <summary>Creates a new instance of <see cref="Popup" />.</summary>
        public Popup() : base(null, null)
        {
        }

        /// <summary>Creates a new instance of <see cref="Popup" />.</summary>
        /// <param name="value">The value.</param>
        public Popup(string value) : base(value, typeof(string))
        {
            valueString = value;
        }

        /// <summary>Converts from <see cref="Popup" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(Popup value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="Popup" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator Popup(string value) => new(value);
    }
}
