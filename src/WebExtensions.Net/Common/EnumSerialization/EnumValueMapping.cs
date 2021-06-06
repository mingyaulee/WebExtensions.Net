namespace WebExtensions.Net
{
    internal class EnumValueMapping
    {
        public EnumValueMapping(string enumValue, string stringValue)
        {
            EnumValue = enumValue;
            StringValue = stringValue;
        }
        public string EnumValue { get; set; }
        public string StringValue { get; set; }
    }
}
