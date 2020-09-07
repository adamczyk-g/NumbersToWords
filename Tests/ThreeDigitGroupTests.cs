using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace NumbersToWords
{
    [TestFixture]
    public class ThreeDigitGroupTests
    {                
        [TestCase(new string[] { "", "one" }, "1000")]
        [TestCase(new string[] { "one hundred", "one" }, "1100")]
        [TestCase(new string[] { "one hundred ten", "one" }, "1110")]
        [TestCase(new string[] { "two hundred thirty-four", "one" }, "1234")]
        [TestCase(new string[] { "three hundred forty-five", "twelve" }, "12345")]
        [TestCase(new string[] { "four hundred fifty-six", "one hundred twenty-three" }, "123456")]
        [TestCase(new string[] { "five hundred sixty-seven", "two hundred thirty-four", "one" }, "1 234 567")]
        [TestCase(new string[] { "six hundred seventy-eight", "three hundred forty-five", "twelve" }, "12 345 678")]
        [TestCase(new string[] { "seven hundred eighty-nine", "four hundred fifty-six", "one hundred twenty-three" }, "123 456 789")]

        public void GropuDigits_Test(string[] expected, string number)
        {
            List<string> words = new List<string>();

            foreach (ThreeDigit d in new ThreeDigitsGroup(number).Group())
                words.Add(d.ToWords());

            Assert.AreEqual(expected, words);
        }
    }   
}
