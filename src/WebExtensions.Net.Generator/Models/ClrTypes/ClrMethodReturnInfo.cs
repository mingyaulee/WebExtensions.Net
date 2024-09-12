namespace WebExtensions.Net.Generator.Models.ClrTypes
{
    public class ClrMethodReturnInfo
    {
        public string? Description { get; set; }
        public bool HasReturnType => ReturnType is not null;
        public ClrTypeInfo? ReturnType { get; set; }
    }
}
