using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToWords
{
    public class GroupOfThreeDigitSegments
    {
        private readonly string number;

        public GroupOfThreeDigitSegments(string number) { this.number = number; }
        
        public IEnumerable<string> Group()
        {
            List<string> split = new List<string>();
            
            string number = this.number.Replace(" ", "");

            for (int i = number.Length - 3; i >= 0; i -= 3)
                split.Add(number.Substring(i, 3));

            if (number.Length % 3 != 0)
                split.Add(number.Substring(0, number.Length % 3));

            return split;
        }
    }
}
