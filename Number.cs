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
            int arrayIndex = 0;
            string result = "";

            foreach (string threeDigitData in group.Group())
            {
                if (IsNotAllZeros(threeDigitData))
                    result = ThreeDigit.Of(threeDigitData.TrimStart('0')).ToWords() + " " + nameOfPowerOfTen[arrayIndex] + " " + result;

                arrayIndex++;
            }

            return result.TrimEnd(' ');
        }

        private bool IsNotAllZeros(string segment)
        {
            return segment.Replace("0", "") != "";
        }
    } 
}
