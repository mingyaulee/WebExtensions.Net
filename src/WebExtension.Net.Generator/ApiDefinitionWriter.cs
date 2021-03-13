using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebExtension.Net.Generator.Extensions;
using WebExtension.Net.Generator.Models;
using WebExtension.Net.Generator.Translators;

namespace WebExtension.Net.Generator
{
    public class ApiDefinitionWriter
    {
        private readonly ILogger logger;
        private readonly List<string> includeNamespaces;
        private readonly List<string> excludeNamespaces;
        private readonly ApiDefinitionTranslator translator;
        private readonly string header;
        private readonly JsonSerializerOptions jsonSerializerOptions;

        public ApiDefinitionWriter(ILogger logger, List<string> includeNamespaces, List<string> excludeNamespaces)
        {
            this.logger = logger;
            this.includeNamespaces = includeNamespaces;
            this.excludeNamespaces = excludeNamespaces;
            translator = new ApiDefinitionTranslator(logger);
            header = $"/// This file is auto generated at {DateTime.UtcNow:s}{Environment.NewLine}{Environment.NewLine}";
            jsonSerializerOptions = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
        }

        public async Task Write(ApiDefinitionRoot apiDefinitionRoot)
        {
            if (apiDefinitionRoot.Directory is null)
            {
                return;
            }

            var apiDefinitions = new List<ApiDefinition>();
            try
            {
                foreach (var directory in Directory.GetDirectories(apiDefinitionRoot.Directory))
                {
                    if (File.Exists(Path.Combine(directory, "generated.txt")))
                    {
                        logger.LogWarning($"Cleaning directory {directory}");
                        Directory.Delete(directory, true);
                    }
                }

                foreach (var apiDefinition in apiDefinitionRoot.ApiDefinitions)
                {
                    if (apiDefinition.Name is null)
                    {
                        throw new Exception("ApiDefinition name should not be null");
                    }

                    if (excludeNamespaces.Contains(apiDefinition.Name))
                    {
                        logger.LogWarning($"Skipped ApiDefinition {apiDefinition.Name}");
                        continue;
                    }

                    if (!includeNamespaces.Contains(apiDefinition.Name))
                    {
                        logger.LogError($"ApiDefinition {apiDefinition.Name} is not recognized");
                        continue;
                    }

                    try
                    {
                        logger.LogInformation($"ApiDefinition {apiDefinition.Name}");

                        var apiDefinitionName = apiDefinition.GetName();
                        apiDefinition.Directory = Path.Combine(apiDefinitionRoot.Directory, apiDefinitionName);
                        apiDefinition.RootNamespace = apiDefinitionRoot.RootNamespace;

                        if (!Directory.Exists(apiDefinition.Directory))
                        {
                            Directory.CreateDirectory(apiDefinition.Directory);
                            await File.WriteAllTextAsync(apiDefinition.GetFilePath("generated.txt"), string.Empty);
                        }
                        await WriteFile(apiDefinition, $"{apiDefinitionName}.json", JsonSerializer.Serialize(apiDefinition.Json, jsonSerializerOptions));

                        if (apiDefinition.Types.Any())
                        {
                            await WriteTypes(apiDefinition);
                        }

                        if (apiDefinition.Functions.Any())
                        {
                            var apiDefinitionContent = translator.TranslateApiDefinition(apiDefinition, $"{apiDefinitionName}API");
                            await WriteFile(apiDefinition, $"{apiDefinitionName}API.cs", apiDefinitionContent);
                            var iApiDefinitionContent = translator.TranslateApiDefinitionInterface(apiDefinition, $"{apiDefinitionName}API");
                            await WriteFile(apiDefinition, $"I{apiDefinitionName}API.cs", iApiDefinitionContent);
                            apiDefinitions.Add(apiDefinition);
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, $"An error occured when writing API definition {apiDefinition.Name}");
                    }
                }

                var webExtensionContent = translator.TranslateApiDefinitionRoot(apiDefinitionRoot, apiDefinitions, "WebExtensionAPI", "API");
                await WriteFile(apiDefinitionRoot, "WebExtensionAPI.cs", webExtensionContent);
                var iWebExtensionContent = translator.TranslateApiDefinitionRootInterface(apiDefinitionRoot, apiDefinitions, "WebExtensionAPI", "API");
                await WriteFile(apiDefinitionRoot, "IWebExtensionAPI.cs", iWebExtensionContent);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"An error occured when writing API definitions");
                throw;
            }
        }

        private async Task WriteTypes(ApiDefinition apiDefinition)
        {
            foreach (var typeDefinition in apiDefinition.Types)
            {
                if (string.IsNullOrEmpty(typeDefinition.Name))
                {
                    logger.LogError($"Name is not available for type definition in {apiDefinition.GetName()} namespace.");
                    continue;
                }
                var typeContent = translator.TranslateTypeDefinition(apiDefinition, typeDefinition);
                await WriteFile(apiDefinition, $"{typeDefinition.GetName()}.cs", typeContent);
            }
        }

        private async Task WriteFile(IDirectoryNode directoryNode, string path, string? text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            var filePath = directoryNode.GetFilePath(path);
            await File.WriteAllTextAsync(filePath, header + text);
        }
    }
}
