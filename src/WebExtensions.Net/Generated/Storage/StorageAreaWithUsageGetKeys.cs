using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Storage;

// Multitype Class
/// <summary>A single key to get, list of keys to get, or a dictionary specifying default values (see description of the object).  An empty list or object will return an empty result object.  Pass in <c>null</c> to get the entire contents of storage.</summary>
[JsonConverter(typeof(MultiTypeJsonConverter<StorageAreaWithUsageGetKeys>))]
public partial class StorageAreaWithUsageGetKeys : BaseMultiTypeObject
{
    private readonly string valueString;

    /// <summary>Creates a new instance of <see cref="StorageAreaWithUsageGetKeys" />.</summary>
    /// <param name="value">The value.</param>
    public StorageAreaWithUsageGetKeys(string value) : base(value, typeof(string))
    {
        valueString = value;
    }

    /// <summary>Creates a new instance of <see cref="StorageAreaWithUsageGetKeys" />.</summary>
    /// <param name="value">The value.</param>
    public StorageAreaWithUsageGetKeys(IEnumerable<string> value) : base(value, typeof(IEnumerable<string>))
    {
    }

    /// <summary>Creates a new instance of <see cref="StorageAreaWithUsageGetKeys" />.</summary>
    /// <param name="value">The value.</param>
    public StorageAreaWithUsageGetKeys(object value) : base(value, typeof(object))
    {
    }

    /// <summary>Converts from <see cref="StorageAreaWithUsageGetKeys" /> to <see cref="string" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator string(StorageAreaWithUsageGetKeys value) => value.valueString;

    /// <summary>Converts from <see cref="string" /> to <see cref="StorageAreaWithUsageGetKeys" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator StorageAreaWithUsageGetKeys(string value) => new(value);
}
