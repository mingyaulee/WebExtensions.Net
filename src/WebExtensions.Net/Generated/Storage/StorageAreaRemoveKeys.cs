using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Storage
{
    // Multitype Class
    /// <summary>A single key or a list of keys for items to remove.</summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<StorageAreaRemoveKeys>))]
    public partial class StorageAreaRemoveKeys : BaseMultiTypeObject
    {
        private readonly string valueString;

        /// <summary>Creates a new instance of <see cref="StorageAreaRemoveKeys" />.</summary>
        /// <param name="value">The value.</param>
        public StorageAreaRemoveKeys(string value) : base(value, typeof(string))
        {
            valueString = value;
        }

        /// <summary>Creates a new instance of <see cref="StorageAreaRemoveKeys" />.</summary>
        /// <param name="value">The value.</param>
        public StorageAreaRemoveKeys(IEnumerable<string> value) : base(value, typeof(IEnumerable<string>))
        {
        }

        /// <summary>Converts from <see cref="StorageAreaRemoveKeys" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(StorageAreaRemoveKeys value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="StorageAreaRemoveKeys" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator StorageAreaRemoveKeys(string value) => new(value);
    }
}
