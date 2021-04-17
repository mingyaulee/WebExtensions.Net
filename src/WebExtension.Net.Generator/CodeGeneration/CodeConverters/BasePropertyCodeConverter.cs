using System.Collections.Generic;
using WebExtension.Net.Generator.Extensions;
using WebExtension.Net.Generator.Models.Schema;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverters
{
    public abstract class BasePropertyCodeConverter : ICodeConverter
    {
        protected IEnumerable<string> UsingNamespaces { get; }
        protected PropertyDefinition PropertyDefinition { get; }
        protected string PropertyType { get; }

        protected BasePropertyCodeConverter(PropertyDefinition propertyDefinition)
        {
            var usingNamespaces = new HashSet<string>();
            var propertyType = propertyDefinition.ToTypeName(usingNamespaces, makeNullable: propertyDefinition.IsOptional);

            UsingNamespaces = usingNamespaces;
            PropertyDefinition = propertyDefinition;
            PropertyType = propertyType;
        }

        public abstract void WriteTo(CodeWriter codeWriter, CodeWriterOptions options);
    }
}
