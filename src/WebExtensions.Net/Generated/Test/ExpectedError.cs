using System;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Test;

// Multitype Class
/// <summary></summary>
[JsonConverter(typeof(MultiTypeJsonConverter<ExpectedError>))]
public partial class ExpectedError : BaseMultiTypeObject
{
    private readonly string valueString;
    private readonly Action valueAction;

    /// <summary>Creates a new instance of <see cref="ExpectedError" />.</summary>
    /// <param name="value">The value.</param>
    public ExpectedError(string value) : base(value, typeof(string))
    {
        valueString = value;
    }

    /// <summary>Creates a new instance of <see cref="ExpectedError" />.</summary>
    /// <param name="value">The value.</param>
    public ExpectedError(object value) : base(value, typeof(object))
    {
    }

    /// <summary>Creates a new instance of <see cref="ExpectedError" />.</summary>
    /// <param name="value">The value.</param>
    public ExpectedError(Action value) : base(value, typeof(Action))
    {
        valueAction = value;
    }

    /// <summary>Converts from <see cref="ExpectedError" /> to <see cref="string" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator string(ExpectedError value) => value.valueString;

    /// <summary>Converts from <see cref="string" /> to <see cref="ExpectedError" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator ExpectedError(string value) => new(value);

    /// <summary>Converts from <see cref="ExpectedError" /> to <see cref="Action" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator Action(ExpectedError value) => value.valueAction;

    /// <summary>Converts from <see cref="Action" /> to <see cref="ExpectedError" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator ExpectedError(Action value) => new(value);
}
