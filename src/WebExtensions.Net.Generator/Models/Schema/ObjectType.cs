using System.Text.Json.Serialization;

namespace WebExtensions.Net.Generator.Models.Schema
{
    [JsonConverter(typeof(EnumStringConverter<ObjectType>))]
    public enum ObjectType
    {
        [EnumValue("null")]
        Null,
        [EnumValue("any")]
        Any,
        [EnumValue("boolean")]
        Boolean,
        [EnumValue("integer")]
        Integer,
        [EnumValue("number")]
        Number,
        [EnumValue("string")]
        String,
        [EnumValue("array")]
        Array,
        [EnumValue("object")]
        Object,
        [EnumValue("function")]
        Function,
        [EnumValue("ApiObject")]
        ApiObject,
        [EnumValue("EventTypeObject")]
        EventTypeObject,
        [EnumValue("CombinedCallbackParameterObject")]
        CombinedCallbackParameterObject
    }
}
