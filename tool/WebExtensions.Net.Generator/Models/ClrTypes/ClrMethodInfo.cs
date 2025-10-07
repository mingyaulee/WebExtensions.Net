using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebExtensions.Net.Generator.Models.ClrTypes
{
    [DebuggerDisplay("{PublicName}")]
    public class ClrMethodInfo : ICloneable
    {
#pragma warning disable CS8618 // Properties are initialized when created
        public string Name { get; set; }
        public string PublicName { get; set; }
        public string? Description { get; set; }
        public ClrTypeInfo DeclaringType { get; set; }
        public IEnumerable<ClrParameterInfo> Parameters { get; set; }
        public ClrMethodReturnInfo Return { get; set; }
        public bool IsAsync { get; set; }
        public bool IsObsolete { get; set; }
        public string? ObsoleteMessage { get; set; }
        public IDictionary<string, object> Metadata { get; set; }
#pragma warning restore CS8618

        public object Clone() => MemberwiseClone();
    }
}
