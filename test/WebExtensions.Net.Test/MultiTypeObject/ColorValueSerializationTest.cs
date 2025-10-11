using WebExtensions.Net.ActionNs;

namespace WebExtensions.Net.Test.MultiTypeObject;

[TestClass]
public class ColorValueSerializationTest : BaseMultiTypeObjectSerializationTest<ColorValue>
{
    [TestMethod]
    public void TestDeserializeString()
        => TestDeserializeAndAssertResult("\"Blue\"", "Blue");

    [TestMethod]
    public void TestDeserializeArray()
        => TestDeserializeAndAssertResult("[250, 200, 150, 1]", new ColorArray() { 250, 200, 150, 1 });
}
