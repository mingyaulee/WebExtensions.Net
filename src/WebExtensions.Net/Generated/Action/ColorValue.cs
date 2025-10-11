using System.Text.Json.Serialization;

namespace WebExtensions.Net.ActionNs;

// Multitype Class
/// <summary>An array of four integers in the range [0,255] that make up the RGBA color of the badge. For example, opaque red is <c>[255, 0, 0, 255]</c>. Can also be a string with a CSS value, with opaque red being <c>#FF0000</c> or <c>#F00</c>.</summary>
[JsonConverter(typeof(MultiTypeJsonConverter<ColorValue>))]
public partial class ColorValue : BaseMultiTypeObject
{
    private readonly string valueString;
    private readonly ColorArray valueColorArray;

    /// <summary>Creates a new instance of <see cref="ColorValue" />.</summary>
    public ColorValue() : base(null, null)
    {
    }

    /// <summary>Creates a new instance of <see cref="ColorValue" />.</summary>
    /// <param name="value">The value.</param>
    public ColorValue(string value) : base(value, typeof(string))
    {
        valueString = value;
    }

    /// <summary>Creates a new instance of <see cref="ColorValue" />.</summary>
    /// <param name="value">The value.</param>
    public ColorValue(ColorArray value) : base(value, typeof(ColorArray))
    {
        valueColorArray = value;
    }

    /// <summary>Converts from <see cref="ColorValue" /> to <see cref="string" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator string(ColorValue value) => value.valueString;

    /// <summary>Converts from <see cref="string" /> to <see cref="ColorValue" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator ColorValue(string value) => new(value);

    /// <summary>Converts from <see cref="ColorValue" /> to <see cref="ColorArray" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator ColorArray(ColorValue value) => value.valueColorArray;

    /// <summary>Converts from <see cref="ColorArray" /> to <see cref="ColorValue" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator ColorValue(ColorArray value) => new(value);
}
