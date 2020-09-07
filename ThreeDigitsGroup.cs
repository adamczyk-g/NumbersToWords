using System.Collections.Generic;

namespace NumbersToWords
{
    public class ThreeDigitsGroup
    {
        private readonly string number;

        public ThreeDigitsGroup(string number) { this.number = number; }
        
        public IEnumerable<ThreeDigit> Group()
        {
            IEnumerable<ThreeDigit> group = new List<ThreeDigit>();
            
            string numberWithoutSpaces = RemoveSpaces(number);

            group = SplitToThree(numberWithoutSpaces);

            return group;
        }

        private IEnumerable<ThreeDigit> SplitToThree(string number)
        {
            List<ThreeDigit> group = new List<ThreeDigit>();

            for (int i = number.Length - 3; i >= 0; i -= 3)            
                group.Add(ThreeDigit.Of(number.Substring(i, 3).TrimStart('0')));

            if (IsNotMultipleOfThree(number.Length))            
                group.Add(ThreeDigit.Of(number.Substring(0, number.Length % 3).TrimStart('0')));            

            return group;
        }

        private bool IsNotMultipleOfThree(int number) => number % 3 != 0;

        private string RemoveSpaces(string number) => number.Replace(" ", "");        
    }
}
