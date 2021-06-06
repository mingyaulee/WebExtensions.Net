using System;
using System.Text.Json;

namespace WebExtension.Net.Generator.Helpers
{
    public static class SerializationHelper
    {
        public static T DeserializeTo<T>(object obj)
        {
            var serializedObject = JsonSerializer.Serialize(obj, JsonSerializerConstant.Options);
            var deserializedObject = JsonSerializer.Deserialize<T>(serializedObject, JsonSerializerConstant.Options);
            if (deserializedObject is null)
            {
                throw new InvalidCastException($"Failed to deserialize object '{serializedObject}' to type '{typeof(T).Name}'.");
            }
            return deserializedObject;
        }
    }
}
