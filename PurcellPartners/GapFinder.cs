using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurcellPartners
{
    public class GapFinder
    {
        public static int Find(int[] numbers)
        {
            if(numbers == null || numbers.Length < 2)
            {
                return -1;
            }

            var sorted = numbers.OrderBy(x => x).ToArray();

            for(int i = 1; i < sorted.Length; i++)
            {
                if (sorted[i] - sorted[i - 1] > 1)
                {
                    return sorted[i - 1] + 1;
                }
            }

            return -1;
        }
    }
}
