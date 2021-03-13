using System;
using System.Text.RegularExpressions;

namespace WebExtension.Net
{
    public class BaseStringFormat
    {
        private readonly string value;

        public BaseStringFormat(string value, string format)
        {
            this.value = value;
            if (!string.IsNullOrEmpty(format) && !Regex.IsMatch(value, format))
            {
                throw new Exception($"The value '{value}' does not match the format '{format}' specified for type {this.GetType().Name}.");
            }
        }

        public override string ToString()
        {
            return value;
        }
    }
}
