using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using WebExtensions.Net.Generator.CodeGeneration;
using WebExtensions.Net.Generator.CodeGeneration.CodeConverterFactories;
using WebExtensions.Net.Generator.CodeGeneration.CodeConverters;
using WebExtensions.Net.Generator.Models;
using WebExtensions.Net.Generator.Models.ClrTypes;

namespace WebExtensions.Net.Generator;

public class CodeGenerator(IServiceProvider serviceProvider)
{
    private readonly ApiRootCodeConverterFactory apiRootCodeConverterFactory = serviceProvider.GetRequiredService<ApiRootCodeConverterFactory>();
    private readonly ApiCodeConverterFactory apiCodeConverterFactory = serviceProvider.GetRequiredService<ApiCodeConverterFactory>();
    private readonly TypeCodeConverterFactory typeCodeConverterFactory = serviceProvider.GetRequiredService<TypeCodeConverterFactory>();
    private readonly EnumCodeConverterFactory enumCodeConverterFactory = serviceProvider.GetRequiredService<EnumCodeConverterFactory>();
    private readonly StringFormatCodeConverterFactory stringFormatCodeConverterFactory = serviceProvider.GetRequiredService<StringFormatCodeConverterFactory>();
    private readonly ArrayCodeConverterFactory arrayCodeConverterFactory = serviceProvider.GetRequiredService<ArrayCodeConverterFactory>();
    private readonly MultitypeCodeConverterFactory multitypeCodeConverterFactory = serviceProvider.GetRequiredService<MultitypeCodeConverterFactory>();
    private readonly EmptyCodeConverterFactory emptyCodeConverterFactory = serviceProvider.GetRequiredService<EmptyCodeConverterFactory>();
    private readonly CombinedCallbackParameterCodeConverterFactory combinedCallbackParameterCodeConverterFactory = serviceProvider.GetRequiredService<CombinedCallbackParameterCodeConverterFactory>();

    public IEnumerable<CodeFileConverter> GetCodeFileConverters(IEnumerable<ClrTypeInfo> clrTypes)
        => [.. clrTypes.Select(GetClrTypeCodeConverter)];

    private CodeFileConverter GetClrTypeCodeConverter(ClrTypeInfo clrTypeInfo)
    {
        var codeType = GetCodeType(clrTypeInfo);
        if (codeType != "enum")
        {
            codeType = $"partial {codeType}";
        }
        var declaration = $"public {codeType} {clrTypeInfo.CSharpName}{{0}}";
        if (!string.IsNullOrEmpty(clrTypeInfo.BaseTypeName))
        {
            declaration += $" : {clrTypeInfo.BaseTypeName}{{1}}";
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
        return clrTypeInfo.IsEnum ? "enum" : "class";
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

    private ICodeConverterFactory GetFactory(ClassType classType) => classType switch
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
