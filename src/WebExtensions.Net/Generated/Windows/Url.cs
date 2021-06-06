using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtension.Net.Windows
{
    // Multitype Class
    /// <summary>A URL or array of URLs to open as tabs in the window. Fully-qualified URLs must include a scheme (i.e. 'http://www.google.com', not 'www.google.com'). Relative URLs will be relative to the current page within the extension. Defaults to the New Tab Page.</summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<Url>))]
    public class Url : BaseMultiTypeObject
    {
        private readonly string valueString;

        /// <summary>Creates a new instance of <see cref="Url" />.</summary>
        /// <param name="value">The value.</param>
        public Url(string value) : base(value, typeof(string))
        {
            valueString = value;
        }

        /// <summary>Creates a new instance of <see cref="Url" />.</summary>
        /// <param name="value">The value.</param>
        public Url(IEnumerable<string> value) : base(value, typeof(IEnumerable<string>))
        {
        }

        /// <summary>Converts from <see cref="Url" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(Url value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="Url" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator Url(string value) => new(value);
    }
}
