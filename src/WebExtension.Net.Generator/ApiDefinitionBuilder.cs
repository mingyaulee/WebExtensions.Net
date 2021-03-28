using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using WebExtension.Net.Generator.Models;
using WebExtension.Net.Generator.Parsers;

namespace WebExtension.Net.Generator
{
    public class ApiDefinitionBuilder
    {
        private readonly HttpClient httpClient;
        private readonly ILogger logger;
        private readonly ApiDefinitionParser apiDefinitionParser;

        public ApiDefinitionBuilder(HttpClient httpClient, ILogger logger)
        {
            this.httpClient = httpClient;
            this.logger = logger;
            apiDefinitionParser = new ApiDefinitionParser(logger);
        }

        public async Task<ApiDefinitionRoot?> BuildRootFromSourceAsync(IEnumerable<string> sourceUrls, bool runInParallel)
        {
            try
            {
                var apiRoot = await GetApiRootAsync(sourceUrls);
                if (runInParallel)
                {
                    Parallel.ForEach(apiRoot.DefinitionUrls, definitionUrl =>
                    {
                        logger.LogInformation($"Reading from URL {definitionUrl}");
                        var apiDefinition = BuildApiDefinitionFromUrl(definitionUrl).GetAwaiter().GetResult();
                        apiRoot.ApiDefinitions.AddRange(apiDefinition);
                        logger.LogInformation($"Reading complete for URL {definitionUrl}");
                    });
                }
                else
                {
                    foreach (var definitionUrl in apiRoot.DefinitionUrls)
                    {
                        logger.LogInformation($"Reading from URL {definitionUrl}");
                        var apiDefinition = await BuildApiDefinitionFromUrl(definitionUrl);
                        apiRoot.ApiDefinitions.AddRange(apiDefinition);
                        logger.LogInformation($"Reading complete for URL {definitionUrl}");
                    }
                }

                apiRoot.ApiDefinitions = MergeByNamespace(apiRoot.ApiDefinitions);

                return apiRoot;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occured when building API definitions");
                return null;
            }
        }

        private async Task<ApiDefinitionRoot> GetApiRootAsync(IEnumerable<string> sourceUrls)
        {
            var apiRoot = new ApiDefinitionRoot();
            foreach (var sourceUrl in sourceUrls)
            {
                var response = await httpClient.GetAsync(sourceUrl);
                var responseContent = await response.Content.ReadAsStringAsync();
                var urls = responseContent.Split(new[] { '\n', '\r' })
                    .Where(x => x.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                    .Select(x => sourceUrl + x[(x.LastIndexOf(" ") + 1)..]);
                apiRoot.DefinitionUrls.AddRange(urls);
            }
            return apiRoot;
        }

        private async Task<IEnumerable<ApiDefinition>> BuildApiDefinitionFromUrl(string url)
        {
            var jsonSerializerOptions = new JsonSerializerOptions()
            {
                ReadCommentHandling = JsonCommentHandling.Skip
            };
            var result = await httpClient.GetFromJsonAsync<JsonDocument>(url, jsonSerializerOptions);
            if (result != null)
            {
                var apiDefinitions = apiDefinitionParser.ParseApiDefinitions(result.RootElement).ToArray();
                foreach (var apiDefinition in apiDefinitions)
                {
                    apiDefinition.URL = url;
                }
                return apiDefinitions;
            }
            return Enumerable.Empty<ApiDefinition>();
        }

        private static List<ApiDefinition> MergeByNamespace(IEnumerable<ApiDefinition> apiDefinitions)
        {
            return apiDefinitions.GroupBy(apiDefinition => apiDefinition.Name).Select(apiDefinitionGroup =>
            {
                var apiDefinition = apiDefinitionGroup.First();
                foreach (var duplicateApiDefinition in apiDefinitionGroup.Skip(1))
                {
                    apiDefinition.URL = $"{apiDefinition.URL}|{duplicateApiDefinition.URL}";
                    apiDefinition.Json = apiDefinition.Json.Concat(duplicateApiDefinition.Json);
                    apiDefinition.Properties = apiDefinition.Properties.Concat(duplicateApiDefinition.Properties).OrderBy(propertyDefinition => propertyDefinition.Name);
                    apiDefinition.Functions = apiDefinition.Functions.Concat(duplicateApiDefinition.Functions).OrderBy(functionDefinition => functionDefinition.Name);
                    apiDefinition.Types = apiDefinition.Types.Concat(duplicateApiDefinition.Types);
                }
                if (apiDefinition.Types.OfType<ClassDefinition>().Any(classDefinition => !string.IsNullOrEmpty(classDefinition.ExtendsClass)))
                {
                    apiDefinition.Types = MergeTypes(apiDefinition.Types).ToArray();
                }
                return apiDefinition;
            }).OrderBy(apiDefinition => apiDefinition.Name).ToList();
        }

        private static IEnumerable<TypeDefinition> MergeTypes(IEnumerable<TypeDefinition> typeDefinitions)
        {
            var extendingClasses = typeDefinitions.OfType<ClassDefinition>().GroupBy(classDefinition => classDefinition.ExtendsClass).ToDictionary(classDefinitionGroup => classDefinitionGroup.Key ?? string.Empty, classDefinitionGroup => classDefinitionGroup.ToArray());
            foreach (var typeDefinition in typeDefinitions)
            {
                if (typeDefinition is ClassDefinition classDefinition)
                {
                    if (!string.IsNullOrEmpty(classDefinition.ExtendsClass))
                    {
                        continue;
                    }
                    if (classDefinition.Name != null && extendingClasses.ContainsKey(classDefinition.Name))
                    {
                        classDefinition.Functions = classDefinition.Functions.Concat(extendingClasses[classDefinition.Name].SelectMany(extendingClass => extendingClass.Functions)).OrderBy(functionDefinition => functionDefinition.Name);
                        classDefinition.Properties = classDefinition.Properties.Concat(extendingClasses[classDefinition.Name].SelectMany(extendingClass => extendingClass.Properties)).OrderBy(propertyDefinition => propertyDefinition.Name);
                    }
                }
                yield return typeDefinition;
            }
        }
    }
}
