namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;

[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
public class FactAttribute : Attribute
{
    public FactAttribute()
    {
        Order = -1;
    }

    public string Description { get; set; }
    public int Order { get; set; }
    public string Skip { get; set; }
}
