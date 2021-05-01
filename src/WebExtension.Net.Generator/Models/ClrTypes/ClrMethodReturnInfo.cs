namespace WebExtension.Net.Generator.Models.ClrTypes
{
    public class ClrMethodReturnInfo
    {
        public string? Description { get; set; }
        public bool HasReturnType { get; set; }
        public ClrTypeInfo? ReturnType { get; set; }
    }
}
