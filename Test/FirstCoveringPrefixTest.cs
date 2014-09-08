using Main.FirstCoveringPrefix;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestFixture]
    public class FirstCoveringPrefixTest
    {
        private FirstCoveringPrefixProblem s;

        [SetUp]
        public void Init()
        {
            s = new FirstCoveringPrefixProblem();
        }

        [Test]
        public void FirstCoveringPrefixTest1()
        {
            int[] b = new int[] { 2, 2, 1, 0, 1};

            Assert.AreEqual(s.solution(b), 3);
        }


    }
}
