using Main.MinMissingInteger;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class MinMissingIntegerTest
    {
        private MinMissingIntegerProblem msp;

        [SetUp]
        public void Init()
        {
            msp = new MinMissingIntegerProblem();
        }

        [Test]
        public void MinMissingIntegerTest1()
        {
            Assert.AreEqual(msp.solution(new int[] { 1, 2, 3, 5 }), 4);
        }

        [Test]
        public void MissingIntegerTestZero()
        {
            Assert.AreEqual(msp.solution(new int[0]), 0);
        }

        [Test]
        public void MissingIntegerTestNull()
        {
            Assert.AreEqual(msp.solution(null), 0);
        }

        [Test]
        public void MissingIntegerTestOne()
        {
            Assert.AreEqual(msp.solution(new int[] {2}), 1);
        }

        [Test]
        public void MissingIntegerTestTwo()
        {
            Assert.AreEqual(msp.solution(new int[] { 1 }), 2);
        }

        [Test]
        public void MissingIntegerTestNegative()
        {
            Assert.AreEqual(msp.solution(new int[] { -1, 4, -5, 1 }), 2);
        }
    }
}
