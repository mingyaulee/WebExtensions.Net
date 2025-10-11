using System.Collections.Generic;

namespace WebExtensions.Net.Generator.CodeGeneration;

public class CodeFile(string fileName, string? relativePath, string relativeNamespace, string declaration)
{
    public string FileName { get; } = fileName;
    public string? RelativePath { get; } = relativePath;
    public ISet<string> UsingNamespaces { get; } = new HashSet<string>();
    public string Namespace { get; } = string.IsNullOrEmpty(relativeNamespace) ? Constants.RelativeNamespaceToken : $"{Constants.RelativeNamespaceToken}.{relativeNamespace}";
    public IList<ICodeConverter> Comments { get; } = [];
    public IList<ICodeConverter> Attributes { get; } = [];
    public string Declaration { get; } = declaration;
    public IList<ICodeConverter> Constructors { get; } = [];
    public IList<ICodeConverter> Properties { get; } = [];
    public IList<ICodeConverter> Methods { get; } = [];
}
