using System.Collections.Generic;
using WebExtensions.Net.Generator.Models.ClrTypes;
using WebExtensions.Net.Generator.Models.Entities;
using WebExtensions.Net.Generator.ClrTypeTranslators;

namespace WebExtensions.Net.Generator;

public class ClrTypeManager(ClrTypeStore clrTypeStore, ClassEntityTranslator classEntityTranslator)
{
    private readonly ClrTypeStore clrTypeStore = clrTypeStore;
    private readonly ClassEntityTranslator classEntityTranslator = classEntityTranslator;

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
