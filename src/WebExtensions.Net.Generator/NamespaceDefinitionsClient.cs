using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebExtensions.Net.Generator.Models;
using WebExtensions.Net.Generator.Models.Schema;

namespace WebExtensions.Net.Generator
{
    /// <summary>
    /// Implementation based on https://firefox-source-docs.mozilla.org/toolkit/components/extensions/webextensions/schema.html
    /// </summary>
    public class NamespaceDefinitionsClient : IDisposable
    {
        private readonly ILogger logger;
        private readonly HttpClient httpClient;

        public NamespaceDefinitionsClient(ILogger logger)
        {
            this.logger = logger;
            httpClient = new HttpClient();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            ((IDisposable)httpClient).Dispose();
        }

        public async Task<IEnumerable<NamespaceDefinition>> GetNamespaceDefinitions(IEnumerable<ApiDefinitionSource> sources, IEnumerable<NamespaceSourceDefinition> additionalNamespaceSourceDefinitions, bool runInParallel)
        {
            var namespaceDefinitions = new List<NamespaceDefinition>();
            var namespaceSourceDefinitions = await GetNamespaceSourceDefinitions(sources);
            namespaceSourceDefinitions.AddRange(additionalNamespaceSourceDefinitions);
            if (runInParallel)
            {
                var unorderedNamespaceDefinitions = new ConcurrentDictionary<long, IEnumerable<NamespaceDefinition>>();
                Parallel.ForEach(namespaceSourceDefinitions, (namespaceSourceDefinition, _, i) =>
                {
                    unorderedNamespaceDefinitions[i] = GetNamespaceDefinition(namespaceSourceDefinition).GetAwaiter().GetResult();
                });
                namespaceDefinitions.AddRange(unorderedNamespaceDefinitions.OrderBy(item => item.Key).SelectMany(item => item.Value));
            }
            else
            {
                foreach (var namespaceSourceDefinition in namespaceSourceDefinitions)
                {
                    namespaceDefinitions.AddRange(await GetNamespaceDefinition(namespaceSourceDefinition));
                }
            }
            return namespaceDefinitions;
        }

        private async Task<IEnumerable<NamespaceDefinition>> GetNamespaceDefinition(NamespaceSourceDefinition namespaceSourceDefinition)
        {
            logger.LogInformation($"Reading from URL {namespaceSourceDefinition.HttpUrl}");

            IEnumerable<NamespaceDefinition>? namespaceDefinitionsResponse;
            try
            {
                namespaceDefinitionsResponse = await GetFromHttpWithRetry<IEnumerable<NamespaceDefinition>>(namespaceSourceDefinition.HttpUrl);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to get response from url '{namespaceSourceDefinition.HttpUrl}'", ex);
            }
            if (namespaceDefinitionsResponse is null)
            {
                throw new InvalidOperationException($"Failed to deserialize response from url '{namespaceSourceDefinition.HttpUrl}'");
            }
            foreach (var namespaceDefinition in namespaceDefinitionsResponse)
            {
                namespaceDefinition.Source = namespaceSourceDefinition;
            }

            logger.LogInformation($"Reading complete for URL {namespaceSourceDefinition.HttpUrl}");
            return namespaceDefinitionsResponse;
        }

        private async Task<List<NamespaceSourceDefinition>> GetNamespaceSourceDefinitions(IEnumerable<ApiDefinitionSource> sources)
        {
            var namespaceSourceDefinitions = new List<NamespaceSourceDefinition>();
            foreach (var source in sources)
            {
                var namespaceSourceDefinitionDictionary = await GetFromHttpWithRetry<IDictionary<string, NamespaceSourceDefinition>>(source.BaseUrl + source.FileName);
                if (namespaceSourceDefinitionDictionary is null)
                {
                    logger.LogError($"Failed to retrieve namespace source definitions from source url. Source url: '{source}'");
                    continue;
                }

                foreach (var item in namespaceSourceDefinitionDictionary)
                {
                    var namespaceSourceDefinition = item.Value;
                    namespaceSourceDefinition.Namespace = item.Key;

                    if (namespaceSourceDefinition.Schema is null)
                    {
                        logger.LogWarning($"Skipping source definition: Namespace definition schema url is null. Key: '{item.Key}'");
                        continue;
                    }
                    var namespaceSource = sources.Single(s => namespaceSourceDefinition.Schema.StartsWith(s.SchemaBaseUrl));
                    namespaceSourceDefinition.HttpUrl = namespaceSource.BaseUrl + namespaceSourceDefinition.Schema[namespaceSource.SchemaBaseUrl.Length..];

                    namespaceSourceDefinitions.Add(namespaceSourceDefinition);
                }
            }
            return namespaceSourceDefinitions;
        }

        private async Task<T?> GetFromHttpWithRetry<T>(string? url)
        {
            var attempt = 5;
            while (attempt > 0)
            {
                try
                {
                    return await httpClient.GetFromJsonAsync<T>(url, JsonSerializerConstant.Options);
                }
                catch (HttpRequestException)
                {
                    attempt--;
                    if (attempt == 0)
                    {
                        throw;
                    }
                }
            }
            throw new TimeoutException();
        }
    }
}
