using System;

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

            Paper[] mas1 = InitOneDimensional(nrow, ncolumn);
            Paper[,] mas2 = InitTwoDimensional(nrow, ncolumn);
            Paper[][] mas3 = InitJagged(nrow, ncolumn);

        }

        static Paper[] InitOneDimensional(int nrow, int ncolumn)
        {
            int timer = Environment.TickCount;
            Paper[] mas1 = new Paper[nrow * ncolumn];
            Random rnd = new Random();
            for (int i = 0; i < mas1.Length; i++)
            {
                mas1[i] = new Paper();
                mas1[i].NameOfPublication = "Name"+rnd.Next(0, 10);
            }
            timer = Environment.TickCount - timer;
            Console.WriteLine("for One mls : " + timer);
            return mas1;
        }

        static Paper[,] InitTwoDimensional(int nrow, int ncolumn)
        {
            int timer = Environment.TickCount;
            Paper[,] mas1 = new Paper[nrow, ncolumn];
            Random rnd = new Random();
            for (int i = 0; i < nrow; i++)
            {
                for (int j = 0; j < ncolumn; j++)
                {
                    mas1[i,j] = new Paper();
                    mas1[i,j].NameOfPublication = "Name" + rnd.Next(0, 10);
                }
            }
            timer = Environment.TickCount - timer;
            Console.WriteLine("for two mls : " + timer);
            return mas1;
        }
        static Paper[][] InitJagged(int nrow, int ncolumn)
        {
            int timer = Environment.TickCount;
            Paper[][] mas1 = new Paper[nrow][];
            Random rnd = new Random();
            for (int i = 0; i < nrow; i++)
            {
                mas1[i] = new Paper[ncolumn];

            }
            for (int i = 0; i < nrow; i++)
            {
                for (int j = 0; j < ncolumn; j++)
                {
                    mas1[i][j] = new Paper();
                    mas1[i][j].NameOfPublication = "Name" + rnd.Next(0, 10);
                }
            }
            timer = Environment.TickCount - timer;
            Console.WriteLine("for Jagged mls : " + timer);
            return mas1;
        }
    }
}
