using GlobPattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProjectGlobPattern
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var p1 = new Parser();
            Assert.IsTrue(p1.IsMatch("ABC", "ABC"));
            Assert.IsFalse(p1.IsMatch("ABC", "ABD"));

            Assert.IsTrue(p1.IsMatch("ABC", "AB*"));
            Assert.IsTrue(p1.IsMatch("ABCD", "AB*"));
            Assert.IsTrue(p1.IsMatch("AB", "AB*"));

            Assert.IsFalse(p1.IsMatch("BC", "ABC"));
            Assert.IsTrue(p1.IsMatch("MBC", "?BC"));
            Assert.IsFalse(p1.IsMatch("MLBC", "?BC"));

            Assert.IsTrue(p1.IsMatch("MLBC", "*BC"));

            Assert.IsTrue(p1.IsMatch("ABCE", "AB*"));

            Assert.IsTrue(p1.IsMatch("ABC", "A[BJKLSF]C"));
            Assert.IsTrue(p1.IsMatch("A!C", "A[BJK!]C"));
            Assert.IsFalse(p1.IsMatch("ABC", "A[!B]C"));

            Assert.IsFalse(p1.IsMatch("A[]C", "A*[]*C"));
            Assert.IsFalse(p1.IsMatch("ABC123n", "AT[274!]?Pp"));

            var p2 = new Parser((parsedInput, currentState) => parsedInput.Length <= 2);
            Assert.IsTrue(p2.IsMatch("ABC", "ABC"));

        }
    }
}
