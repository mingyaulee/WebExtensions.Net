using System;
using WebExtension.Net.Generator.CodeGeneration;
using WebExtension.Net.Generator.CodeGeneration.CodeConverterFactories;
using WebExtension.Net.Generator.Models.Entities;

namespace WebExtension.Net.Generator.Translators
{
    public class ClassEntityTranslator
    {
        private readonly ApiRootCodeConverterFactory apiRootCodeConverterFactory;
        private readonly ApiCodeConverterFactory apiCodeConverterFactory;
        private readonly TypeCodeConverterFactory typeCodeConverterFactory;
        private readonly StringFormatCodeConverterFactory stringFormatCodeConverterFactory;
        private readonly ArrayCodeConverterFactory arrayCodeConverterFactory;
        private readonly MultitypeCodeConverterFactory multitypeCodeConverterFactory;

        public ClassEntityTranslator(
            ApiRootCodeConverterFactory apiRootCodeConverterFactory,
            ApiCodeConverterFactory apiCodeConverterFactory,
            TypeCodeConverterFactory typeCodeConverterFactory,
            StringFormatCodeConverterFactory stringFormatCodeConverterFactory,
            ArrayCodeConverterFactory arrayCodeConverterFactory,
            MultitypeCodeConverterFactory multitypeCodeConverterFactory)
        {
            this.apiRootCodeConverterFactory = apiRootCodeConverterFactory;
            this.apiCodeConverterFactory = apiCodeConverterFactory;
            this.typeCodeConverterFactory = typeCodeConverterFactory;
            this.stringFormatCodeConverterFactory = stringFormatCodeConverterFactory;
            this.arrayCodeConverterFactory = arrayCodeConverterFactory;
            this.multitypeCodeConverterFactory = multitypeCodeConverterFactory;
        }

        public void TranslateClassEntityToInterfaceCodeFile(ClassEntity classEntity, CodeFile codeFile)
        {
            foreach (var relativeNamespace in classEntity.UsingRelativeNamespaces)
            {
                codeFile.UsingRelativeNamespaces.Add(relativeNamespace);
            }
            GetFactory(classEntity).AddInterfaceConvertersToCodeFile(classEntity, codeFile);
        }

        public void TranslateClassEntityToCodeFile(ClassEntity classEntity, CodeFile codeFile)
        {
            foreach (var relativeNamespace in classEntity.UsingRelativeNamespaces)
            {
                codeFile.UsingRelativeNamespaces.Add(relativeNamespace);
            }
            GetFactory(classEntity).AddConvertersToCodeFile(classEntity, codeFile);
        }

        private ICodeConverterFactory<ClassEntity> GetFactory(ClassEntity classEntity)
        {
            return classEntity.Type switch
            {
                ClassEntityType.ApiRootClass => apiRootCodeConverterFactory,
                ClassEntityType.ApiClass => apiCodeConverterFactory,
                ClassEntityType.TypeClass => typeCodeConverterFactory,
                ClassEntityType.StringFormatClass => stringFormatCodeConverterFactory,
                ClassEntityType.ArrayClass => arrayCodeConverterFactory,
                ClassEntityType.MultitypeClass => multitypeCodeConverterFactory,
                _ => throw new NotImplementedException()
            };
        }
    }
}
