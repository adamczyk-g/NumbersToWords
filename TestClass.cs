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
    }

    public class NumberToWordsConverter
    {
        private readonly Dictionary<string, string> NameOfNumber = new Dictionary<string, string>(){
            { "0", "zero"}, {"1", "one"}, {"2", "two"}, {"3", "three"}, {"4", "four"}, {"5", "five"}, {"6", "six"}, {"7", "seven"}, {"8", "eight" },
            { "9", "nine"}, {"10", "ten"}, { "11", "eleven"}, {"12", "twelve"}, {"13", "thirteen"}, {"14", "fourteen"}, {"15", "fifteen"},
            { "16", "sixteen"}, {"17", "seventeen"}, {"18", "eighteen"}, {"19", "ninteen" }, {"20", "twenty"}, {"30", "thirty"},
            { "40", "fourty"}, {"50", "fifty"}, {"60", "sixty"}, {"70", "seventy"}, {"80", "eighty"}, {"90", "ninety" } };
        
        /*
        private readonly Dictionary<string, string> first = new Dictionary<string, string>(){
            { "0", "zero"}, {"1", "one"}, {"2", "two"}, {"3", "three"}, {"4", "four"}, {"5", "five"}, {"6", "six"}, {"7", "seven"}, {"8", "eight" },
            { "9", "nine"} };

        private readonly Dictionary<string, string> second = new Dictionary<string, string>(){
            {"20", "twenty"}, {"30", "thirty"}, { "40", "fourty"}, {"50", "fifty"}, {"60", "sixty"}, {"70", "seventy"}, {"80", "eighty"}, {"90", "ninety" }, {"100", "hundred" }};

       
        private readonly string[] first = {"zero", "one", "two", "three", "four", "five", "six", "seven","eight", "nine"};
        private readonly string[] second = { "ten", "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety", "hundred" };
        */

        public NumberToWordsConverter() { }

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
