using Library.Day4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.Tests
{
    [TestClass]
    public class TestDay4
    {
        [TestMethod]
        public void TestDay1()
        {
            Assert.IsTrue(PasswordChecker.IsValid(111111));
            Assert.IsFalse(PasswordChecker.IsValid(223450));
            Assert.IsFalse(PasswordChecker.IsValid(123789));
        }

        [TestMethod]
        public void Day1Problem()
        {
            //How many different passwords within the range given in your puzzle input meet these criteria?
            //Your puzzle input is 278384-824795.
            Assert.AreEqual(921, PasswordChecker.PasswordCheck(278384,824795));
        }

        [TestMethod]
        public void TestDay2()
        {
            Assert.IsTrue(PasswordChecker.IsValid(112233, true));
            Assert.IsFalse(PasswordChecker.IsValid(123444, true));
            Assert.IsTrue(PasswordChecker.IsValid(111122, true));
        }

        [TestMethod]
        public void Day2Problem()
        {
            //How many different passwords within the range given in your puzzle input meet these criteria?
            //Your puzzle input is 278384-824795.
            Assert.AreEqual(603, PasswordChecker.PasswordCheck(278384,824795, true));
        }

    }
}
