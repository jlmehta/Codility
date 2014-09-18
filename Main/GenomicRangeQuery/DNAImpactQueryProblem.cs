using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.GenomicRangeQuery
{
    public class DNAImpactQueryProblem
    {
        public int[] Solution(string s, int[] p, int[] q)
        {
            short a, c, g;
            int counter = 1;
            int[,] prefixArray = new int[3, s.Length + 1];

            foreach(char ch in s)
            {
                a = 0; c = 0; g = 0;
                switch (ch)
                {
                    case 'A':
                        a = 1;
                        break;
                    case 'C':
                        c = 1;
                        break;
                    case 'G':
                        g = 1;
                        break;
                    default: 
                        break;
                }
                prefixArray[0, counter] = prefixArray[0, counter - 1] + a;
                prefixArray[1, counter] = prefixArray[1, counter - 1] + c;
                prefixArray[2, counter] = prefixArray[2, counter - 1] + g;
                counter++;
            }

            return p.Zip(q, (pi, qi) => GetMinimalImpactFactor(pi, qi, prefixArray)).ToArray();
        }

        private int GetMinimalImpactFactor(int pi, int qi, int[,] prefixArray)
        {
            if (prefixArray[0, qi + 1] > prefixArray[0, pi])
                return 1;
            else if (prefixArray[1, qi + 1] > prefixArray[1, pi])
                return 2;
            else if (prefixArray[2, qi + 1] > prefixArray[2, pi])
                return 3;
            return 4;
        }
    }
}
