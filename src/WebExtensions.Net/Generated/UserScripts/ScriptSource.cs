using System.Text.Json.Serialization;

namespace WebExtensions.Net.UserScripts;

// Multitype Class
/// <summary>Object with file xor code property. Equivalent to the ExtensionFileOrCode, except the file remains a relative URL.</summary>
[JsonConverter(typeof(MultiTypeJsonConverter<ScriptSource>))]
public partial class ScriptSource : BaseMultiTypeObject
{
    private readonly ScriptSourceType1 valueScriptSourceType1;
    private readonly ScriptSourceType2 valueScriptSourceType2;

    /// <summary>Creates a new instance of <see cref="ScriptSource" />.</summary>
    /// <param name="value">The value.</param>
    public ScriptSource(ScriptSourceType1 value) : base(value, typeof(ScriptSourceType1))
    {
        valueScriptSourceType1 = value;
    }

    /// <summary>Creates a new instance of <see cref="ScriptSource" />.</summary>
    /// <param name="value">The value.</param>
    public ScriptSource(ScriptSourceType2 value) : base(value, typeof(ScriptSourceType2))
    {
        valueScriptSourceType2 = value;
    }

    /// <summary>Converts from <see cref="ScriptSource" /> to <see cref="ScriptSourceType1" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator ScriptSourceType1(ScriptSource value) => value.valueScriptSourceType1;

    /// <summary>Converts from <see cref="ScriptSourceType1" /> to <see cref="ScriptSource" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator ScriptSource(ScriptSourceType1 value) => new(value);

    /// <summary>Converts from <see cref="ScriptSource" /> to <see cref="ScriptSourceType2" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator ScriptSourceType2(ScriptSource value) => value.valueScriptSourceType2;

    /// <summary>Converts from <see cref="ScriptSourceType2" /> to <see cref="ScriptSource" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator ScriptSource(ScriptSourceType2 value) => new(value);
}
