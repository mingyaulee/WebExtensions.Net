using System.Text.Json.Serialization;

namespace WebExtensions.Net.Generator.Models.Schema
{
    [JsonConverter(typeof(EnumStringConverter<Scope>))]
    public enum Scope
    {
        [EnumValue("addon_parent")]
        AddonParent,
        [EnumValue("addon_child")]
        AddonChild,
        [EnumValue("content_parent")]
        ContentParent,
        [EnumValue("content_child")]
        ContentChild,
        [EnumValue("devtools_parent")]
        DevtoolsParent,
        [EnumValue("devtools_child")]
        DevtoolsChild,
    }
}
