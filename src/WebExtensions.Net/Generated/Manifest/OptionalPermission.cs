using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest;

// Multitype Class
/// <summary></summary>
[JsonConverter(typeof(MultiTypeJsonConverter<OptionalPermission>))]
public partial class OptionalPermission : BaseMultiTypeObject
{
    private readonly OptionalPermissionNoPrompt valueOptionalPermissionNoPrompt;
    private readonly OptionalPermissionType2 valueOptionalPermissionType2;

    /// <summary>Creates a new instance of <see cref="OptionalPermission" />.</summary>
    /// <param name="value">The value.</param>
    public OptionalPermission(OptionalPermissionNoPrompt value) : base(value, typeof(OptionalPermissionNoPrompt))
    {
        valueOptionalPermissionNoPrompt = value;
    }

    /// <summary>Creates a new instance of <see cref="OptionalPermission" />.</summary>
    /// <param name="value">The value.</param>
    public OptionalPermission(OptionalPermissionType2 value) : base(value, typeof(OptionalPermissionType2))
    {
        valueOptionalPermissionType2 = value;
    }

    /// <summary>Converts from <see cref="OptionalPermission" /> to <see cref="OptionalPermissionNoPrompt" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator OptionalPermissionNoPrompt(OptionalPermission value) => value.valueOptionalPermissionNoPrompt;

    /// <summary>Converts from <see cref="OptionalPermissionNoPrompt" /> to <see cref="OptionalPermission" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator OptionalPermission(OptionalPermissionNoPrompt value) => new(value);

    /// <summary>Converts from <see cref="OptionalPermission" /> to <see cref="OptionalPermissionType2" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator OptionalPermissionType2(OptionalPermission value) => value.valueOptionalPermissionType2;

    /// <summary>Converts from <see cref="OptionalPermissionType2" /> to <see cref="OptionalPermission" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator OptionalPermission(OptionalPermissionType2 value) => new(value);
}
