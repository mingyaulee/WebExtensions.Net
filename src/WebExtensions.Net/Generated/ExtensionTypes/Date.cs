using System.Text.Json.Serialization;

namespace WebExtensions.Net.ExtensionTypes;

// Multitype Class
/// <summary></summary>
[JsonConverter(typeof(MultiTypeJsonConverter<Date>))]
public partial class Date : BaseMultiTypeObject
{
    private readonly string valueString;
    private readonly int valueInt;

    /// <summary>Creates a new instance of <see cref="Date" />.</summary>
    /// <param name="value">The value.</param>
    public Date(string value) : base(value, typeof(string))
    {
        valueString = value;
    }

    /// <summary>Creates a new instance of <see cref="Date" />.</summary>
    /// <param name="value">The value.</param>
    public Date(int value) : base(value, typeof(int))
    {
        valueInt = value;
    }

    /// <summary>Creates a new instance of <see cref="Date" />.</summary>
    /// <param name="value">The value.</param>
    public Date(object value) : base(value, typeof(object))
    {
    }

    /// <summary>Converts from <see cref="Date" /> to <see cref="string" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator string(Date value) => value.valueString;

    /// <summary>Converts from <see cref="string" /> to <see cref="Date" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator Date(string value) => new(value);

    /// <summary>Converts from <see cref="Date" /> to <see cref="int" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator int(Date value) => value.valueInt;

    /// <summary>Converts from <see cref="int" /> to <see cref="Date" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator Date(int value) => new(value);
}
