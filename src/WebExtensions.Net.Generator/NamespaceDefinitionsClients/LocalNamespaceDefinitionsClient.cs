using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebExtensions.Net.Generator.Models.Schema;

namespace WebExtensions.Net.Generator.NamespaceDefinitionsClients
{
    /// <summary>
    /// Read or store namespace definitions locally.
    /// </summary>
    public static class LocalNamespaceDefinitionsClient
    {
        private const string FileOrderName = "_order.json";

        public static IEnumerable<NamespaceDefinition> GetNamespaceDefinitions(string path)
        {
            var namespaceDefinitions = new List<NamespaceDefinition>();
            var fileOrderFilePath = Path.Combine(path, FileOrderName);
            var fileOrder = JsonSerializer.Deserialize<IEnumerable<string>>(File.ReadAllText(fileOrderFilePath));
            if (fileOrder is null)
            {
                throw new InvalidOperationException($"Order file {fileOrderFilePath} is invalid.");
            }

            foreach (var namespaceDefinitionFileName in fileOrder)
            {
                var namespaceDefinitionFilePath = Path.Combine(path, namespaceDefinitionFileName);
                var namespaceDefinitionFileContent = File.ReadAllText(namespaceDefinitionFilePath);
                var fileNamespaceDefinitions = JsonSerializer.Deserialize<IEnumerable<NamespaceDefinition>>(namespaceDefinitionFileContent, JsonSerializerConstant.Options);
                if (fileNamespaceDefinitions is not null)
                {
                    namespaceDefinitions.AddRange(fileNamespaceDefinitions);
                }
            }

            return namespaceDefinitions;
        }

        public static void StoreNamespaceDefinitions(string path, IEnumerable<NamespaceDefinition> namespaceDefinitions)
        {
            var groupedNamespaceDefinitions = namespaceDefinitions.GroupBy(namespaceDefinition => namespaceDefinition.Source?.HttpUrl);
            var jsonSerializerOptions = new JsonSerializerOptions(JsonSerializerConstant.Options)
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
            };
            var fileOrder = new List<string>();
            foreach (var groupedNamespaceDefinition in groupedNamespaceDefinitions)
            {
                if (groupedNamespaceDefinition.Key is null)
                {
                    throw new InvalidOperationException("HttpUrl should be not be null.");
                }
                var namespaceDefinitionFileName = Path.GetFileName(groupedNamespaceDefinition.Key);
                var namespaceDefinitionFilePath = Path.Combine(path, namespaceDefinitionFileName);
                var namespaceDefinitionFileContent = JsonSerializer.Serialize(groupedNamespaceDefinition.ToArray(), jsonSerializerOptions);
                File.WriteAllText(namespaceDefinitionFilePath, namespaceDefinitionFileContent);
                fileOrder.Add(namespaceDefinitionFileName);
            }
            var fileOrderFilePath = Path.Combine(path, FileOrderName);
            File.WriteAllText(fileOrderFilePath, JsonSerializer.Serialize(fileOrder, jsonSerializerOptions));
        }
    }
}
