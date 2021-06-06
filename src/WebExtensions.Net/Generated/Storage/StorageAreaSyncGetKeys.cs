using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtension.Net.Storage
{
    // Multitype Class
    /// <summary>A single key to get, list of keys to get, or a dictionary specifying default values (see description of the object).  An empty list or object will return an empty result object.  Pass in <c>null</c> to get the entire contents of storage.</summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<StorageAreaSyncGetKeys>))]
    public class StorageAreaSyncGetKeys : BaseMultiTypeObject
    {
        private readonly string valueString;

        /// <summary>Creates a new instance of <see cref="StorageAreaSyncGetKeys" />.</summary>
        /// <param name="value">The value.</param>
        public StorageAreaSyncGetKeys(string value) : base(value, typeof(string))
        {
            valueString = value;
        }

        /// <summary>Creates a new instance of <see cref="StorageAreaSyncGetKeys" />.</summary>
        /// <param name="value">The value.</param>
        public StorageAreaSyncGetKeys(IEnumerable<string> value) : base(value, typeof(IEnumerable<string>))
        {
        }

        /// <summary>Creates a new instance of <see cref="StorageAreaSyncGetKeys" />.</summary>
        /// <param name="value">The value.</param>
        public StorageAreaSyncGetKeys(object value) : base(value, typeof(object))
        {
        }

        /// <summary>Converts from <see cref="StorageAreaSyncGetKeys" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(StorageAreaSyncGetKeys value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="StorageAreaSyncGetKeys" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator StorageAreaSyncGetKeys(string value) => new(value);
    }
}
