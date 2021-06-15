using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using WebExtensions.Net.Generator.Models;
using WebExtensions.Net.Generator.Models.Entities;

namespace WebExtensions.Net.Generator.EntitiesRegistration
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
            if (registrationOptions.ExcludeNamespaces is not null && registrationOptions.ExcludeNamespaces.Contains(namespaceEntity.FullName))
            {
                logger.LogWarning($"Skipped namespace '{namespaceEntity.FullName}'.");
                return false;
            }

            if (registrationOptions.IncludeNamespaces is not null && !registrationOptions.IncludeNamespaces.Contains(namespaceEntity.FullName))
            {
                logger.LogError($"Namespace '{namespaceEntity.FullName}' is not recognized.");
                return false;
            }

            return true;
        }
    }
}
