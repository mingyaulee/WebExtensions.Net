using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Storage
{
    // Multitype Class
    /// <summary>A single key or a list of keys for items to remove.</summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<StorageAreaSyncRemoveKeys>))]
    public class StorageAreaSyncRemoveKeys : BaseMultiTypeObject
    {
        private readonly string valueString;

        /// <summary>Creates a new instance of <see cref="StorageAreaSyncRemoveKeys" />.</summary>
        /// <param name="value">The value.</param>
        public StorageAreaSyncRemoveKeys(string value) : base(value, typeof(string))
        {
            valueString = value;
        }

        /// <summary>Creates a new instance of <see cref="StorageAreaSyncRemoveKeys" />.</summary>
        /// <param name="value">The value.</param>
        public StorageAreaSyncRemoveKeys(IEnumerable<string> value) : base(value, typeof(IEnumerable<string>))
        {
        }

        /// <summary>Converts from <see cref="StorageAreaSyncRemoveKeys" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(StorageAreaSyncRemoveKeys value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="StorageAreaSyncRemoveKeys" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator StorageAreaSyncRemoveKeys(string value) => new(value);
    }
}
