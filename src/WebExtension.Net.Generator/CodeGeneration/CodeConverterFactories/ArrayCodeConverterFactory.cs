using System;
using WebExtension.Net.Generator.CodeGeneration.CodeConverters;
using WebExtension.Net.Generator.Extensions;
using WebExtension.Net.Generator.Models.Entities;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverterFactories
{
    public class ArrayCodeConverterFactory : ICodeConverterFactory<ClassEntity>
    {
        public void AddInterfaceConvertersToCodeFile(ClassEntity classEntity, CodeFile codeFile)
        {
            throw new NotImplementedException();
        }

        public void AddConvertersToCodeFile(ClassEntity classEntity, CodeFile codeFile)
        {
            if (classEntity.TypeDefinition is null || classEntity.TypeDefinition.ArrayItems is null)
            {
                return;
            }

            codeFile.UsingNamespaces.Add("System.Collections.Generic");

            codeFile.Declaration = codeFile.Declaration.Replace("$arrayItemTypeName", classEntity.TypeDefinition.ArrayItems.ToTypeName(codeFile.UsingNamespaces));

            codeFile.Comments.Add(new CommentCodeConverter("Array Class"));
            codeFile.Comments.Add(new CommentSummaryCodeConverter(classEntity.Description));

            if (classEntity.TypeDefinition.IsDeprecated)
            {
                codeFile.Attributes.Add(new AttributeObsoleteCodeConverter(classEntity.TypeDefinition.Deprecated));
            }
        }
    }
}
