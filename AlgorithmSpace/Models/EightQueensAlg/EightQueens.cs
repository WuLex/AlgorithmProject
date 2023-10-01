using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmSpace.Models.EightQueensAlg
{

    /// <summary>
    /// 八皇后问题是一个经典的计算机科学和数学问题，
    /// 它要求在一个8x8的国际象棋棋盘上放置8个皇后，
    /// 使得它们彼此之间互相不攻击，
    /// 即没有两个皇后在同一行、同一列或同一斜线上。
    /// 这些问题都涉及到组合、排列和递归等数学和计算机科学概念，
    /// 因此它们一直是算法和编程练习的热门选择。
    /// </summary>
    public class EightQueens
    {
        static int N = 8; // 棋盘大小
        static int[] queens = new int[N]; // 存储皇后的列索引
        public static int solutionCount = 0; // 用于计数解决方案的数量
       
        //static void Main()
        //{
        //    // 调用解决方法，从第一行开始
        //    SolveQueens(0);
        //}
        
        // 递归函数用于找到所有解决方案
        public static void SolveQueens(int row)
        {
            if (row == N)
            {
                // 当已经成功放置8个皇后，找到一个解决方案
                PrintSolution(); 
                //PrintSolution(solutionCount); 
                solutionCount++; // 增加解决方案数量
                return;
            }

            // 在当前行的每一列中尝试放置皇后
            for (int col = 0; col < N; col++)
            {
                if (IsSafe(row, col))
                {  
                    // 如果当前位置安全，则放置皇后，并继续下一行
                    queens[row] = col;
                    SolveQueens(row + 1);
                }
            }
        }
        // 检查当前位置是否安全，避免冲突
        static bool IsSafe(int row, int col)
        {
             //检查当前位置是否与之前的皇后冲突
             //检查当前位置是否安全
            for (int prevRow = 0; prevRow < row; prevRow++)
            {
                int prevCol = queens[prevRow];

                // 检查是否在同一列、同一左上到右下斜线或同一左下到右上斜线上
                if (prevCol == col || // 同一列
                    prevRow - prevCol == row - col || // 左上到右下斜线
                    prevRow + prevCol == row + col) // 左下到右上斜线
                {
                    return false;// 冲突，位置不安全
                }
            }
            return true;// 当前位置安全
        }

        // 打印找到的解决方案
        static void PrintSolution()
        {
            Console.WriteLine($"一个解决方案:");
            //Console.WriteLine($"第{solutionCount}个解决方案:");
            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < N; col++)
                {
                    if (queens[row] == col)
                        Console.Write("Q ");// 打印皇后
                    else
                        Console.Write(". ");// 打印空格表示没有皇后
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
