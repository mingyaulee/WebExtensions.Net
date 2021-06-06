using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest
{
    // Multitype Class
    /// <summary></summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<PermissionNoPrompt>))]
    public class PermissionNoPrompt : BaseMultiTypeObject
    {
        private readonly OptionalPermission valueOptionalPermission;
        private readonly string valueString;

        /// <summary>Creates a new instance of <see cref="PermissionNoPrompt" />.</summary>
        /// <param name="value">The value.</param>
        public PermissionNoPrompt(OptionalPermission value) : base(value, typeof(OptionalPermission))
        {
            valueOptionalPermission = value;
        }

        /// <summary>Creates a new instance of <see cref="PermissionNoPrompt" />.</summary>
        /// <param name="value">The value.</param>
        public PermissionNoPrompt(string value) : base(value, typeof(string))
        {
            valueString = value;
        }

        /// <summary>Converts from <see cref="PermissionNoPrompt" /> to <see cref="OptionalPermission" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator OptionalPermission(PermissionNoPrompt value) => value.valueOptionalPermission;

        /// <summary>Converts from <see cref="OptionalPermission" /> to <see cref="PermissionNoPrompt" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator PermissionNoPrompt(OptionalPermission value) => new(value);

        /// <summary>Converts from <see cref="PermissionNoPrompt" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(PermissionNoPrompt value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="PermissionNoPrompt" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator PermissionNoPrompt(string value) => new(value);
    }
}
