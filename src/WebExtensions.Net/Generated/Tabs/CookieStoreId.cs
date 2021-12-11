using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Multitype Class
    /// <summary>The CookieStoreId used for the tab.</summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<CookieStoreId>))]
    public partial class CookieStoreId : BaseMultiTypeObject
    {
        private readonly string valueString;

        /// <summary>Creates a new instance of <see cref="CookieStoreId" />.</summary>
        /// <param name="value">The value.</param>
        public CookieStoreId(IEnumerable<string> value) : base(value, typeof(IEnumerable<string>))
        {
        }

        /// <summary>Creates a new instance of <see cref="CookieStoreId" />.</summary>
        /// <param name="value">The value.</param>
        public CookieStoreId(string value) : base(value, typeof(string))
        {
            valueString = value;
        }

        /// <summary>Converts from <see cref="CookieStoreId" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(CookieStoreId value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="CookieStoreId" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator CookieStoreId(string value) => new(value);
    }
}
