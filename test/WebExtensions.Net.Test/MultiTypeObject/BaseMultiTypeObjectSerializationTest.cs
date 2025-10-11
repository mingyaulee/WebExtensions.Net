using System.Text.Json;

namespace WebExtensions.Net.Test.MultiTypeObject;

public abstract class BaseMultiTypeObjectSerializationTest<T>
    where T : BaseMultiTypeObject
{
    protected void TestDeserializeAndAssertResult(string serializedValue, T expectedValue)
    {
        var deserialized = JsonSerializer.Deserialize<T>(serializedValue);
        deserialized.ShouldNotBeNull();
        AssertMultiTypeObjectsEqual(deserialized, expectedValue);
    }

    private void AssertMultiTypeObjectsEqual(BaseMultiTypeObject actual, BaseMultiTypeObject expected)
    {
        actual.ValueType.ShouldBe(expected.ValueType);
        if (actual.Value is BaseMultiTypeObject actualMultiTypeObject && expected.Value is BaseMultiTypeObject expectedMultiTypeObject)
        {
            AssertMultiTypeObjectsEqual(actualMultiTypeObject, expectedMultiTypeObject);
        }
        else if (actual.Value is BaseStringFormat actualBaseStringFormat && expected.Value is BaseStringFormat expectedBaseStringFormat)
        {
            actualBaseStringFormat.Value.ShouldBe(expectedBaseStringFormat.Value);
        }
        else
        {
            actual.Value.ShouldBe(expected.Value);
        }
    }
}
