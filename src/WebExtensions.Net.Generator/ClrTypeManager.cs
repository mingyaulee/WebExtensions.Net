using System.Collections.Generic;
using WebExtension.Net.Generator.Models.ClrTypes;
using WebExtension.Net.Generator.Models.Entities;
using WebExtension.Net.Generator.ClrTypeTranslators;

namespace WebExtension.Net.Generator
{
    public class ClrTypeManager
    {
        private readonly ClrTypeStore clrTypeStore;
        private readonly ClassEntityTranslator classEntityTranslator;

        public ClrTypeManager(ClrTypeStore clrTypeStore, ClassEntityTranslator classEntityTranslator)
        {
            this.clrTypeStore = clrTypeStore;
            this.classEntityTranslator = classEntityTranslator;
        }

        public IEnumerable<ClrTypeInfo> TranslateToClrType(IEnumerable<ClassEntity> classEntities)
        {
            clrTypeStore.Reset();

            var intermediateClrTypes = new List<(ClassEntity ClassEntity, ClrTypeInfo ClrTypeInfo)>();
            foreach (var classEntity in classEntities)
            {
                var translatedClrTypes = classEntityTranslator.ShallowTranslate(classEntity);
                foreach (var translatedClrType in translatedClrTypes)
                {
                    intermediateClrTypes.Add((classEntity, translatedClrType));
                }
            }

            var clrTypes = new List<ClrTypeInfo>();
            foreach (var intermediateClrType in intermediateClrTypes)
            {
                classEntityTranslator.DeepTranslate(intermediateClrType.ClassEntity, intermediateClrType.ClrTypeInfo);
                clrTypes.Add(intermediateClrType.ClrTypeInfo);
            }

            return clrTypes;
        }
    }
}
