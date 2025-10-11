using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebExtensions.Net.Generator.Models.Schema;

namespace WebExtensions.Net.Generator.NamespaceDefinitionsClients;

/// <summary>
/// Read or store namespace definitions locally.
/// </summary>
public static class LocalNamespaceDefinitionsClient
{
    private const string DefinitionSourcesFileName = "_sources.json";

    public static IEnumerable<NamespaceDefinition> GetNamespaceDefinitions(string path)
    {
        var namespaceDefinitions = new List<NamespaceDefinition>();
        var definitionSourceFilePath = Path.Combine(path, DefinitionSourcesFileName);
        var definitionSources = JsonSerializer.Deserialize<IEnumerable<NamespaceSourceDefinition>>(File.ReadAllText(definitionSourceFilePath));
        if (definitionSources is null)
        {
            throw new InvalidOperationException($"Order file {definitionSourceFilePath} is invalid.");
        }

        foreach (var definitionSource in definitionSources)
        {
            var namespaceDefinitionFileName = Path.GetFileName(definitionSource.Schema) ?? throw new InvalidOperationException("Namespace definition schema should not be null");
            var namespaceDefinitionFilePath = Path.Combine(path, namespaceDefinitionFileName);
            var namespaceDefinitionFileContent = File.ReadAllText(namespaceDefinitionFilePath);
            var fileNamespaceDefinitions = JsonSerializer.Deserialize<IEnumerable<NamespaceDefinition>>(namespaceDefinitionFileContent, JsonSerializerConstant.Options);
            if (fileNamespaceDefinitions is not null)
            {
                foreach (var namespaceDefinition in fileNamespaceDefinitions)
                {
                    namespaceDefinition.Source = definitionSource;
                    namespaceDefinitions.Add(namespaceDefinition);
                }
            }
        }

        return namespaceDefinitions;
    }

    public static void StoreNamespaceDefinitions(string path, IEnumerable<NamespaceDefinition> namespaceDefinitions)
    {
        var groupedNamespaceDefinitions = namespaceDefinitions.GroupBy(namespaceDefinition => namespaceDefinition.Source);
        var jsonSerializerOptions = new JsonSerializerOptions(JsonSerializerConstant.Options)
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        };
        var definitionSources = new List<NamespaceSourceDefinition>();
        foreach (var groupedNamespaceDefinition in groupedNamespaceDefinitions)
        {
            if (groupedNamespaceDefinition.Key is null)
            {
                throw new InvalidOperationException("Namespace definition source should be not be null.");
            }

            if (groupedNamespaceDefinition.Key.HttpUrl is null)
            {
                throw new InvalidOperationException("HttpUrl should be not be null.");
            }

            definitionSources.Add(groupedNamespaceDefinition.Key);
            var namespaceDefinitionFileName = Path.GetFileName(groupedNamespaceDefinition.Key.HttpUrl);
            var namespaceDefinitionFilePath = Path.Combine(path, namespaceDefinitionFileName);
            var namespaceDefinitionFileContent = JsonSerializer.Serialize(groupedNamespaceDefinition.ToArray(), jsonSerializerOptions);
            File.WriteAllText(namespaceDefinitionFilePath, namespaceDefinitionFileContent);
        }
        var definitionSourceFilePath = Path.Combine(path, DefinitionSourcesFileName);
        File.WriteAllText(definitionSourceFilePath, JsonSerializer.Serialize(definitionSources, jsonSerializerOptions));
    }
}
