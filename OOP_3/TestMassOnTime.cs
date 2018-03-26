using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{
    class TestMassOnTime
    {
        static public void Test()
        {
            int nrow = 0, ncolumn = 0;

            string text = Console.ReadLine();
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            nrow = Convert.ToInt32(words[0]);
            ncolumn = Convert.ToInt32(words[1]);

            int[] mas1 = InitOneDimensional(nrow, ncolumn);
            int[,] mas2 = InitTwoDimensional(nrow, ncolumn);
            int[][] mas3 = InitJagged(nrow, ncolumn);

        }

        static int[] InitOneDimensional(int nrow, int ncolumn)
        {
            int timer = Environment.TickCount;
            int[] mas1 = new int[nrow * ncolumn];
            Random rnd = new Random();
            for (int i = 0; i < mas1.Length; i++)
            {
                mas1[i] = rnd.Next(0, 10);
            }
            timer = Environment.TickCount - timer;
            Console.WriteLine("for One mls : " + timer);
            return mas1;
        }

        static int[,] InitTwoDimensional(int nrow, int ncolumn)
        {
            int timer = Environment.TickCount;
            int[,] mas1 = new int[nrow, ncolumn];
            Random rnd = new Random();
            for (int i = 0; i < nrow; i++)
            {
                for (int j = 0; j < ncolumn; j++)
                {
                    mas1[i, j] = rnd.Next(0, 10);
                }
            }
            timer = Environment.TickCount - timer;
            Console.WriteLine("for two mls : " + timer);
            return mas1;
        }
        static int[][] InitJagged(int nrow, int ncolumn)
        {
            int timer = Environment.TickCount;
            int[][] mas1 = new int[nrow][];
            Random rnd = new Random();
            for (int i = 0; i < nrow; i++)
            {
                mas1[i] = new int[ncolumn];

            }
            for (int i = 0; i < nrow; i++)
            {
                for (int j = 0; j < ncolumn; j++)
                {
                    mas1[i][j] = rnd.Next(0, 10);
                }
            }
            timer = Environment.TickCount - timer;
            Console.WriteLine("for Jagged mls : " + timer);
            return mas1;
        }
    }
}
