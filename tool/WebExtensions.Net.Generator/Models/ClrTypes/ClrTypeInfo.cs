using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebExtensions.Net.Generator.Models.ClrTypes
{
    [DebuggerDisplay("{FullName}")]
    public class ClrTypeInfo : ICloneable
    {
#pragma warning disable CS8618 // Properties are initialized when created
        private string cSharpName;

        public string Id { get; set; }
        public string Namespace { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string CSharpName
        {
            get => CSharpNameGetter?.Invoke() ?? cSharpName;
            set => cSharpName = value;
        }

        public bool IsNullable { get; set; }
        public bool IsEnum { get; set; }
        public IEnumerable<ClrEnumValueInfo>? EnumValues { get; set; }
        public bool IsInterface { get; set; }
        public bool IsNullType { get; set; }
        public bool IsGenericType { get; set; }
        public IEnumerable<ClrTypeInfo> GenericTypeArguments { get; set; }
        public bool IsObsolete { get; set; }
        public string? ObsoleteMessage { get; set; }
        public bool IsGenerated { get; set; }
        public string? GeneratedNamespace { get; set; }
        public string? InitialGeneratedNamespace { get; set; }
        public ISet<string> ReferenceNamespaces { get; set; }
        public ISet<string> RequiredNamespaces { get; set; }
        public ISet<string> Interfaces { get; set; }
        public string? BaseTypeName { get; set; }
        public string? Description { get; set; }
        public IDictionary<string, object> Metadata { get; set; }

        public IEnumerable<ClrMethodInfo> Methods { get; set; }
        public IEnumerable<ClrPropertyInfo> Properties { get; set; }
        public IEnumerable<ClrTypeInfo>? TypeChoices { get; set; }
#pragma warning restore CS8618

        public object Clone()
        {
            var clone = (ClrTypeInfo)MemberwiseClone();
            clone.RequiredNamespaces = new HashSet<string>(RequiredNamespaces);
            clone.ReferenceNamespaces = new HashSet<string>(ReferenceNamespaces);
            clone.Interfaces = new HashSet<string>(Interfaces);
            return clone;
        }

        internal Func<string>? CSharpNameGetter { get; set; }
    }
}
