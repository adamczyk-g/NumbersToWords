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
        private readonly ThreeDigitsGroup threeDigitsGroup;

        private Number(string number) { this.threeDigitsGroup = new ThreeDigitsGroup(number); }

        public static Number Of(string number) { return new Number(number); }

        public string ToWords()
        {
            int powerOfTenArrayIndex = 0;
            string result = string.Empty;

            foreach (ThreeDigit threeDigitData in threeDigitsGroup.Group())
            {
                if (threeDigitData.ToWords() != string.Empty)
                   result = threeDigitData.ToWords() + " " + nameOfPowerOfTen[powerOfTenArrayIndex] + " " + result;

                powerOfTenArrayIndex++;
            }

            return result.TrimEnd(' ');
        }       
    } 
}
