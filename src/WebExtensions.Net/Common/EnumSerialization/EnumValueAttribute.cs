using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WebExtensions.Net
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple =false, Inherited = false)]
    internal class EnumValueAttribute : Attribute
    {
        public string Value { get; }
        public EnumValueAttribute(string value)
        {
            Value = value;
        }

        public static Dictionary<string, object> GetEnumValues(Type type)
        {
            if (cachedAttributes.TryGetValue(type, out var cached))
            {
                return cached;
            }

            cached = type.GetFields(BindingFlags.Public | BindingFlags.Static)
                .Select(enumField => KeyValuePair.Create(enumField.GetCustomAttribute<EnumValueAttribute>()?.Value ?? enumField.Name, enumField.GetValue(null)!))
                .ToDictionary();
            cachedAttributes[type] = cached;
            return cached;
        }

        private static Dictionary<Type, Dictionary<string, object>> cachedAttributes = new();
    }
}
