using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebExtensions.Net.Generator.Models;
using WebExtensions.Net.Generator.Models.Schema;

namespace WebExtensions.Net.Generator.NamespaceDefinitionsClients
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
            logger.LogInformation("Reading from URL {HttpUrl}", namespaceSourceDefinition.HttpUrl);

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

            logger.LogInformation("Reading complete for URL {HttpUrl}", namespaceSourceDefinition.HttpUrl);
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
                    logger.LogError("Failed to retrieve namespace source definitions from source url. Source url: '{Source}'", source);
                    continue;
                }

                foreach (var item in namespaceSourceDefinitionDictionary)
                {
                    var namespaceSourceDefinition = item.Value;
                    namespaceSourceDefinition.Namespace = item.Key;

                    if (namespaceSourceDefinition.Schema is null)
                    {
                        logger.LogWarning("Skipping source definition: Namespace definition schema url is null. Key: '{Key}'", item.Key);
                        continue;
                    }
                    var namespaceSource = sources.Single(s => namespaceSourceDefinition.Schema.StartsWith(s.SchemaBaseUrl));
                    namespaceSourceDefinition.HttpUrl = namespaceSource.BaseUrl + namespaceSourceDefinition.Schema[namespaceSource.SchemaBaseUrl.Length..];

                    namespaceSourceDefinitions.Add(namespaceSourceDefinition);
                }
            }
            return namespaceSourceDefinitions;
        }

        static readonly Random random = new();
        private async Task<T?> GetFromHttpWithRetry<T>(string? url)
        {
            var attempt = 0;
            while (attempt < 100)
            {
                try
                {
                    return await httpClient.GetFromJsonAsync<T>(url, JsonSerializerConstant.Options);
                }
                catch (HttpRequestException exception)
                {
                    attempt++;
                    if (exception.StatusCode == HttpStatusCode.TooManyRequests)
                    {
                        await Task.Delay(random.Next(1, attempt) * 1000);
                    }
                    else if (attempt >= 5)
                    {
                        throw;
                    }
                }
            }
            throw new TimeoutException();
        }
    }
}
