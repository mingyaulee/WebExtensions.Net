using System.Collections.Generic;
using WebExtension.Net.Generator.CodeGeneration;
using WebExtension.Net.Generator.CodeGeneration.CodeConverters;
using WebExtension.Net.Generator.Models.Entities;
using WebExtension.Net.Generator.Repositories;
using WebExtension.Net.Generator.Translators;

namespace WebExtension.Net.Generator
{
    public class CodeGenerator
    {
        private readonly EntitiesContext entitiesContext;
        private readonly ClassEntityTranslator classEntityTranslator;
        private readonly EnumEntityTranslator enumEntityTranslator;
        private readonly List<CodeFileConverter> codeFiles;

        public CodeGenerator(EntitiesContext entitiesContext, ClassEntityTranslator classEntityTranslator, EnumEntityTranslator enumEntityTranslator)
        {
            this.entitiesContext = entitiesContext;
            this.classEntityTranslator = classEntityTranslator;
            this.enumEntityTranslator = enumEntityTranslator;
            codeFiles = new List<CodeFileConverter>();
        }

        public IEnumerable<CodeFileConverter> GetCodeFileConverters()
        {
            var classEntities = entitiesContext.Classes.GetAllClassEntities();
            foreach (var classEntity in classEntities)
            {
                codeFiles.AddRange(GetClassEntityCodeConverters(classEntity)) ;
            }
            var enumEntities = entitiesContext.Enums.GetAllEnumEntities();
            foreach (var enumEntity in enumEntities)
            {
                codeFiles.Add(GetEnumEntityCodeConverter(enumEntity)) ;
            }
            return codeFiles;
        }

        private IEnumerable<CodeFileConverter> GetClassEntityCodeConverters(ClassEntity classEntity)
        {
            if (classEntity.ImplementInterface)
            {
                yield return GetClassEntityInterfaceCodeConverter(classEntity);
            }
            yield return GetClassEntityCodeConverter(classEntity);
        }

        private CodeFileConverter GetClassEntityInterfaceCodeConverter(ClassEntity classEntity)
        {
            var relativeNamespace = classEntity.NamespaceEntity.FormattedName;
            var declaration = $"public interface I{classEntity.FormattedName}";
            var codeFile = new CodeFile($"I{classEntity.FormattedName}", relativeNamespace, declaration);
            classEntityTranslator.TranslateClassEntityToInterfaceCodeFile(classEntity, codeFile);
            return new CodeFileConverter(codeFile);
        }

        private CodeFileConverter GetClassEntityCodeConverter(ClassEntity classEntity)
        {
            var relativeNamespace = classEntity.NamespaceEntity.FormattedName;
            var declaration = $"public class {classEntity.FormattedName}";
            if (!string.IsNullOrEmpty(classEntity.BaseClassName))
            {
                declaration += $" : {classEntity.BaseClassName}" + (classEntity.ImplementInterface ? $", I{classEntity.FormattedName}" : string.Empty);
            }
            else if (classEntity.ImplementInterface)
            {
                declaration += $" : I{classEntity.FormattedName}";
            }
            var codeFile = new CodeFile(classEntity.FormattedName, relativeNamespace, declaration);
            classEntityTranslator.TranslateClassEntityToCodeFile(classEntity, codeFile);
            return new CodeFileConverter(codeFile);
        }

        private CodeFileConverter GetEnumEntityCodeConverter(EnumEntity enumEntity)
        {
            var relativeNamespace = enumEntity.NamespaceEntity.FormattedName;
            var declaration = $"public enum {enumEntity.FormattedName}";
            var codeFile = new CodeFile(enumEntity.FormattedName, relativeNamespace, declaration);
            enumEntityTranslator.TranslateEnumEntityToCodeFile(enumEntity, codeFile);
            return new CodeFileConverter(codeFile);
        }
    }
}
