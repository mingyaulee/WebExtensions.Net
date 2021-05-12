namespace WebExtension.Net.Manifest
{
    // Multitype Class
    /// <summary></summary>
    public class OptionalPermission
    {
        private readonly OptionalPermissionNoPrompt valueOptionalPermissionNoPrompt;
        private readonly string valueString;
        private readonly object currentValue = null;

        /// <summary>Creates a new instance of <see cref="OptionalPermission" />.</summary>
        /// <param name="value">The value.</param>
        public OptionalPermission(OptionalPermissionNoPrompt value)
        {
            valueOptionalPermissionNoPrompt = value;
            currentValue = value;
        }

        /// <summary>Creates a new instance of <see cref="OptionalPermission" />.</summary>
        /// <param name="value">The value.</param>
        public OptionalPermission(string value)
        {
            valueString = value;
            currentValue = value;
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

        /// <inheritdoc />
        public override string ToString()
        {
            return currentValue?.ToString();
        }
    }
}
