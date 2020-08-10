using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace NumbersToWords
{
    [TestFixture]
    public class ThreeDigitGroup_Tests
    {                
        [TestCase(new string[] { "000", "1" }, "1000")]
        [TestCase(new string[] { "100", "1" }, "1100")]
        [TestCase(new string[] { "110", "1" }, "1110")]
        [TestCase(new string[] { "234", "1" }, "1234")]
        [TestCase(new string[] { "345", "12" }, "12345")]
        [TestCase(new string[] { "456", "123" }, "123456")]
        [TestCase(new string[] { "567", "234","1" }, "1 234 567")]
        [TestCase(new string[] { "678", "345", "12" }, "12 345 678")]
        [TestCase(new string[] { "789", "456", "123" }, "123 456 789")]

        public void Get_Test(string[] expected, string number)
        {
            IEnumerable<string> words = new ThreeDigitsGroup(number).Get();
            Assert.AreEqual(expected, words);
        }
    }   
}
