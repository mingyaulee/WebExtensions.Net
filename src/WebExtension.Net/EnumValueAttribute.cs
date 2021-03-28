using System;

namespace WebExtension.Net
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple =false, Inherited = false)]
    internal class EnumValueAttribute : Attribute
    {
        public string Value { get; }
        public EnumValueAttribute(string value)
        {
            Value = value;
        }
    }
}
