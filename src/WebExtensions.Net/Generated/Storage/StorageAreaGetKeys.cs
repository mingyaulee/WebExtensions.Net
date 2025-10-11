using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Storage;

// Multitype Class
/// <summary>A single key to get, list of keys to get, or a dictionary specifying default values (see description of the object).  An empty list or object will return an empty result object.  Pass in <c>null</c> to get the entire contents of storage.</summary>
[JsonConverter(typeof(MultiTypeJsonConverter<StorageAreaGetKeys>))]
public partial class StorageAreaGetKeys : BaseMultiTypeObject
{
    private readonly string valueString;

    /// <summary>Creates a new instance of <see cref="StorageAreaGetKeys" />.</summary>
    /// <param name="value">The value.</param>
    public StorageAreaGetKeys(string value) : base(value, typeof(string))
    {
        valueString = value;
    }

    /// <summary>Creates a new instance of <see cref="StorageAreaGetKeys" />.</summary>
    /// <param name="value">The value.</param>
    public StorageAreaGetKeys(IEnumerable<string> value) : base(value, typeof(IEnumerable<string>))
    {
    }

    /// <summary>Creates a new instance of <see cref="StorageAreaGetKeys" />.</summary>
    /// <param name="value">The value.</param>
    public StorageAreaGetKeys(object value) : base(value, typeof(object))
    {
    }

    /// <summary>Converts from <see cref="StorageAreaGetKeys" /> to <see cref="string" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator string(StorageAreaGetKeys value) => value.valueString;

    /// <summary>Converts from <see cref="string" /> to <see cref="StorageAreaGetKeys" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator StorageAreaGetKeys(string value) => new(value);
}
