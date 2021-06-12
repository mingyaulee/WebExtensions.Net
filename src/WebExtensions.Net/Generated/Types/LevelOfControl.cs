using System.Text.Json.Serialization;

namespace WebExtensions.Net.Types
{
    /// <summary>One of'ul''li'<c>not_controllable</c>: cannot be controlled by any extension'/li''li'<c>controlled_by_other_extensions</c>: controlled by extensions with higher precedence'/li''li'<c>controllable_by_this_extension</c>: can be controlled by this extension'/li''li'<c>controlled_by_this_extension</c>: controlled by this extension'/li''/ul'</summary>
    [JsonConverter(typeof(EnumStringConverter<LevelOfControl>))]
    public enum LevelOfControl
    {
        /// <summary>not_controllable</summary>
        [EnumValue("not_controllable")]
        NotControllable,

        /// <summary>controlled_by_other_extensions</summary>
        [EnumValue("controlled_by_other_extensions")]
        ControlledByOtherExtensions,

        /// <summary>controllable_by_this_extension</summary>
        [EnumValue("controllable_by_this_extension")]
        ControllableByThisExtension,

        /// <summary>controlled_by_this_extension</summary>
        [EnumValue("controlled_by_this_extension")]
        ControlledByThisExtension,
    }
}
