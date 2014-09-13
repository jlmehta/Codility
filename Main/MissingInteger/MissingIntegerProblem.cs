using System;
using System.Linq;

namespace Main.MissingInteger
{
    public class MissingIntegerProblem
    {
        /// <summary>
        /// Correct solution with acceptable performance.
        /// This solution computes the sum of the given number and finds the max to find the missing number.
        /// Time Complexity: O(N) 
        /// Space Complexity: O(1)
        /// Codility Score 100%
        /// Result Link: https://codility.com/demo/results/demo9P2T47-RVG/
        /// </summary>
        /// 
        public int solution(int[] a)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            if (a == null) 
                return 0;

            if (a.Length < 1) 
                return 1;

            double max = 0;
            double sum = 0;
            foreach(int i in a)
             {
                 max = (max > i) ? max : i;
                 sum += i;
             }

            if (max > a.Length + 1)
                throw new ApplicationException("Unacceptable input");

            int missingNumber = (int)((double)(max * (max + 1) / 2) - sum);

            watch.Stop();
            System.Diagnostics.Debug.WriteLine(a.Length + " elements: " + watch.ElapsedMilliseconds);
            return missingNumber == 0 ? (int)max+1 : missingNumber;
        }
    }
}
