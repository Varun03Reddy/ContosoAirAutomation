using NUnit.Framework;

namespace Utilities
{
    /// <summary>
    /// Provides custom assertion wrappers.
    /// </summary>
    public static class AssertionsHelper
    {
        public static void AssertElementText(string actual, string expected, string message = "")
        {
            Assert.AreEqual(expected, actual, string.IsNullOrEmpty(message) ? $"Expected '{expected}', but got '{actual}'." : message);
        }

        public static void AssertTrue(bool condition, string message = "")
        {
            Assert.IsTrue(condition, string.IsNullOrEmpty(message) ? "Condition is not true." : message);
        }

        public static void AssertIsNotEmpty<T>(ICollection<T> collection, string message = "")
        {
            Assert.IsNotEmpty(collection, message);
        }

        public static void AssertIsFalse(bool condition, string message = "")
        {
            Assert.IsFalse(condition, message);
        }

        /// <summary>
        /// Asserts that the given action does not throw any exception.
        /// </summary>
        public static void AssertDoesNotThrow(TestDelegate code, string message = "")
        {
            Assert.DoesNotThrow(code, message);
        }

        public static void AssertFalse(bool condition, string message = "")
        {
            Assert.IsFalse(condition, string.IsNullOrEmpty(message) ? "Condition is not false." : message);
        }
        public static void AssertEqual(string expected, string actual, string message = "")
        {
            Assert.AreEqual(expected, actual, message);
        }

        public static void AssertCollectionEqual<T>(ICollection<T> expected, ICollection<T> actual, string message = "")
        {
            CollectionAssert.AreEqual(expected, actual, message);
        }
    }
}