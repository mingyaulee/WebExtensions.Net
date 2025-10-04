﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly EmptyCodeConverterFactory emptyCodeConverterFactory;
        private readonly CombinedCallbackParameterCodeConverterFactory combinedCallbackParameterCodeConverterFactory;

        public CodeGenerator(IServiceProvider serviceProvider)
        {
            apiRootCodeConverterFactory = serviceProvider.GetRequiredService<ApiRootCodeConverterFactory>();
            apiCodeConverterFactory = serviceProvider.GetRequiredService<ApiCodeConverterFactory>();
            typeCodeConverterFactory = serviceProvider.GetRequiredService<TypeCodeConverterFactory>();
            enumCodeConverterFactory = serviceProvider.GetRequiredService<EnumCodeConverterFactory>();
            stringFormatCodeConverterFactory = serviceProvider.GetRequiredService<StringFormatCodeConverterFactory>();
            arrayCodeConverterFactory = serviceProvider.GetRequiredService<ArrayCodeConverterFactory>();
            multitypeCodeConverterFactory = serviceProvider.GetRequiredService<MultitypeCodeConverterFactory>();
            emptyCodeConverterFactory = serviceProvider.GetRequiredService<EmptyCodeConverterFactory>();
            combinedCallbackParameterCodeConverterFactory = serviceProvider.GetRequiredService<CombinedCallbackParameterCodeConverterFactory>();
        }

        public IEnumerable<CodeFileConverter> GetCodeFileConverters(IEnumerable<ClrTypeInfo> clrTypes)
        {
            return clrTypes.Select(GetClrTypeCodeConverter).ToArray();
        }

        private CodeFileConverter GetClrTypeCodeConverter(ClrTypeInfo clrTypeInfo)
        {
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
            var codeFile = new CodeFile(
                fileName: clrTypeInfo.CSharpName,
                relativePath: clrTypeInfo.InitialGeneratedNamespace,
                relativeNamespace: clrTypeInfo.GeneratedNamespace ?? string.Empty,
                declaration: declaration);
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
                ClassType.EmptyClass => emptyCodeConverterFactory,
                ClassType.CombinedCallbackParameterClass => combinedCallbackParameterCodeConverterFactory,
                _ => throw new NotImplementedException()
            };
        }
    }
}
