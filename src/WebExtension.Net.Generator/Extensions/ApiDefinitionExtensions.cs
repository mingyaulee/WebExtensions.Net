using System;
using WebExtension.Net.Generator.Models;

namespace WebExtension.Net.Generator.Extensions
{
    public static class ApiDefinitionExtensions
    {
        public static string GetNamespace(this ApiDefinition apiDefinition)
        {
            if (string.IsNullOrEmpty(apiDefinition.RootNamespace))
            {
                throw new NotSupportedException("Base namespace cannot be null");
            }
            return $"{apiDefinition.RootNamespace}.{apiDefinition.GetName()}";
        }
    }
}
