using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.FirstCoveringPrefix
{
    public class FirstCoveringPrefixProblem
    {
        /// <summary>
        /// First correct solution with acceptable performance.
        /// This solution iterates thru the array and adds unseen values in a hashset 
        /// and updates the prefix value
        /// Time Complexity: O(N) 
        /// Space Complexity: O(N)
        /// Codility Score 100%
        /// Result Link: https://codility.com/demo/results/demoJWZGUR-JDD/
        /// 
        /// Comments: Turned out to be too easy
        /// </summary>
        public int solution(int[] array)
        {
            var valueSet = new HashSet<int>();
            int prefixValue = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if(!valueSet.Contains(array[i]))
                {
                    valueSet.Add(array[i]);
                    prefixValue = i;
                }
            }
            return prefixValue;
        }
    }
}
