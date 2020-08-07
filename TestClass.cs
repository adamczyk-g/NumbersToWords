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
            string words = new NumberToWordsConverter().Convert(number);
            Assert.AreEqual(expected, words);
        }

        [TestCase(new string[] { "1", "000" }, "1000")]
        [TestCase(new string[] { "1", "100" }, "1100")]
        [TestCase(new string[] { "1", "110" }, "1110")]
        [TestCase(new string[] { "1", "234" }, "1234")]
        [TestCase(new string[] { "12", "345" }, "12345")]
        [TestCase(new string[] { "123", "456" }, "123456")]
        [TestCase(new string[] { "1", "234","567" }, "1 234 567")]
        [TestCase(new string[] { "12", "345", "678" }, "12 345 678")]
        [TestCase(new string[] { "123", "456", "789" }, "123 456 789")]

        public void Split_Test(string[] expected, string number)
        {
            string[] words = new NumberToWordsConverter().SplitNumber(number);
            Assert.AreEqual(expected, words);
        }
    }

    public class NumberToWordsConverter
    {
        private readonly Dictionary<string, string> NameOfNumber = new Dictionary<string, string>(){
            { "0", "zero"}, {"1", "one"}, {"2", "two"}, {"3", "three"}, {"4", "four"}, {"5", "five"}, {"6", "six"}, {"7", "seven"}, {"8", "eight" },
            { "9", "nine"}, {"10", "ten"}, { "11", "eleven"}, {"12", "twelve"}, {"13", "thirteen"}, {"14", "fourteen"}, {"15", "fifteen"},
            { "16", "sixteen"}, {"17", "seventeen"}, {"18", "eighteen"}, {"19", "ninteen" }, {"20", "twenty"}, {"30", "thirty"},
            { "40", "fourty"}, {"50", "fifty"}, {"60", "sixty"}, {"70", "seventy"}, {"80", "eighty"}, {"90", "ninety" } };
        
        public NumberToWordsConverter() { }

        public string[] SplitNumber(string number)
        {
            List<string> split = new List<string>();

            number = number.Replace(" ", "");

            string tmp = "";
            for (int i = number.Length - 3; i >= 0; i-=3)
            {
                tmp = number.Substring(i, 3);
                split.Add(tmp);
            }

            if (number.Length % 3 != 0)
            {
                split.Add(number.Substring(0, number.Length % 3));
            }
            split.Reverse();
            
            return split.ToArray();
        }

        public string Convert(string number)
        {
            number = number.Replace(" ", "");

            return From0To999(number);
        }

        public string From0To999(string number)
        {
            string result = string.Empty;

            if (NameOfNumber.ContainsKey(number))
                return NameOfNumber[number];

            if (number.Length == 2)            
                return NameOfNumber[FirstDigit(number) + "0"] +  "-" + NameOfNumber[SecondDigit(number)];            

            if (number.Length == 3)
            {
                result = NameOfNumber[FirstDigit(number)] + " " + "hundred";

                if(NumberCombineFromLastTwoDigit(number).Length >  0 )                
                    result += " " + From0To999(NumberCombineFromLastTwoDigit(number));                                
            }

            return result;
        }

        private string NumberCombineFromLastTwoDigit(string number)
        {
            return number.Substring(1).TrimStart('0');
        }

        private string FirstDigit(string number)
        {
            return number[0].ToString();
        }

        private string SecondDigit(string number)
        {
            return number[1].ToString();
        }

    }
}
