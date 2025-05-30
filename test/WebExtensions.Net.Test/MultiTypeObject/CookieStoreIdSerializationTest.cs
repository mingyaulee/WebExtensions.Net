using WebExtensions.Net.ContentScripts;

namespace WebExtensions.Net.Test.MultiTypeObject
{
    [TestClass]
    public class CookieStoreIdSerializationTest : BaseMultiTypeObjectSerializationTest<CookieStoreId>
    {
        [TestMethod]
        public void TestDeserializeString()
            => TestDeserializeAndAssertResult("\"Id1\"", "Id1");

        [TestMethod]
        public void TestDeserializeArray()
            => TestDeserializeAndAssertResult("[\"Id1\", \"Id2\"]", new CookieStoreId([ "Id1", "Id2" ]));
    }
}
