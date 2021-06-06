using System.Collections.Generic;
using System.Linq;
using WebExtensions.Net.Generator.Models.Entities;
using WebExtensions.Net.Generator.Models.Schema;

namespace WebExtensions.Net.Generator.EntitiesRegistration
{
    public class TypeUsageProcessor
    {
        private readonly TypeEntityRegistrar typeEntityRegistrar;

        public TypeUsageProcessor(TypeEntityRegistrar typeEntityRegistrar)
        {
            this.typeEntityRegistrar = typeEntityRegistrar;
        }

        public void MarkTypeUsage(IEnumerable<TypeReference>? typeReferences, NamespaceEntity namespaceEntity)
        {
            if (typeReferences is null)
            {
                return;
            }

            foreach (var typeReference in typeReferences)
            {
                MarkTypeUsage(typeReference, namespaceEntity);
            }
        }

        private void MarkTypeUsage(TypeReference? typeReference, NamespaceEntity namespaceEntity)
        {
            if (typeReference is null || typeReference.IsUnsupported)
            {
                return;
            }

            if (typeReference.Ref is not null)
            {
                var typeEntity = typeEntityRegistrar.GetTypeEntity(typeReference.Ref, namespaceEntity);
                if (typeEntity.IsReferenced)
                {
                    return;
                }
                typeEntity.IsReferenced = true;
                MarkTypeUsage(typeEntity.Definition, typeEntity.NamespaceEntity);
            }

            MarkTypeUsage(typeReference.ArrayItems, namespaceEntity);
            MarkTypeUsage(typeReference.FunctionParameters, namespaceEntity);
            MarkTypeUsage(typeReference.FunctionReturns, namespaceEntity);
            MarkTypeUsage(typeReference.ObjectFunctions, namespaceEntity);
            MarkTypeUsage(typeReference.ObjectProperties?.Select(property => property.Value), namespaceEntity);
            MarkTypeUsage(typeReference.TypeChoices, namespaceEntity);
        }
    }
}
