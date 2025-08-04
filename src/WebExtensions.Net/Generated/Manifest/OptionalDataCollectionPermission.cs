using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest
{
    // Multitype Class
    /// <summary></summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<OptionalDataCollectionPermission>))]
    public partial class OptionalDataCollectionPermission : BaseMultiTypeObject
    {
        private readonly CommonDataCollectionPermission valueCommonDataCollectionPermission;
        private readonly OptionalDataCollectionPermissionType2 valueOptionalDataCollectionPermissionType2;

        /// <summary>Creates a new instance of <see cref="OptionalDataCollectionPermission" />.</summary>
        /// <param name="value">The value.</param>
        public OptionalDataCollectionPermission(CommonDataCollectionPermission value) : base(value, typeof(CommonDataCollectionPermission))
        {
            valueCommonDataCollectionPermission = value;
        }

        /// <summary>Creates a new instance of <see cref="OptionalDataCollectionPermission" />.</summary>
        /// <param name="value">The value.</param>
        public OptionalDataCollectionPermission(OptionalDataCollectionPermissionType2 value) : base(value, typeof(OptionalDataCollectionPermissionType2))
        {
            valueOptionalDataCollectionPermissionType2 = value;
        }

        /// <summary>Converts from <see cref="OptionalDataCollectionPermission" /> to <see cref="CommonDataCollectionPermission" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator CommonDataCollectionPermission(OptionalDataCollectionPermission value) => value.valueCommonDataCollectionPermission;

        /// <summary>Converts from <see cref="CommonDataCollectionPermission" /> to <see cref="OptionalDataCollectionPermission" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator OptionalDataCollectionPermission(CommonDataCollectionPermission value) => new(value);

        /// <summary>Converts from <see cref="OptionalDataCollectionPermission" /> to <see cref="OptionalDataCollectionPermissionType2" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator OptionalDataCollectionPermissionType2(OptionalDataCollectionPermission value) => value.valueOptionalDataCollectionPermissionType2;

        /// <summary>Converts from <see cref="OptionalDataCollectionPermissionType2" /> to <see cref="OptionalDataCollectionPermission" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator OptionalDataCollectionPermission(OptionalDataCollectionPermissionType2 value) => new(value);
    }
}
