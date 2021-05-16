using System;
using System.Linq;
using WebExtension.Net.Generator.Helpers;
using WebExtension.Net.Generator.Models.Entities;
using WebExtension.Net.Generator.Models.Schema;

namespace WebExtension.Net.Generator.EntitiesRegistration
{
    public class AnonymousTypeRegistrar
    {
        private readonly TypeEntityRegistrar typeEntityRegistrar;

        public AnonymousTypeRegistrar(TypeEntityRegistrar typeEntityRegistrar)
        {
            this.typeEntityRegistrar = typeEntityRegistrar;
        }

        public string RegisterType(AnonymousTypeEntityRegistrationInfo typeEntityRegistrationInfo)
        {
            var namespaceEntity = typeEntityRegistrationInfo.NamespaceEntity;
            var nameHierarchy = typeEntityRegistrationInfo.NameHierarchy.Reverse().ToList();
            var typeId = string.Empty;
            do
            {
                if (nameHierarchy.Count == 0)
                {
                    throw new InvalidOperationException("Unable to get a type name for type entity registration.");
                }
                typeId = nameHierarchy[0] + typeId;
                nameHierarchy.RemoveAt(0);

            } while (typeEntityRegistrar.HasTypeEntity(typeId, namespaceEntity));
            var typeDefinition = SerializationHelper.DeserializeTo<TypeDefinition>(typeEntityRegistrationInfo.TypeReference);
            typeDefinition.Id = typeId;

            typeEntityRegistrar.RegisterNamespaceType(typeDefinition, namespaceEntity);

            return typeId;
        }
    }
}
