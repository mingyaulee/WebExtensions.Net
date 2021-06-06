using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebExtensions.Net
{
    /// <summary>
    /// JSON converter for String Format class object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StringFormatJsonConverter<T> : JsonConverter<T>
        where T : BaseStringFormat
    {
        /// <inheritdoc/>
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var stringValue = reader.GetString();
            if (stringValue is null)
            {
                return null;
            }

            var constructor = typeToConvert.GetConstructor(new[] { typeof(string) });
            if (constructor is null)
            {
                throw new InvalidOperationException($"Unable to get constructor which accepts string for String Format class type '{typeToConvert.FullName}'.");
            }

            return (T)constructor.Invoke(new[] { stringValue });
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value?.Value, options);
        }
    }
}
