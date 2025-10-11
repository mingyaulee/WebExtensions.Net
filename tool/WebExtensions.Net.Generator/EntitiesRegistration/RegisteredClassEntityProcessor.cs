using WebExtensions.Net.Generator.Models.Entities;

namespace WebExtensions.Net.Generator.EntitiesRegistration;

public class RegisteredClassEntityProcessor
{
    public void Process(ClassEntity classEntity)
    {
        if (classEntity.NamespaceEntity.FormattedName == "Runtime" && classEntity.FormattedName == "Port")
        {
            // Remove this postMessage function because it has no parameter, so we define it in Extensions/Runtime/Port
            classEntity.Properties.Remove("postMessage");
        }
    }
}
