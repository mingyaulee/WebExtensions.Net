using System.Text.Json.Serialization;

namespace WebExtensions.Net.Menus
{
    // Multitype Class
    /// <summary></summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<RemoveListenerCallbackInfoMenuIdsArrayItem>))]
    public partial class RemoveListenerCallbackInfoMenuIdsArrayItem : BaseMultiTypeObject
    {
        private readonly int valueInt;
        private readonly string valueString;

        /// <summary>Creates a new instance of <see cref="RemoveListenerCallbackInfoMenuIdsArrayItem" />.</summary>
        /// <param name="value">The value.</param>
        public RemoveListenerCallbackInfoMenuIdsArrayItem(int value) : base(value, typeof(int))
        {
            valueInt = value;
        }

        /// <summary>Creates a new instance of <see cref="RemoveListenerCallbackInfoMenuIdsArrayItem" />.</summary>
        /// <param name="value">The value.</param>
        public RemoveListenerCallbackInfoMenuIdsArrayItem(string value) : base(value, typeof(string))
        {
            valueString = value;
        }

        /// <summary>Converts from <see cref="RemoveListenerCallbackInfoMenuIdsArrayItem" /> to <see cref="int" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator int(RemoveListenerCallbackInfoMenuIdsArrayItem value) => value.valueInt;

        /// <summary>Converts from <see cref="int" /> to <see cref="RemoveListenerCallbackInfoMenuIdsArrayItem" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator RemoveListenerCallbackInfoMenuIdsArrayItem(int value) => new(value);

        /// <summary>Converts from <see cref="RemoveListenerCallbackInfoMenuIdsArrayItem" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(RemoveListenerCallbackInfoMenuIdsArrayItem value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="RemoveListenerCallbackInfoMenuIdsArrayItem" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator RemoveListenerCallbackInfoMenuIdsArrayItem(string value) => new(value);
    }
}
