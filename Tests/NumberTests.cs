using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace NumbersToWords
{
    [TestFixture]
    public class NumberTests
    {
        [TestCase("one thousand", "1 000")]
        [TestCase("one thousand two", "1 002")]
        [TestCase("one thousand ten", "1 010")]
        [TestCase("one thousand eleven", "1 011")]
        [TestCase("one thousand one hundred ten", "1 110")]
        [TestCase("one thousand one hundred eleven", "1 111")]
        [TestCase("ten thousand one hundred eleven", "10 111")]
        [TestCase("nine hundred ninety-nine thousand nine hundred ninety-nine", "999 999")]
        [TestCase("one million", "1 000 000")]
        [TestCase("one million one", "1 000 001")]
        [TestCase("one million one hundred thousand one", "1 100 001")]
        [TestCase("six million three hundred forty-seven thousand six hundred thirty-four", "6 347 634")]
        [TestCase("four hundred sixty-seven billion eight hundred sixty-seven million nine hundred eighty-four thousand nine hundred three", "467 867 984 903")]
        [TestCase("one", "001")]
        [TestCase("eleven", "011")]
        [TestCase("twenty", "020")]
        public void Number_ToWords_Test(string expected, string number)
        {
            string words =  Number.Of(number).ToWords();
            Assert.AreEqual(expected, words);
        }
    }   
}
