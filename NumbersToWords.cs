using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToWords
{
    public class NumberToWordsConverter
    {
        private readonly Dictionary<string, string> nameOfNumber = new Dictionary<string, string>(){
            { "0", "zero"}, {"1", "one"}, {"2", "two"}, {"3", "three"}, {"4", "four"}, {"5", "five"}, {"6", "six"}, {"7", "seven"}, {"8", "eight" },
            { "9", "nine"}, {"10", "ten"}, { "11", "eleven"}, {"12", "twelve"}, {"13", "thirteen"}, {"14", "fourteen"}, {"15", "fifteen"},
            { "16", "sixteen"}, {"17", "seventeen"}, {"18", "eighteen"}, {"19", "ninteen" }, {"20", "twenty"}, {"30", "thirty"},
            { "40", "forty"}, {"50", "fifty"}, {"60", "sixty"}, {"70", "seventy"}, {"80", "eighty"}, {"90", "ninety" } };

        private readonly string[] nameOfPowerOfTen = new string[]{"", "thousand", "million", "billion", "trillion", "quadrillion", "quintillion",
            "sextillion", "septillion", "octillion","nonillion","decillion","undecillion","duodecillion", "tredecillion", "quattuordecillion",
            "Quindecillion", "Sedecillion", "Septendecillion", "Octodecillion", "Novendecillion", "Vigintillion", "Unvigintillion", "Duovigintillion",
            "Tresvigintillion", "Quattuorvigintillion", "Quinvigintillion", "Sesvigintillion", "Septemvigintillion", "Octovigintillion",
            "Novemvigintillion", "Trigintillion", "Untrigintillion", "Duotrigintillion"
        };

        public NumberToWordsConverter() { }

        public string Convert(string number)
        {
            number = RemoveSpaces(number);

            int segmentSeparatorCounter = 0;
            string result = "";

            foreach (string s in SplitNumberToSegmentsOfThrees(number))
            {
                if (IsNotAllZeros(s))
                    result = ConvertSegmentToWords(s.TrimStart('0')) + " " + nameOfPowerOfTen[segmentSeparatorCounter] + " " + result;

                segmentSeparatorCounter++;
            }

            return result.TrimEnd(' ');
        }

        private string RemoveSpaces(string number)
        {
            return number.Replace(" ", "");
        }

        private bool IsNotAllZeros(string segment)
        {
            return segment.Replace("0", "") != "";
        }

        public string[] SplitNumberToSegmentsOfThrees(string number)
        {
            List<string> split = new List<string>();

            number = number.Replace(" ", "");

            for (int i = number.Length - 3; i >= 0; i -= 3)
                split.Add(number.Substring(i, 3));

            if (number.Length % 3 != 0)
                split.Add(number.Substring(0, number.Length % 3));

            return split.ToArray();
        }

        public string ConvertSegmentToWords(string number)
        {
            if (nameOfNumber.ContainsKey(number))
                return nameOfNumber[number];

            if (number.Length == 2)
                return nameOfNumber[FirstDigit(number) + "0"] + "-" + nameOfNumber[SecondDigit(number)];

            string result = string.Empty;

            if (number.Length == 3)
            {
                result = nameOfNumber[FirstDigit(number)] + " " + "hundred";

                if (NumberCombineFromLastTwoDigit(number).Length > 0)
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
