using WebExtensions.Net.Downloads;
using WebExtensions.Net.ExtensionTypes;

namespace WebExtensions.Net.Test.MultiTypeObject;

[TestClass]
public class DownloadTimeSerializationTest : BaseMultiTypeObjectSerializationTest<DownloadTime>
{
    [TestMethod]
    public void TestDeserializeString()
        => TestDeserializeAndAssertResult("\"2000-01-01\"", "2000-01-01");

    [TestMethod]
    public void TestDeserializeDate()
        => TestDeserializeAndAssertResult("946684800000", new Date(946684800000));
}
