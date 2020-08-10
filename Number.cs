using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToWords
{
    public class Number
    {
        private readonly string[] nameOfPowerOfTen = new string[]{"", "thousand", "million", "billion", "trillion", "quadrillion", "quintillion",
            "sextillion", "septillion", "octillion","nonillion","decillion","undecillion","duodecillion", "tredecillion", "quattuordecillion",
            "Quindecillion", "Sedecillion", "Septendecillion", "Octodecillion", "Novendecillion", "Vigintillion", "Unvigintillion", "Duovigintillion",
            "Tresvigintillion", "Quattuorvigintillion", "Quinvigintillion", "Sesvigintillion", "Septemvigintillion", "Octovigintillion",
            "Novemvigintillion", "Trigintillion", "Untrigintillion", "Duotrigintillion"
        };
        private readonly string number;

        private Number(string number) { this.number = number; }
        public static Number Of(string number) { return new Number(number); }

        public string ToWords()
        {
            string number = RemoveSpaces(this.number);

            int segmentSeparatorCounter = 0;
            string result = "";

            foreach (string s in SplitNumberToThreeDigitParts(number))
            {
                if (IsNotAllZeros(s))
                    result = ThreeDigit.Of(s.TrimStart('0')).ToWords() + " " + nameOfPowerOfTen[segmentSeparatorCounter] + " " + result;

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

        private string[] SplitNumberToThreeDigitParts(string number)
        {
            List<string> split = new List<string>();

            number = number.Replace(" ", "");

            for (int i = number.Length - 3; i >= 0; i -= 3)
                split.Add(number.Substring(i, 3));

            if (number.Length % 3 != 0)
                split.Add(number.Substring(0, number.Length % 3));

            return split.ToArray();
        }
    } 
}
