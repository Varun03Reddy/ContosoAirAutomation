using NUnit.Framework;
using System.Collections.Generic;

namespace Utilities
{
    /// <summary>
    /// Provides custom assertion wrappers for NUnit.
    /// ✅ Helps to standardize assertion messages and reduce repetitive code in tests.
    /// </summary>
    public static class AssertionsHelper
    {
        /// <summary>
        /// Asserts that the actual string matches the expected string.
        /// </summary>
        /// <param name="actual">The actual value from the application.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="message">Optional custom message for failure.</param>
        public static void AssertElementText(string actual, string expected, string message = "")
        {
            Assert.AreEqual(expected, actual, string.IsNullOrEmpty(message) ? $"Expected '{expected}', but got '{actual}'." : message);
        }

        /// <summary>
        /// Asserts that a condition is true.
        /// </summary>
        public static void AssertTrue(bool condition, string message = "")
        {
            Assert.IsTrue(condition, string.IsNullOrEmpty(message) ? "Condition is not true." : message);
        }

        /// <summary>
        /// Asserts that a collection is not empty.
        /// </summary>
        public static void AssertIsNotEmpty<T>(ICollection<T> collection, string message = "")
        {
            Assert.IsNotEmpty(collection, message);
        }

        /// <summary>
        /// Asserts that a condition is false.
        /// </summary>
        public static void AssertIsFalse(bool condition, string message = "")
        {
            Assert.IsFalse(condition, message);
        }

        /// <summary>
        /// Asserts that the given code block does not throw any exception.
        /// ✅ Useful for verifying actions like clicks, navigation, or API calls.
        /// </summary>
        public static void AssertDoesNotThrow(TestDelegate code, string message = "")
        {
            Assert.DoesNotThrow(code, message);
        }

        /// <summary>
        /// Alias for AssertIsFalse, asserts that a condition is false.
        /// </summary>
        public static void AssertFalse(bool condition, string message = "")
        {
            Assert.IsFalse(condition, string.IsNullOrEmpty(message) ? "Condition is not false." : message);
        }

        /// <summary>
        /// Asserts that two strings are equal.
        /// ✅ Simplifies string equality checks with optional message.
        /// </summary>
        public static void AssertEqual(string expected, string actual, string message = "")
        {
            Assert.AreEqual(expected, actual, message);
        }

        /// <summary>
        /// Asserts that two collections are equal.
        /// ✅ Compares each element in the expected and actual collections.
        /// </summary>
        public static void AssertCollectionEqual<T>(ICollection<T> expected, ICollection<T> actual, string message = "")
        {
            CollectionAssert.AreEqual(expected, actual, message);
        }
    }
}
