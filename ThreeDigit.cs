using System.Collections.Generic;

namespace NumbersToWords
{
    public class ThreeDigit
    {
        private readonly Dictionary<string, string> nameOfNumber = new Dictionary<string, string>(){
            { "0", "zero"}, {"1", "one"}, {"2", "two"}, {"3", "three"}, {"4", "four"}, {"5", "five"}, {"6", "six"}, {"7", "seven"}, {"8", "eight" },
            { "9", "nine"}, {"10", "ten"}, { "11", "eleven"}, {"12", "twelve"}, {"13", "thirteen"}, {"14", "fourteen"}, {"15", "fifteen"},
            { "16", "sixteen"}, {"17", "seventeen"}, {"18", "eighteen"}, {"19", "ninteen" }, {"20", "twenty"}, {"30", "thirty"},
            { "40", "forty"}, {"50", "fifty"}, {"60", "sixty"}, {"70", "seventy"}, {"80", "eighty"}, {"90", "ninety" } };

        private readonly string number;

        private ThreeDigit(string number) { this.number = number; }

        public static ThreeDigit Of(string number) { return new ThreeDigit(number); }

        public string ToWords()
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
                    result += " " + Of(NumberCombineFromLastTwoDigit(number)).ToWords();
            }

            return result;
        }

        private string NumberCombineFromLastTwoDigit(string number) => number.Substring(1,2).TrimStart('0');

        private string FirstDigit(string number) => number[0].ToString();

        private string SecondDigit(string number) => number[1].ToString();        
    }
}
