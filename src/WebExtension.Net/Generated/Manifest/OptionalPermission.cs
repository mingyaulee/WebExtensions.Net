using System.Text.Json.Serialization;

namespace WebExtension.Net.Manifest
{
    // Multitype Class
    /// <summary></summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<OptionalPermission>))]
    public class OptionalPermission : BaseMultiTypeObject
    {
        private readonly OptionalPermissionNoPrompt valueOptionalPermissionNoPrompt;
        private readonly string valueString;

        /// <summary>Creates a new instance of <see cref="OptionalPermission" />.</summary>
        /// <param name="value">The value.</param>
        public OptionalPermission(OptionalPermissionNoPrompt value) : base(value, typeof(OptionalPermissionNoPrompt))
        {
            valueOptionalPermissionNoPrompt = value;
        }

        /// <summary>Creates a new instance of <see cref="OptionalPermission" />.</summary>
        /// <param name="value">The value.</param>
        public OptionalPermission(string value) : base(value, typeof(string))
        {
            valueString = value;
        }

        /// <summary>Converts from <see cref="OptionalPermission" /> to <see cref="OptionalPermissionNoPrompt" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator OptionalPermissionNoPrompt(OptionalPermission value) => value.valueOptionalPermissionNoPrompt;

        /// <summary>Converts from <see cref="OptionalPermissionNoPrompt" /> to <see cref="OptionalPermission" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator OptionalPermission(OptionalPermissionNoPrompt value) => new(value);

        /// <summary>Converts from <see cref="OptionalPermission" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(OptionalPermission value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="OptionalPermission" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator OptionalPermission(string value) => new(value);
    }
}
