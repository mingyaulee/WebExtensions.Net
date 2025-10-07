using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    public class NamespaceDefinitionsManager(NamespaceDefinitionsClient namespaceDefinitionsClient, SourceOptions sourceOptions, ILogger logger)
    {
        private readonly NamespaceDefinitionsClient namespaceDefinitionsClient = namespaceDefinitionsClient;
        private readonly SourceOptions sourceOptions = sourceOptions;
        private readonly ILogger logger = logger;

        public async Task<IEnumerable<NamespaceDefinition>> GetNamespaceDefinitions()
        {
            IEnumerable<NamespaceDefinition> namespaceDefinitions;
            if (sourceOptions.UseLocalSources)
            {
                logger.LogInformation("Using local namespace definition sources.");
                namespaceDefinitions = LocalNamespaceDefinitionsClient.GetNamespaceDefinitions(sourceOptions.LocalDirectory);
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

                namespaceDefinitions = await namespaceDefinitionsClient.GetNamespaceDefinitions(sourceOptions.Sources, sourceOptions.AdditionalNamespaceSourceDefinitions, sourceOptions.RunInParallel);

                LocalNamespaceDefinitionsClient.StoreNamespaceDefinitions(sourceOptions.LocalDirectory, namespaceDefinitions);
            }

            if (Directory.Exists(sourceOptions.AdditionalLocalDefinitions))
            {
                var additionalLocalDefinitions = LocalNamespaceDefinitionsClient.GetNamespaceDefinitions(sourceOptions.AdditionalLocalDefinitions);
                return namespaceDefinitions.Concat(additionalLocalDefinitions);
            }

            return namespaceDefinitions;
        }
    }
}
