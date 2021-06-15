using System.Text.Json.Serialization;

namespace WebExtensions.Net.Menus
{
    // Multitype Class
    /// <summary></summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<HasListenerCallbackInfoMenuIdsArrayItem>))]
    public partial class HasListenerCallbackInfoMenuIdsArrayItem : BaseMultiTypeObject
    {
        private readonly int valueInt;
        private readonly string valueString;

        /// <summary>Creates a new instance of <see cref="HasListenerCallbackInfoMenuIdsArrayItem" />.</summary>
        /// <param name="value">The value.</param>
        public HasListenerCallbackInfoMenuIdsArrayItem(int value) : base(value, typeof(int))
        {
            valueInt = value;
        }

        /// <summary>Creates a new instance of <see cref="HasListenerCallbackInfoMenuIdsArrayItem" />.</summary>
        /// <param name="value">The value.</param>
        public HasListenerCallbackInfoMenuIdsArrayItem(string value) : base(value, typeof(string))
        {
            valueString = value;
        }

        /// <summary>Converts from <see cref="HasListenerCallbackInfoMenuIdsArrayItem" /> to <see cref="int" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator int(HasListenerCallbackInfoMenuIdsArrayItem value) => value.valueInt;

        /// <summary>Converts from <see cref="int" /> to <see cref="HasListenerCallbackInfoMenuIdsArrayItem" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator HasListenerCallbackInfoMenuIdsArrayItem(int value) => new(value);

        /// <summary>Converts from <see cref="HasListenerCallbackInfoMenuIdsArrayItem" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(HasListenerCallbackInfoMenuIdsArrayItem value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="HasListenerCallbackInfoMenuIdsArrayItem" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator HasListenerCallbackInfoMenuIdsArrayItem(string value) => new(value);
    }
}
