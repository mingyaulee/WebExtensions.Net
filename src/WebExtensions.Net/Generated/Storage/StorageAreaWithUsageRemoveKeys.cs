using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Storage;

// Multitype Class
/// <summary>A single key or a list of keys for items to remove.</summary>
[JsonConverter(typeof(MultiTypeJsonConverter<StorageAreaWithUsageRemoveKeys>))]
public partial class StorageAreaWithUsageRemoveKeys : BaseMultiTypeObject
{
    private readonly string valueString;

    /// <summary>Creates a new instance of <see cref="StorageAreaWithUsageRemoveKeys" />.</summary>
    /// <param name="value">The value.</param>
    public StorageAreaWithUsageRemoveKeys(string value) : base(value, typeof(string))
    {
        valueString = value;
    }

    /// <summary>Creates a new instance of <see cref="StorageAreaWithUsageRemoveKeys" />.</summary>
    /// <param name="value">The value.</param>
    public StorageAreaWithUsageRemoveKeys(IEnumerable<string> value) : base(value, typeof(IEnumerable<string>))
    {
    }

    /// <summary>Converts from <see cref="StorageAreaWithUsageRemoveKeys" /> to <see cref="string" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator string(StorageAreaWithUsageRemoveKeys value) => value.valueString;

    /// <summary>Converts from <see cref="string" /> to <see cref="StorageAreaWithUsageRemoveKeys" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator StorageAreaWithUsageRemoveKeys(string value) => new(value);
}
