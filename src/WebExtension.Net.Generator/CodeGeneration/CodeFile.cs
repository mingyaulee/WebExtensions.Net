using System.Collections.Generic;

namespace WebExtension.Net.Generator.CodeGeneration
{
    public class CodeFile
    {
        public CodeFile(string fileName, string relativeNamespace, string declaration)
        {
            FileName = fileName;
            UsingRelativeNamespaces = new HashSet<string>();
            UsingNamespaces = new HashSet<string>();
            RelativeNamespace = relativeNamespace;
            Comments = new List<ICodeConverter>();
            Attributes = new List<ICodeConverter>();
            Declaration = declaration;
            Constructors = new List<ICodeConverter>();
            Properties = new List<ICodeConverter>();
            Methods = new List<ICodeConverter>();
        }

        public string FileName { get; }
        public ISet<string> UsingRelativeNamespaces { get; }
        public ISet<string> UsingNamespaces { get; }
        public string RelativeNamespace { get; }
        public IList<ICodeConverter> Comments { get; }
        public IList<ICodeConverter> Attributes { get; }
        public string Declaration { get; set; }
        public IList<ICodeConverter> Constructors { get; }
        public IList<ICodeConverter> Properties { get; }
        public IList<ICodeConverter> Methods { get; }
    }
}
