using System.Text.Json.Serialization;

namespace WebExtensions.Net.Menus
{
    /// <summary>The type of menu item.</summary>
    [JsonConverter(typeof(EnumStringConverter<ItemType>))]
    public enum ItemType
    {
        /// <summary>normal</summary>
        [EnumValue("normal")]
        Normal,

        /// <summary>checkbox</summary>
        [EnumValue("checkbox")]
        Checkbox,

        /// <summary>radio</summary>
        [EnumValue("radio")]
        Radio,

        /// <summary>separator</summary>
        [EnumValue("separator")]
        Separator,
    }
}
