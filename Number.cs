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

        private Number(string number) { this.group = new ThreeDigitsGroup(number); }
        public static Number Of(string number) { return new Number(number); }

        public string ToWords()
        {
            int powerOfTenArrayIndex = 0;
            string result = "";

            foreach (ThreeDigit threeDigitData in group.Group())
            {
                if (threeDigitData.ToWords() != string.Empty)
                   result = threeDigitData.ToWords() + " " + nameOfPowerOfTen[powerOfTenArrayIndex] + " " + result;

                powerOfTenArrayIndex++;
            }

            return result.TrimEnd(' ');
        }

        private bool IsNotAllZeros(string segment)
        {
            return segment.Replace("0", "") != "";
        }
    } 
}
