using WebExtensions.Net.ActionNs;

namespace WebExtensions.Net.Test.MultiTypeObject;

[TestClass]
public class PathSerializationTest : BaseMultiTypeObjectSerializationTest<ActionNs.Path>
{
    [TestMethod]
    public void TestDeserializeString()
        => TestDeserializeAndAssertResult("\"path/to/image.png\"", "path/to/image.png");
}
