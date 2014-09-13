using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.MinMissingInteger
{
    /// <summary>
    /// Store the given Array in a HashSet, then iterates from 1 to figure 
    /// out the smallest one not present in the set.
    /// Time Complexity: O(N), Theta(2N) actually
    /// Space Complexity: O(N)
    /// Codility Score 100%
    /// Result Link: https://codility.com/demo/results/demoBYH3JZ-6V4/
    /// 
    /// </summary>
    public class MinMissingIntegerProblem
    {
        public int solution(int[] a)
        {
            if (a == null || a.Length == 0)
                return 0;

            HashSet<int> set = new HashSet<int>();

            foreach(int i in a)
            {
                set.Add(i);
            }

            for (int i = 1; i <= int.MaxValue; i++)
                if(!set.Contains(i))
                return i;

            return int.MaxValue;
        }
    }
}
