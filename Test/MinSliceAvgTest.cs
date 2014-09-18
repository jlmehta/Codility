using Main.MinAvgTwoSlice;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class MinSliceAvgTest
    {
        private MinSliceAvgProblem s;

        [SetUp]
        public void Init()
        {
            s = new MinSliceAvgProblem();
        }

        [Test]
        public void DefaultTest()
        {
            Assert.AreEqual(s.Solution(new int[] { 4, 2, 2, 5, 1, 5, 8 }), 1);
        }

        [Test]
        public void SingleElementArrayTest()
        {
            Assert.AreEqual(s.Solution(new int[] { 4 }), 0);
        }

        [Test]
        public void TwoElementArrayTest()
        {
            Assert.AreEqual(s.Solution(new int[] { 4,2 }), 0);
        }

        [Test]
        public void LastTwoTest1()
        {
            Assert.AreEqual(s.Solution(new int[] { 4, 3 ,1 }), 1);
        }

        [Test]
        public void LastTwoTest2()
        {
            Assert.AreEqual(s.Solution(new int[] { 5, 6, 8, 4, 3, 1 }), 4);
        }

        [Test]
        public void LastThreeTest()
        {
            Assert.AreEqual(s.Solution(new int[] { 5, 6, 8, -1, 3, 1 }), 3);
        }

        [Test]
        public void NegativeValuesTest()
        {
            Assert.AreEqual(s.Solution(new int[] { 5, 4, -2, 3, 1 }), 2);
        }
    }
}
