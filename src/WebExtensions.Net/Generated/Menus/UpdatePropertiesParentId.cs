using System.Text.Json.Serialization;

namespace WebExtensions.Net.Menus
{
    // Multitype Class
    /// <summary>Note: You cannot change an item to be a child of one of its own descendants.</summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<UpdatePropertiesParentId>))]
    public partial class UpdatePropertiesParentId : BaseMultiTypeObject
    {
        private readonly int valueInt;
        private readonly string valueString;

        /// <summary>Creates a new instance of <see cref="UpdatePropertiesParentId" />.</summary>
        /// <param name="value">The value.</param>
        public UpdatePropertiesParentId(int value) : base(value, typeof(int))
        {
            valueInt = value;
        }

        /// <summary>Creates a new instance of <see cref="UpdatePropertiesParentId" />.</summary>
        /// <param name="value">The value.</param>
        public UpdatePropertiesParentId(string value) : base(value, typeof(string))
        {
            valueString = value;
        }

        /// <summary>Converts from <see cref="UpdatePropertiesParentId" /> to <see cref="int" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator int(UpdatePropertiesParentId value) => value.valueInt;

        /// <summary>Converts from <see cref="int" /> to <see cref="UpdatePropertiesParentId" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator UpdatePropertiesParentId(int value) => new(value);

        /// <summary>Converts from <see cref="UpdatePropertiesParentId" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(UpdatePropertiesParentId value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="UpdatePropertiesParentId" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator UpdatePropertiesParentId(string value) => new(value);
    }
}
