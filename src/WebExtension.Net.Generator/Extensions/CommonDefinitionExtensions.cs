using System;
using WebExtension.Net.Generator.Models;
using System.Text.Json;

namespace WebExtension.Net.Generator.Extensions
{
    public static class CommonDefinitionExtensions
    {
        public static string GetName(this ICommonDefinition commonDefinition)
        {
            if (commonDefinition is TypeReference typeReference)
            {
                if (string.IsNullOrEmpty(commonDefinition.Name))
                {
                    throw new Exception($"Type reference has to be translated before calling GetName()");
                }
            }
            if (string.IsNullOrEmpty(commonDefinition.Name))
            {
                throw new Exception("Name cannot be null " + JsonSerializer.Serialize((object)commonDefinition));
            }
            if (commonDefinition.Name.Length > 1)
            {
                return commonDefinition.Name[0].ToString().ToUpperInvariant() + commonDefinition.Name.Substring(1);
            }
            return commonDefinition.Name.ToUpperInvariant();
        }
    }
}
