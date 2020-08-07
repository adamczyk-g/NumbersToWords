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
            string words = new NumberToWordsConverter().ConvertSegmentToWords(number);
            Assert.AreEqual(expected, words);
        }

        [TestCase(new string[] { "000", "1" }, "1000")]
        [TestCase(new string[] { "100", "1" }, "1100")]
        [TestCase(new string[] { "110", "1" }, "1110")]
        [TestCase(new string[] { "234", "1" }, "1234")]
        [TestCase(new string[] { "345", "12" }, "12345")]
        [TestCase(new string[] { "456", "123" }, "123456")]
        [TestCase(new string[] { "567", "234","1" }, "1 234 567")]
        [TestCase(new string[] { "678", "345", "12" }, "12 345 678")]
        [TestCase(new string[] { "789", "456", "123" }, "123 456 789")]

        public void Split_Test(string[] expected, string number)
        {
            string[] words = new NumberToWordsConverter().SplitNumberToSegmentsOfTrees(number);
            Assert.AreEqual(expected, words);
        }

        [TestCase("one thousand", "1000")]
        [TestCase("one thousand two", "1002")]
        [TestCase("one thousand ten", "1010")]
        [TestCase("one thousand eleven", "1011")]
        [TestCase("one thousand one hundred ten", "1110")]
        [TestCase("one thousand one hundred eleven", "1111")]
        [TestCase("ten thousand one hundred eleven", "10111")]
        [TestCase("nine hundred ninety-nine thousand nine hundred ninety-nine", "999999")]
        [TestCase("one million", "1000000")]
        [TestCase("one million one", "1 000 001")]
        [TestCase("one million one hundred thousand one", "1 100 001")]
        [TestCase("six million three hundred forty-seven thousand six hundred thirty-four", "6347634")]
        [TestCase("four hundred sixty-seven billion eight hundred sixty-seven million nine hundred eighty-four thousand nine hundred three", "467867984903")]

        public void Convert_Test(string expected, string number)
        {
            string words = new NumberToWordsConverter().Convert(number);
            Assert.AreEqual(expected, words);
        }
    }

    public class NumberToWordsConverter
    {
        private readonly Dictionary<string, string> nameOfNumber = new Dictionary<string, string>(){
            { "0", "zero"}, {"1", "one"}, {"2", "two"}, {"3", "three"}, {"4", "four"}, {"5", "five"}, {"6", "six"}, {"7", "seven"}, {"8", "eight" },
            { "9", "nine"}, {"10", "ten"}, { "11", "eleven"}, {"12", "twelve"}, {"13", "thirteen"}, {"14", "fourteen"}, {"15", "fifteen"},
            { "16", "sixteen"}, {"17", "seventeen"}, {"18", "eighteen"}, {"19", "ninteen" }, {"20", "twenty"}, {"30", "thirty"},
            { "40", "forty"}, {"50", "fifty"}, {"60", "sixty"}, {"70", "seventy"}, {"80", "eighty"}, {"90", "ninety" } };

        private readonly string[] segmentsSeparator = new string[]{"", "thousand", "million", "billion", "trillion", "quadrillion", "quintillion",
            "sextillion", "septillion", "octillion","nonillion","decillion","undecillion", };

        public NumberToWordsConverter() { }

        public string Convert(string number)
        {
            number = number.Replace(" ", "");
            string result = "";
            int segmentSeparatorCounter = 0;

            foreach (string s in SplitNumberToSegmentsOfTrees(number))
            {
                if (IsSegmentNotEmpty(s))
                    result = ConvertSegmentToWords(s.TrimStart('0')) + " " + segmentsSeparator[segmentSeparatorCounter] + " " + result;

                segmentSeparatorCounter++;
            }

            return result.TrimEnd(' ');
        }

        private bool IsSegmentNotEmpty(string segment)
        {
            return segment.Replace("0","")!="";
        }

        public string[] SplitNumberToSegmentsOfTrees(string number)
        {
            List<string> split = new List<string>();

            number = number.Replace(" ", "");

            for (int i = number.Length - 3; i >= 0; i-=3)            
                split.Add(number.Substring(i, 3));            

            if (number.Length % 3 != 0)            
                split.Add(number.Substring(0, number.Length % 3));            
            
            return split.ToArray();
        }

        public string ConvertSegmentToWords(string number)
        {
            string result = string.Empty;

            if (nameOfNumber.ContainsKey(number))
                return nameOfNumber[number];

            if (number.Length == 2)            
                return nameOfNumber[FirstDigit(number) + "0"] +  "-" + nameOfNumber[SecondDigit(number)];            

            if (number.Length == 3)
            {
                result = nameOfNumber[FirstDigit(number)] + " " + "hundred";

                if(NumberCombineFromLastTwoDigit(number).Length >  0 )                
                    result += " " + ConvertSegmentToWords(NumberCombineFromLastTwoDigit(number));                                
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
