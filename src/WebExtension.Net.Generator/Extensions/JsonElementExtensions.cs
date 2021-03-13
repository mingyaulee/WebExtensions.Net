using System.Text.Json;

namespace WebExtension.Net.Generator.Extensions
{
    public static class JsonElementExtensions
    {
        public static string? GetStringProperty(this JsonElement jsonElement, string property)
        {
            if (jsonElement.TryGetProperty(property, out var jsonValue))
            {
                return jsonValue.GetString();
            }
            return null;
        }

        public static bool GetBooleanProperty(this JsonElement jsonElement, string property)
        {
            if (jsonElement.TryGetProperty(property, out var jsonValue))
            {
                if (jsonValue.ValueKind == JsonValueKind.String)
                {
                    return bool.Parse(jsonValue.GetString() ?? "false");
                }
                return jsonValue.GetBoolean();
            }
            return false;
        }
    }
}
