using NUnit.Framework;
using System.Reflection;

namespace CommonUtilities.Methods
{
    public static class ObjectMethods
    {

        public static void AssertObjectsAreEqual(this object expected, object actual, string message = "")
        {
            Assert.AreEqual(expected.GetType(), actual.GetType());
            foreach (PropertyInfo property in expected.GetType().GetProperties())
            {
                var expectedProperty = property.GetValue(expected, null).ToString();
                var actualProperty = actual.GetType().GetProperty(property.Name)?.GetValue(actual, null).ToString();
                Assert.AreEqual(
                    expectedProperty,
                    actualProperty,
                    $"{message}\nExpected:{property.Name} - '{expectedProperty}', Actual:{property.Name} - '{actualProperty}.");
            }
        }

    }
}