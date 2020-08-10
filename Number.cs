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
        private readonly ThreeDigitsGroup group;

        private Number(ThreeDigitsGroup group) { this.group = group; }
        public static Number Of(ThreeDigitsGroup group) { return new Number(group); }

        public string ToWords()
        {
            int segmentSeparatorCounter = 0;
            string result = "";

            foreach (string s in group.Get())
            {
                if (IsNotAllZeros(s))
                    result = ThreeDigit.Of(s.TrimStart('0')).ToWords() + " " + nameOfPowerOfTen[segmentSeparatorCounter] + " " + result;

                segmentSeparatorCounter++;
            }

            return result.TrimEnd(' ');
        }

        private string RemoveAllSpaces(string number)
        {
            return number.Replace(" ", "");
        }

        private bool IsNotAllZeros(string segment)
        {
            return segment.Replace("0", "") != "";
        }
    } 
}
