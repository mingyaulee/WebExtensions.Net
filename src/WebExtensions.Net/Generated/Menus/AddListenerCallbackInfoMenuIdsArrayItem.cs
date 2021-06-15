using System.Text.Json.Serialization;

namespace WebExtensions.Net.Menus
{
    // Multitype Class
    /// <summary></summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<AddListenerCallbackInfoMenuIdsArrayItem>))]
    public partial class AddListenerCallbackInfoMenuIdsArrayItem : BaseMultiTypeObject
    {
        private readonly int valueInt;
        private readonly string valueString;

        /// <summary>Creates a new instance of <see cref="AddListenerCallbackInfoMenuIdsArrayItem" />.</summary>
        /// <param name="value">The value.</param>
        public AddListenerCallbackInfoMenuIdsArrayItem(int value) : base(value, typeof(int))
        {
            valueInt = value;
        }

        /// <summary>Creates a new instance of <see cref="AddListenerCallbackInfoMenuIdsArrayItem" />.</summary>
        /// <param name="value">The value.</param>
        public AddListenerCallbackInfoMenuIdsArrayItem(string value) : base(value, typeof(string))
        {
            valueString = value;
        }

        /// <summary>Converts from <see cref="AddListenerCallbackInfoMenuIdsArrayItem" /> to <see cref="int" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator int(AddListenerCallbackInfoMenuIdsArrayItem value) => value.valueInt;

        /// <summary>Converts from <see cref="int" /> to <see cref="AddListenerCallbackInfoMenuIdsArrayItem" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator AddListenerCallbackInfoMenuIdsArrayItem(int value) => new(value);

        /// <summary>Converts from <see cref="AddListenerCallbackInfoMenuIdsArrayItem" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(AddListenerCallbackInfoMenuIdsArrayItem value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="AddListenerCallbackInfoMenuIdsArrayItem" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator AddListenerCallbackInfoMenuIdsArrayItem(string value) => new(value);
    }
}
