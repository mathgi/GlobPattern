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
            Assert.IsTrue(Parser.IsMatch("ABC", "ABC"));
            Assert.IsFalse(Parser.IsMatch("ABC", "ABD"));

            Assert.IsTrue(Parser.IsMatch("ABC", "AB*"));
            Assert.IsTrue(Parser.IsMatch("ABCD", "AB*"));
            Assert.IsTrue(Parser.IsMatch("AB", "AB*"));

            Assert.IsFalse(Parser.IsMatch("BC", "ABC"));
            Assert.IsTrue(Parser.IsMatch("MBC", "?BC"));
            Assert.IsFalse(Parser.IsMatch("MLBC", "?BC"));

            Assert.IsTrue(Parser.IsMatch("MLBC", "*BC"));

            Assert.IsTrue(Parser.IsMatch("ABCE", "AB*"));

            Assert.IsTrue(Parser.IsMatch("ABC", "A[BJKLSF]C"));
            Assert.IsTrue(Parser.IsMatch("A!C", "A[BJK!]C"));
            Assert.IsFalse(Parser.IsMatch("ABC", "A[!B]C"));

            Assert.IsFalse(Parser.IsMatch("A[]C", "A*[]*C"));
            Assert.IsFalse(Parser.IsMatch("ABC123n", "AT[274!]?Pp"));
        }
    }
}
