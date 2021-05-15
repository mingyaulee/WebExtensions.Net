using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using WebExtension.Net.Generator.Models;
using WebExtension.Net.Generator.Models.Entities;

namespace WebExtension.Net.Generator.EntitiesRegistration
{
    public class NamespaceRegistrationFilter
    {
        private readonly ILogger logger;
        private readonly RegistrationOptions registrationOptions;

        public NamespaceRegistrationFilter(ILogger logger, RegistrationOptions registrationOptions)
        {
            this.logger = logger;
            this.registrationOptions = registrationOptions;
        }

        public bool ShouldProcess(NamespaceEntity namespaceEntity)
        {
            if (registrationOptions.ExcludeNamespaces.Contains(namespaceEntity.Name))
            {
                logger.LogWarning($"Skipped namespace '{namespaceEntity.Name}'.");
                return false;
            }

            if (!registrationOptions.IncludeNamespaces.Contains(namespaceEntity.Name))
            {
                logger.LogError($"Namespace '{namespaceEntity.Name}' is not recognized.");
                return false;
            }

            return true;
        }
    }
}
