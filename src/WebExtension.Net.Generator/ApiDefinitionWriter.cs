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
        private readonly JsonSerializerOptions jsonSerializerOptions;

        public ApiDefinitionWriter(ILogger logger, List<string> includeNamespaces, List<string> excludeNamespaces)
        {
            this.logger = logger;
            this.includeNamespaces = includeNamespaces;
            this.excludeNamespaces = excludeNamespaces;
            translator = new ApiDefinitionTranslator(logger);
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
                        throw new NotSupportedException("ApiDefinition name should not be null");
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
                            await File.WriteAllTextAsync(apiDefinition.GetFilePath("generated.txt"), $"This file is auto generated at {DateTime.UtcNow:s}");
                        }
                        await WriteFile(apiDefinition, $"{apiDefinitionName}.json", JsonSerializer.Serialize(apiDefinition.Json, jsonSerializerOptions));

                        if (apiDefinition.Types.Any())
                        {
                            await WriteTypes(apiDefinition);
                        }

                        if (apiDefinition.Properties.Any() || apiDefinition.Functions.Any())
                        {
                            var apiDefinitionNamePostfix = apiDefinitionRoot.DefinitionClassNamePostfix;
                            var apiDefinitionContent = translator.TranslateApiDefinition(apiDefinition, $"{apiDefinitionName}{apiDefinitionNamePostfix}", apiDefinitionRoot.DefinitionBaseClassName);
                            await WriteFile(apiDefinition, $"{apiDefinitionName}{apiDefinitionNamePostfix}.cs", apiDefinitionContent);
                            var iApiDefinitionContent = translator.TranslateApiDefinitionInterface(apiDefinition, $"{apiDefinitionName}{apiDefinitionNamePostfix}");
                            await WriteFile(apiDefinition, $"I{apiDefinitionName}{apiDefinitionNamePostfix}.cs", iApiDefinitionContent);
                            apiDefinitions.Add(apiDefinition);
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, $"An error occured when writing API definition {apiDefinition.Name}");
                    }
                }

                var webExtensionContent = ApiDefinitionTranslator.TranslateApiDefinitionRoot(apiDefinitionRoot, apiDefinitions);
                await WriteFile(apiDefinitionRoot, $"{apiDefinitionRoot.Name}.cs", webExtensionContent);
                var iWebExtensionContent = ApiDefinitionTranslator.TranslateApiDefinitionRootInterface(apiDefinitionRoot, apiDefinitions);
                await WriteFile(apiDefinitionRoot, $"I{apiDefinitionRoot.Name}.cs", iWebExtensionContent);
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

        private static async Task WriteFile(IDirectoryNode directoryNode, string path, string? text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            var filePath = directoryNode.GetFilePath(path);
            await File.WriteAllTextAsync(filePath, text);
        }
    }
}
