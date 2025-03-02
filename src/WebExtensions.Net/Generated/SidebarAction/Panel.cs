using System.Text.Json.Serialization;

namespace WebExtensions.Net.SidebarAction
{
    // Multitype Class
    /// <summary>The url to the html file to show in a sidebar.  If set to the empty string (''), no sidebar is shown.</summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<Panel>))]
    public partial class Panel : BaseMultiTypeObject
    {
        private readonly string valueString;

        /// <summary>Creates a new instance of <see cref="Panel" />.</summary>
        public Panel() : base(null, null)
        {
        }

        /// <summary>Creates a new instance of <see cref="Panel" />.</summary>
        /// <param name="value">The value.</param>
        public Panel(string value) : base(value, typeof(string))
        {
            valueString = value;
        }

        /// <summary>Converts from <see cref="Panel" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(Panel value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="Panel" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator Panel(string value) => new(value);
    }
}
