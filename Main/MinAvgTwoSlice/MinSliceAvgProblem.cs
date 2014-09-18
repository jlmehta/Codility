using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.MinAvgTwoSlice
{
    public class MinSliceAvgProblem
    {
        /// <summary>
        /// Calculate Prefix sums and use them to find the minimum avg slice
        /// Minimum slice will be either a 2 element or a three element slice
        /// Proof of the above claim, say a slice > 3 elements is a minimum average slice
        /// - if the slice has odd number of elements, it can be broken into a combination of 2 and 3 element slices.
        ///   And by definition all those slices will be minimum average too, if not the initial hypothesis fails
        /// - if the slice has even number of elements, it can be broken into a combination of 2 element slices.
        ///   And again by definition all those slices will be minimum average too, if not the initial hypothesis fails
        /// Note: it is possible to solve this without using prefix sums too.
        /// Time Complexity: O(N) 
        /// Space Complexity: O(N)
        /// Codility Score 100%
        /// https://codility.com/demo/results/demo6UG6JS-YN4/
        /// </summary>
        /// <param name="arr">Input Array</param>
        /// <returns>Start index of the slice with minimum average</returns>
        public int Solution(int[] arr)
        {
            if (arr.Length < 2)
                return 0;
            if (arr.Length == 2)
                return 0;

            double[] prefixSums = new double[arr.Length + 1];
            int i = 0, startIndex = 0;
            foreach(int num in arr)
            {
                prefixSums[i + 1] = prefixSums[i] + num;
                i++;
            }

            double minAvg = int.MaxValue;
            for(i=0; i<prefixSums.Length-3; i++)
            {
                double next2 = (prefixSums[i+2]-prefixSums[i])/2;
                if( next2 < minAvg)
                {
                    minAvg = next2;
                    startIndex = i;
                }

                double next3 = (prefixSums[i + 3] - prefixSums[i]) / 3;
                if (next3 < minAvg)
                {
                    minAvg = next3;
                    startIndex = i;
                }
            }
            if((prefixSums[prefixSums.Length-1]-prefixSums[prefixSums.Length-3])/2<minAvg)
            {
                minAvg = (prefixSums[prefixSums.Length-1] - prefixSums[prefixSums.Length - 3])/2;
                startIndex = prefixSums.Length - 3;
            }

            return startIndex;
        }
    }
}
