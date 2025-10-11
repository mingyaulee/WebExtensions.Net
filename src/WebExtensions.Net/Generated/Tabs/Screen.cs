using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs;

// Multitype Class
/// <summary>True for any screen sharing, or a string to specify type of screen sharing.</summary>
[JsonConverter(typeof(MultiTypeJsonConverter<Screen>))]
public partial class Screen : BaseMultiTypeObject
{
    private readonly ScreenType1 valueScreenType1;
    private readonly bool valueBool;

    /// <summary>Creates a new instance of <see cref="Screen" />.</summary>
    /// <param name="value">The value.</param>
    public Screen(ScreenType1 value) : base(value, typeof(ScreenType1))
    {
        valueScreenType1 = value;
    }

    /// <summary>Creates a new instance of <see cref="Screen" />.</summary>
    /// <param name="value">The value.</param>
    public Screen(bool value) : base(value, typeof(bool))
    {
        valueBool = value;
    }

    /// <summary>Converts from <see cref="Screen" /> to <see cref="ScreenType1" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator ScreenType1(Screen value) => value.valueScreenType1;

    /// <summary>Converts from <see cref="ScreenType1" /> to <see cref="Screen" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator Screen(ScreenType1 value) => new(value);

    /// <summary>Converts from <see cref="Screen" /> to <see cref="bool" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator bool(Screen value) => value.valueBool;

    /// <summary>Converts from <see cref="bool" /> to <see cref="Screen" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator Screen(bool value) => new(value);
}
