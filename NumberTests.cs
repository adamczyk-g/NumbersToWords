using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace NumbersToWords
{
    [TestFixture]
    public class TestClass
    {
        [TestCase("zero", "0")]
        [TestCase("one", "1")]
        [TestCase("two", "2")]
        [TestCase("three", "3")]
        [TestCase("four", "4")]
        [TestCase("five", "5")]
        [TestCase("six", "6")]
        [TestCase("seven", "7")]
        [TestCase("eight", "8")]
        [TestCase("nine", "9")]
        [TestCase("ten", "10")]
        [TestCase("eleven", "11")]
        [TestCase("twelve", "12")]
        [TestCase("thirteen", "13")]
        [TestCase("fourteen", "14")]
        [TestCase("fifteen", "15")]
        [TestCase("sixteen", "16")]
        [TestCase("seventeen", "17")]
        [TestCase("eighteen", "18")]
        [TestCase("ninteen", "19")]
        [TestCase("twenty", "20")]
        [TestCase("twenty-one", "21")]
        [TestCase("ninety-nine", "99")]
        [TestCase("one hundred", "100")]
        [TestCase("one hundred one", "101")]
        [TestCase("two hundred", "200")]
        [TestCase("two hundred two", "202")]
        [TestCase("two hundred twenty", "220")]
        [TestCase("two hundred twenty-two", "222")]
        [TestCase("nine hundred ninety-nine", "999")]
        public void From_0_To_999_Test(string expected, string number)
        {
            string words = ThreeDigit.Of(number).ToWords();
            Assert.AreEqual(expected, words);
        }
        
        [TestCase("one thousand", "1 000")]
        [TestCase("one thousand two", "1 002")]
        [TestCase("one thousand ten", "1 010")]
        [TestCase("one thousand eleven", "1 011")]
        [TestCase("one thousand one hundred ten", "1 110")]
        [TestCase("one thousand one hundred eleven", "1 111")]
        [TestCase("ten thousand one hundred eleven", "10 111")]
        [TestCase("nine hundred ninety-nine thousand nine hundred ninety-nine", "999999")]
        [TestCase("one million", "1000000")]
        [TestCase("one million one", "1 000 001")]
        [TestCase("one million one hundred thousand one", "1 100 001")]
        [TestCase("six million three hundred forty-seven thousand six hundred thirty-four", "6 347 634")]
        [TestCase("four hundred sixty-seven billion eight hundred sixty-seven million nine hundred eighty-four thousand nine hundred three", "467 867 984 903")]
        [TestCase("one", "001")]
        [TestCase("eleven", "011")]
        [TestCase("twenty", "020")]
        public void Convert_Test(string expected, string number)
        {
            string words = Number.Of(number).ToWords();
            Assert.AreEqual(expected, words);
        }
    }   
}
