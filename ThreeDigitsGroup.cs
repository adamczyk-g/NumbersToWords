using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToWords
{
    public class ThreeDigitsGroup
    {
        private readonly string number;

        public ThreeDigitsGroup(string number) { this.number = number; }
        
        public IEnumerable<ThreeDigit> Group()
        {
            List<ThreeDigit> group = new List<ThreeDigit>();
            string threeDigit = string.Empty;
            
            string number = this.number.Replace(" ", "");

            for (int i = number.Length - 3; i >= 0; i -= 3)
            {
                threeDigit = number.Substring(i, 3);
                group.Add(ThreeDigit.Of(threeDigit.TrimStart('0')));
            }

            if (number.Length % 3 != 0)
            {
                threeDigit = number.Substring(0, number.Length % 3);
                group.Add(ThreeDigit.Of(threeDigit.TrimStart('0')));
            }

            return group;
        }
    }
}
