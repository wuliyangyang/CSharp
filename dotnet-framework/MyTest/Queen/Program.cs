using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using System.Diagnostics;

namespace Queen
{
    class Program
    {
        //定义解的个数
        int sum = 0;
        //定义皇后数组
        int[] Queens = new int[8];
        static void Main(string[] args)
        {
            Program Pro = new Program();
            //开始求解
            Pro.QueenSort(0);
            Console.ReadKey();
        }
        //排序获取组合（1-8）
        public void QueenSort(int num)
        {
            for (int j = 1; j < 9; j++)
            {
                if (num == 8)
                {
                    sum++;
                    //打印输出
                    Write();
                    break;
                }
                //判断是否冲突
                if (FooConflict(num, j))
                {
                    Queens[num] = j;
                    QueenSort(num + 1);
                }
            }
        }

        /// <summary>
        /// 判断皇后是否和之前所有的皇后冲突
        /// </summary>
        /// <param name="row">已放置完毕无冲突皇后的列数</param>
        /// <param name="queen">新放置的皇后值</param>
        /// <returns>是否冲突</returns>
        public bool FooConflict(int row, int queen)
        {
            if (row == 0)
            {
                return true;
            }
            else
            {
                //循环判断与之前的皇后是否有冲突的
                for (int pionter = 0; pionter < row; pionter++)
                {
                    //如果有，返回false
                    if (!FooCompare(Queens[pionter], row - pionter, queen))
                    {
                        return false;
                    }
                }
                //与之前均无冲突，返回true
                return true;
            }
        }
        /// <summary>
        /// 对比2个皇后是否冲突
        /// </summary>
        /// <param name="i">之前的一个皇后</param>
        /// <param name="row">2个皇后的列数之差</param>
        /// <param name="queen">新放置的皇后</param>
        /// <returns></returns>
        public bool FooCompare(int i, int row, int queen)
        {
            //判断2个皇后是否相等或者相差等于列数之差（即处于正反对角线）
            if ((i == queen) || ((i - queen) == row) || ((queen - i) == row))
            {
                return false;
            }
            return true;
        }
        //打印皇后图案
        public void Write()
        {
            //输出皇后的个数排序
            Console.WriteLine("第{0}个皇后排列:", sum);
            Console.WriteLine("第"+sum+"个皇后排列:");
            for (int i = 0; i < 8; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (j == Queens[i])
                    {
                        Console.Write("■");
                        Console.Write("■");
                    }
                    else
                    {
                        Console.Write("□");
                        Console.Write("□");
                    }
                }
                //换行
                Console.Write("\n");
                Console.Write("\n");
                
            }
        }
    }
}
