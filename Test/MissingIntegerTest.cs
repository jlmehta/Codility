using Main.MissingInteger;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class MissingIntegerTest
    {
        private MissingIntegerProblem msp;

        [SetUp]
        public void Init()
        {
            msp = new MissingIntegerProblem();
        }

        [Test]
        public void MissingIntegerTest1()
        {
            Assert.AreEqual(msp.solution(new int[] { 1, 2, 3, 5 }), 4);
        }

        [Test]
        public void MissingIntegerTestZero()
        {
            Assert.AreEqual(msp.solution(new int[0]), 1);
        }

        [Test]
        public void MissingIntegerTestOne()
        {
            Assert.AreEqual(msp.solution(new int[] {1}), 2);
        }

        [Test]
        public void MissingIntegerTestTwo()
        {
            Assert.AreEqual(msp.solution(new int[] { 1,2 }), 3);
        }

        [Test]
        public void MissingIntegerTestLast()
        {
            Assert.AreEqual(msp.solution(new int[] {1,2,3,4}), 5);
        }

        [Test]
        public void MissingIntegerTestFirst()
        {
            Assert.AreEqual(msp.solution(new int[] { 2, 3, 4 }), 1);
        }

        [Test]
        public void MissingIntegerTestNull()
        {
            Assert.AreEqual(msp.solution(null), 0);
        }

        [Test]
        public void MissingIntegerTestMedium()
        {
            int num = 0;
            Assert.AreEqual(msp.solution(GetLargeArray(10000, out num)), num);
        }

        [Test]
        public void MissingIntegerTestLarge()
        {
            int num = 0;
            Assert.AreEqual(msp.solution(GetLargeArray(100000, out num)), num);
        }

        [Test]
        public void MissingIntegerTestHuge()
        {
            int num = 0;
            Assert.AreEqual(msp.solution(GetLargeArray(1000000, out num)), num);
        }

        private int[] GetLargeArray(int n, out int random)
        {
            var r = new Random();
            var arr = new int[n-1];
            var list = new List<int>();
            for(int i =1; i<=n; i++)
            {
                list.Add(i);
            }

            for (int i=0; i<n-1; i++)
            {
                int num = r.Next(list.Count);
                arr[i] = list[num];
                list[num] = list.Last();
                list.RemoveAt(list.Count-1);
            }
            random = list.First();
            return arr;
        }
    }
}
