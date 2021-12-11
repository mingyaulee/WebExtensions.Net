using System.Collections.Generic;

namespace WebExtensions.Net.Generator.CodeGeneration
{
    public class CodeFile
    {
        public CodeFile(string fileName, string? relativePath, string relativeNamespace, string declaration)
        {
            FileName = fileName;
            RelativePath = relativePath;
            UsingNamespaces = new HashSet<string>();
            Namespace = string.IsNullOrEmpty(relativeNamespace) ? Constants.RelativeNamespaceToken : $"{Constants.RelativeNamespaceToken}.{relativeNamespace}";
            Comments = new List<ICodeConverter>();
            Attributes = new List<ICodeConverter>();
            Declaration = declaration;
            Constructors = new List<ICodeConverter>();
            Properties = new List<ICodeConverter>();
            Methods = new List<ICodeConverter>();
        }

        public string FileName { get; }
        public string? RelativePath { get; }
        public ISet<string> UsingNamespaces { get; }
        public string Namespace { get; }
        public IList<ICodeConverter> Comments { get; }
        public IList<ICodeConverter> Attributes { get; }
        public string Declaration { get; set; }
        public IList<ICodeConverter> Constructors { get; }
        public IList<ICodeConverter> Properties { get; }
        public IList<ICodeConverter> Methods { get; }
    }
}
