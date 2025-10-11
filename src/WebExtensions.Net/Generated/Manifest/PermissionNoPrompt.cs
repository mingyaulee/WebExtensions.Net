using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest;

// Multitype Class
/// <summary></summary>
[JsonConverter(typeof(MultiTypeJsonConverter<PermissionNoPrompt>))]
public partial class PermissionNoPrompt : BaseMultiTypeObject
{
    private readonly OptionalPermissionNoPrompt valueOptionalPermissionNoPrompt;
    private readonly PermissionPrivileged valuePermissionPrivileged;
    private readonly PermissionNoPromptType3 valuePermissionNoPromptType3;

    /// <summary>Creates a new instance of <see cref="PermissionNoPrompt" />.</summary>
    /// <param name="value">The value.</param>
    public PermissionNoPrompt(OptionalPermissionNoPrompt value) : base(value, typeof(OptionalPermissionNoPrompt))
    {
        valueOptionalPermissionNoPrompt = value;
    }

    /// <summary>Creates a new instance of <see cref="PermissionNoPrompt" />.</summary>
    /// <param name="value">The value.</param>
    public PermissionNoPrompt(PermissionPrivileged value) : base(value, typeof(PermissionPrivileged))
    {
        valuePermissionPrivileged = value;
    }

    /// <summary>Creates a new instance of <see cref="PermissionNoPrompt" />.</summary>
    /// <param name="value">The value.</param>
    public PermissionNoPrompt(PermissionNoPromptType3 value) : base(value, typeof(PermissionNoPromptType3))
    {
        valuePermissionNoPromptType3 = value;
    }

    /// <summary>Converts from <see cref="PermissionNoPrompt" /> to <see cref="OptionalPermissionNoPrompt" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator OptionalPermissionNoPrompt(PermissionNoPrompt value) => value.valueOptionalPermissionNoPrompt;

    /// <summary>Converts from <see cref="OptionalPermissionNoPrompt" /> to <see cref="PermissionNoPrompt" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator PermissionNoPrompt(OptionalPermissionNoPrompt value) => new(value);

    /// <summary>Converts from <see cref="PermissionNoPrompt" /> to <see cref="PermissionPrivileged" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator PermissionPrivileged(PermissionNoPrompt value) => value.valuePermissionPrivileged;

    /// <summary>Converts from <see cref="PermissionPrivileged" /> to <see cref="PermissionNoPrompt" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator PermissionNoPrompt(PermissionPrivileged value) => new(value);

    /// <summary>Converts from <see cref="PermissionNoPrompt" /> to <see cref="PermissionNoPromptType3" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator PermissionNoPromptType3(PermissionNoPrompt value) => value.valuePermissionNoPromptType3;

    /// <summary>Converts from <see cref="PermissionNoPromptType3" /> to <see cref="PermissionNoPrompt" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator PermissionNoPrompt(PermissionNoPromptType3 value) => new(value);
}
