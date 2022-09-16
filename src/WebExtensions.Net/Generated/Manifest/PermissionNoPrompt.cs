using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest
{
    // Multitype Class
    /// <summary></summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<PermissionNoPrompt>))]
    public partial class PermissionNoPrompt : BaseMultiTypeObject
    {
        private readonly OptionalPermissionNoPrompt valueOptionalPermissionNoPrompt;
        private readonly PermissionPrivileged valuePermissionPrivileged;
        private readonly string valueString;

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
        public PermissionNoPrompt(string value) : base(value, typeof(string))
        {
            valueString = value;
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

        /// <summary>Converts from <see cref="PermissionNoPrompt" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(PermissionNoPrompt value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="PermissionNoPrompt" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator PermissionNoPrompt(string value) => new(value);
    }
}
