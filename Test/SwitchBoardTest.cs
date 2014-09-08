using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.SwitchBoard;

namespace Test.SwitchBoard
{
    [TestFixture]
    public class SwitchBoardTest
    {
        private SwitchBoardProblem s;

        [SetUp]
        public void Init()
        {
            s = new SwitchBoardProblem();
        }

        [Test]
        public void SwitchBoardTest1()
        {
            int[][] b = new int[2][];
            b[0] = new int[] { -1, 0, -1 };
            b[1] = new int[] { 1, 0, 0 };

            Assert.AreEqual(s.solution(b, 4), 1);
        }

        [Test]
        public void SwitchBoardTest2()
        {
            int[][] b = new int[2][];
            b[0] = new int[] { -1, 0, -1, 1 };
            b[1] = new int[] { 1, 0, 0, 1 };

            Assert.AreEqual(s.solution(b, 4), 0);
        }

        [Test]
        public void SwitchBoardTest_NullBoard()
        {
            int[][] b = null;

            Assert.AreEqual(s.solution(b, 4), 0);
        }

        [Test]
        public void SwitchBoardTest_ZeroBalls()
        {
            int[][] b = new int[2][];
            b[0] = new int[] { -1, 0, -1, 1 };
            b[1] = new int[] { 1, 0, 0, 1 };

            Assert.AreEqual(s.solution(b, 0), 0);
        }
    }
}
