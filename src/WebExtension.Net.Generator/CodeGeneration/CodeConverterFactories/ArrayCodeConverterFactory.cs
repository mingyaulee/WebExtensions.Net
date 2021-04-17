using System;
using WebExtension.Net.Generator.CodeGeneration.CodeConverters;
using WebExtension.Net.Generator.Extensions;
using WebExtension.Net.Generator.Models.Entities;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverterFactories
{
    public class ArrayCodeConverterFactory : ICodeConverterFactory<ClassEntity>
    {
        public void AddInterfaceConvertersToCodeFile(ClassEntity entity, CodeFile codeFile)
        {
            throw new NotImplementedException();
        }

        public void AddConvertersToCodeFile(ClassEntity entity, CodeFile codeFile)
        {
            if (entity.TypeDefinition is null || entity.TypeDefinition.ArrayItems is null)
            {
                return;
            }

            codeFile.UsingNamespaces.Add("System.Collections.Generic");

            codeFile.Declaration = codeFile.Declaration.Replace("$arrayItemTypeName", entity.TypeDefinition.ArrayItems.ToTypeName(codeFile.UsingNamespaces));

            codeFile.Comments.Add(new CommentCodeConverter("Array Class"));
            codeFile.Comments.Add(new CommentSummaryCodeConverter(entity.Description));

            if (entity.TypeDefinition.IsDeprecated)
            {
                codeFile.Attributes.Add(new AttributeObsoleteCodeConverter(entity.TypeDefinition.Deprecated));
            }
        }
    }
}
