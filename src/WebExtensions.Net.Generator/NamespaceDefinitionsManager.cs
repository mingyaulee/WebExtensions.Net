using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WebExtensions.Net.Generator.Models;
using WebExtensions.Net.Generator.Models.Schema;
using WebExtensions.Net.Generator.NamespaceDefinitionsClients;

namespace WebExtensions.Net.Generator
{
    /// <summary>
    /// Implementation based on https://firefox-source-docs.mozilla.org/toolkit/components/extensions/webextensions/schema.html
    /// </summary>
    public class NamespaceDefinitionsManager
    {
        private readonly NamespaceDefinitionsClient namespaceDefinitionsClient;
        private readonly SourceOptions sourceOptions;
        private readonly ILogger logger;

        public NamespaceDefinitionsManager(NamespaceDefinitionsClient namespaceDefinitionsClient, SourceOptions sourceOptions, ILogger logger)
        {
            this.namespaceDefinitionsClient = namespaceDefinitionsClient;
            this.sourceOptions = sourceOptions;
            this.logger = logger;
        }

        public async Task<IEnumerable<NamespaceDefinition>> GetNamespaceDefinitions()
        {
            if (sourceOptions.UseLocalSources)
            {
                logger.LogInformation("Using local namespace definition sources.");
                return LocalNamespaceDefinitionsClient.GetNamespaceDefinitions(sourceOptions.LocalDirectory);
            }
            else
            {
                foreach (var additionalNamespaceSourceDefinition in sourceOptions.AdditionalNamespaceSourceDefinitions)
                {
                    if (additionalNamespaceSourceDefinition.HttpUrl is null)
                    {
                        throw new InvalidOperationException("Additional namespace source definition should have value for HttpUrl.");
                    }

                    additionalNamespaceSourceDefinition.Schema = Path.GetFileName(additionalNamespaceSourceDefinition.HttpUrl);
                }

                var namespaceDefinitions = await namespaceDefinitionsClient.GetNamespaceDefinitions(sourceOptions.Sources, sourceOptions.AdditionalNamespaceSourceDefinitions, sourceOptions.RunInParallel);
                LocalNamespaceDefinitionsClient.StoreNamespaceDefinitions(sourceOptions.LocalDirectory, namespaceDefinitions);
                return namespaceDefinitions;
            }
        }
    }
}
