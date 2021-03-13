using System;

namespace WebExtension.Net
{
    internal class EnumValueAttribute : Attribute
    {
        public string Value { get; }
        public EnumValueAttribute(string value)
        {
            Value = value;
        }
    }
}
