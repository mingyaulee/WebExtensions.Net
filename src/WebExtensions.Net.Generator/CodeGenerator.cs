using System;
using System.Collections.Generic;
using System.Linq;
using WebExtensions.Net.Generator.CodeGeneration;
using WebExtensions.Net.Generator.CodeGeneration.CodeConverterFactories;
using WebExtensions.Net.Generator.CodeGeneration.CodeConverters;
using WebExtensions.Net.Generator.Models;
using WebExtensions.Net.Generator.Models.ClrTypes;

namespace WebExtensions.Net.Generator
{
    public class CodeGenerator
    {
        private readonly ApiRootCodeConverterFactory apiRootCodeConverterFactory;
        private readonly ApiCodeConverterFactory apiCodeConverterFactory;
        private readonly TypeCodeConverterFactory typeCodeConverterFactory;
        private readonly EnumCodeConverterFactory enumCodeConverterFactory;
        private readonly StringFormatCodeConverterFactory stringFormatCodeConverterFactory;
        private readonly ArrayCodeConverterFactory arrayCodeConverterFactory;
        private readonly MultitypeCodeConverterFactory multitypeCodeConverterFactory;

        public CodeGenerator(
            ApiRootCodeConverterFactory apiRootCodeConverterFactory,
            ApiCodeConverterFactory apiCodeConverterFactory,
            TypeCodeConverterFactory typeCodeConverterFactory,
            EnumCodeConverterFactory enumCodeConverterFactory,
            StringFormatCodeConverterFactory stringFormatCodeConverterFactory,
            ArrayCodeConverterFactory arrayCodeConverterFactory,
            MultitypeCodeConverterFactory multitypeCodeConverterFactory)
        {
            this.apiRootCodeConverterFactory = apiRootCodeConverterFactory;
            this.apiCodeConverterFactory = apiCodeConverterFactory;
            this.typeCodeConverterFactory = typeCodeConverterFactory;
            this.enumCodeConverterFactory = enumCodeConverterFactory;
            this.stringFormatCodeConverterFactory = stringFormatCodeConverterFactory;
            this.arrayCodeConverterFactory = arrayCodeConverterFactory;
            this.multitypeCodeConverterFactory = multitypeCodeConverterFactory;
        }

        public IEnumerable<CodeFileConverter> GetCodeFileConverters(IEnumerable<ClrTypeInfo> clrTypes)
        {
            return clrTypes.Select(GetClrTypeCodeConverter).ToArray();
        }

        private CodeFileConverter GetClrTypeCodeConverter(ClrTypeInfo clrTypeInfo)
        {
            var relativeNamespace = clrTypeInfo.GeneratedNamespace ?? string.Empty;
            var codeType = GetCodeType(clrTypeInfo);
            if (codeType != "enum")
            {
                codeType = $"partial {codeType}";
            }
            var declaration = $"public {codeType} {clrTypeInfo.CSharpName}";
            if (!string.IsNullOrEmpty(clrTypeInfo.BaseTypeName))
            {
                declaration += $" : {clrTypeInfo.BaseTypeName}";
                if (clrTypeInfo.Interfaces.Any())
                {
                    declaration += $", {string.Join(", ", clrTypeInfo.Interfaces)}";
                }
            }
            else if (clrTypeInfo.Interfaces.Any())
            {
                declaration += $" : {string.Join(", ", clrTypeInfo.Interfaces)}";
            }
            var codeFile = new CodeFile(clrTypeInfo.CSharpName, relativeNamespace, declaration);
            foreach (var usingNamespace in clrTypeInfo.RequiredNamespaces)
            {
                codeFile.UsingNamespaces.Add(usingNamespace);
            }
            TranslateClrTypeToCodeFile(clrTypeInfo, codeFile);
            return new CodeFileConverter(codeFile);
        }

        private static string GetCodeType(ClrTypeInfo clrTypeInfo)
        {
            if (clrTypeInfo.IsInterface)
            {
                return "interface";
            }
            if (clrTypeInfo.IsEnum)
            {
                return "enum";
            }
            return "class";
        }

        private void TranslateClrTypeToCodeFile(ClrTypeInfo clrTypeInfo, CodeFile codeFile)
        {
            var classType = (ClassType)clrTypeInfo.Metadata[Constants.TypeMetadata.ClassType];
            var factory = GetFactory(classType);
            if (clrTypeInfo.IsInterface)
            {
                factory.AddInterfaceConvertersToCodeFile(clrTypeInfo, codeFile);
            }
            else
            {
                factory.AddConvertersToCodeFile(clrTypeInfo, codeFile);
            }
        }

        private ICodeConverterFactory GetFactory(ClassType classType)
        {
            return classType switch
            {
                ClassType.ApiRootClass => apiRootCodeConverterFactory,
                ClassType.ApiClass => apiCodeConverterFactory,
                ClassType.TypeClass => typeCodeConverterFactory,
                ClassType.EnumClass => enumCodeConverterFactory,
                ClassType.StringFormatClass => stringFormatCodeConverterFactory,
                ClassType.ArrayClass => arrayCodeConverterFactory,
                ClassType.MultitypeClass => multitypeCodeConverterFactory,
                _ => throw new NotImplementedException()
            };
        }
    }
}
