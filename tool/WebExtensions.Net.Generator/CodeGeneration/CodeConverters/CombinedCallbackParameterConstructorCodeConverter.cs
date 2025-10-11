using System.Collections.Generic;
using System.Linq;
using WebExtensions.Net.Generator.Models.ClrTypes;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters;

public class CombinedCallbackParameterConstructorCodeConverter(IEnumerable<ClrPropertyInfo> clrPropertyInfos) : ICodeConverter
{
    private readonly IEnumerable<ClrPropertyInfo> clrPropertyInfos = clrPropertyInfos;

    public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
    {
        codeWriter.WriteUsingStatement("System");

        var propertyTypes = clrPropertyInfos.Select(property => $"typeof({property.PropertyType.CSharpName})");
        var propertyNames = clrPropertyInfos.Select(property => $"\"{property.PublicName}\"");

        codeWriter.Properties
            .WriteLine($"private static readonly Type[] propertyTypes = [{string.Join(", ", propertyTypes)}];")
            .WriteLine($"private static readonly string[] propertyNames = [{string.Join(", ", propertyNames)}];");

        codeWriter.Declaration
            .WritePrimaryConstructor([], ["propertyTypes", "propertyNames"]);
    }
}
