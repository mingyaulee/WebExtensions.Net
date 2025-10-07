using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using WebExtensions.Net.Generator.Models;
using WebExtensions.Net.Generator.Models.Entities;

namespace WebExtensions.Net.Generator.EntitiesRegistration
{
    public class NamespaceRegistrationFilter(ILogger logger, RegistrationOptions registrationOptions)
    {
        private readonly ILogger logger = logger;
        private readonly RegistrationOptions registrationOptions = registrationOptions;

        public bool ShouldProcess(NamespaceEntity namespaceEntity)
        {
            if (registrationOptions.ExcludeNamespaces is not null && registrationOptions.ExcludeNamespaces.Contains(namespaceEntity.FullName))
            {
                logger.LogWarning("Skipped namespace '{FullName}'.", namespaceEntity.FullName);
                return false;
            }

            if (registrationOptions.IncludeNamespaces is not null && !registrationOptions.IncludeNamespaces.Contains(namespaceEntity.FullName))
            {
                logger.LogError("Namespace '{FullName}' is not recognized.", namespaceEntity.FullName);
                return false;
            }

            return true;
        }
    }
}
