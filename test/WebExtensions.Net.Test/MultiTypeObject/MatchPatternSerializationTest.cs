using WebExtensions.Net.Manifest;

namespace WebExtensions.Net.Test.MultiTypeObject
{
    [TestClass]
    public class MatchPatternSerializationTest : BaseMultiTypeObjectSerializationTest<MatchPattern>
    {
        [TestMethod]
        public void TestDeserializeMatchPatternType1()
            => TestDeserializeAndAssertResult("\"<all_urls>\"", MatchPatternType1.AllUrls);

        [TestMethod]
        public void TestDeserializeMatchPatternRestricted()
            => TestDeserializeAndAssertResult("\"AnyString\"", new MatchPatternRestricted("AnyString"));

        [TestMethod]
        public void TestDeserializeMatchPatternUnestricted()
            => TestDeserializeAndAssertResult("\"about:\"", new MatchPatternUnestricted("about:"));
    }
}
