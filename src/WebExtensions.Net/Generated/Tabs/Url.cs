using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Multitype Class
    /// <summary>Match tabs against one or more $(topic:match_patterns)[URL patterns]. Note that fragment identifiers are not matched.</summary>
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
