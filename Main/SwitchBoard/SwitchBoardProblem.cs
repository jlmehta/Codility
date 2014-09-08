using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.SwitchBoard
{
    public class SwitchBoardProblem
    {
        #region First Correct Solution
        /// <summary>
        /// First correct solution with acceptable performance.
        /// This solution computes the state for all the switches as per the number of balls 
        /// State is defined as 
        ///  - Number of balls coming into the switch
        ///  - Number of balls switch sends through the right side
        ///  - Number of balls switch sends through the bottom side
        /// At the end it return the balls the bottom-right swtich sends through the bottom
        /// Time Complexity: O(M*N) 
        /// Space Complexity: O(M*N)
        /// Codility Score 100%
        /// Result Link: https://codility.com/demo/results/demoZQ8E4D-BWK/
        /// </summary>
        /// 
        private struct Node
        {
            public Node(int d, int r, int bIn)
            {
                sendsDown = d;
                sendsRight = r;
                ballsIn = bIn;
            }
            public int sendsDown;
            public int sendsRight;
            public int ballsIn;
        }
        private List<List<Node>> list = new List<List<Node>>();
        private int totalBallsIn;

        public int solution(int[][] board, int balls)
        {
            if (board == null || board.Length == 0)
                return 0;
            if (balls == 0)
                return 0;

            totalBallsIn = balls;
            for (int i = 0; i < board.Length; i++)
            {
                list.Add(new List<Node>());
                for (int j = 0; j < board[i].Length; j++)
                {
                    list[i].Add(new Node(
                            SetDownBalls(i, j, board[i][j]),
                            SetRightBalls(i, j, board[i][j]),
                            GetBallsIn(i, j)
                            ));
                }
            }
            return list.Last().Last().sendsDown;
        }

        private int SetDownBalls(int i, int j, int boardValue)
        {
            if (boardValue == 0)
            {
                return (i > 0) ? list[i - 1][j].sendsDown : (j == 0) ? GetBallsIn(i, j) : 0;
            }
            return (boardValue == -1) ? (GetBallsIn(i, j) - GetBallsIn(i, j) / 2) : GetBallsIn(i, j) / 2;
        }

        private int SetRightBalls(int i, int j, int boardValue)
        {
            if (boardValue == 0)
            {
                return (j > 0) ? list[i][j - 1].sendsRight : 0;
            }
            return (boardValue == 1) ? (GetBallsIn(i, j) - GetBallsIn(i, j) / 2) : GetBallsIn(i, j) / 2;
        }

        private int GetBallsIn(int i, int j)
        {
            if (i == 0 && j == 0)
                return totalBallsIn;
            else if (i < 1)
                return list[i][j - 1].sendsRight;
            else if (j < 1)
                return list[i - 1][j].sendsDown;

            return list[i - 1][j].sendsDown + list[i][j - 1].sendsRight;
        }
        #endregion
        
        #region Initial Solution
        /// <summary>
        /// Basically Simulates the traversal of all the balls, not efficient, O((M+N)*K)
        /// Codility Score: 70% (Failed 3 performance tests)
        /// Result Link: https://codility.com/demo/results/demoU9ZTZJ-2PT/#task-0
        /// </summary>
        private enum direction
        {
            DOWN,
            RIGHT
        }

        public int solution1(int[][] board, int balls)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            int count = 0;

            for (int i = 0; i < balls; i++)
            {
                direction lastDirection = direction.DOWN;
                int x = 0, y = 0;
                while (x < board.Length && y < board[x].Length)
                {
                    lastDirection = GetNewDirection(lastDirection, board[x][y]);
                    board[x][y] = UpdateBoardValue(board[x][y]);
                    if (x == board.Length - 1 && y == board[x].Length - 1 && lastDirection == direction.DOWN)
                        count++;
                    if (lastDirection == direction.DOWN)
                        x++;
                    else
                        y++;

                }
            }
            return count;
        }

        private int UpdateBoardValue(int p)
        {
            if (p == 0)
                return 0;
            if (p == 1)
                return -1;
            if (p == -1)
                return 1;
            throw new ApplicationException("Incorrect boardValue");
        }

        private direction GetNewDirection(direction lastDirection, int boardVal)
        {
            if (boardVal > 1 || boardVal < -1)
                throw new ApplicationException("Incorrect boardValue");

            if (boardVal == 0)
                return lastDirection;
            else if (boardVal == 1)
                return direction.RIGHT;
            else
                return direction.DOWN;
        }
        #endregion
    }
}
