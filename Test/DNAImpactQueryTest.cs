using Main.GenomicRangeQuery;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestFixture]
    public class DNAImpactQueryTest
    {
        private DNAImpactQueryProblem s;

        [SetUp]
        public void Init()
        {
            s = new DNAImpactQueryProblem();
        }

        [Test]
        public void Test1()
        {
            var result = s.Solution("CAGCCTA", new int[] { 2, 5, 0 }, new int[] { 4, 5, 6 });
            int[] expected = new int[] {2,4,1};
            Assert.AreEqual(result.Zip(expected, (r,e) => r==e).Any(x => x==false), false);
        }

        [Test]
        public void Test2()
        {
            var result = s.Solution("A", new int[] { 0 }, new int[] { 0 });
            int[] expected = new int[] { 1 };
            Assert.AreEqual(result.Zip(expected, (r, e) => r == e).Any(x => x == false), false);
        }
    }
}
