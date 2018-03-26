using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{
    class TestMassOnTime
    {
        
        static public void Test(Article article)
        {
            int nrow = 0, ncolumn = 0;
            string text = Console.ReadLine();
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            nrow = Convert.ToInt32(words[0]);
            ncolumn = Convert.ToInt32(words[1]);
            Person okabeRentaro = new Person("HOOOUIN ", "KYOOOOMAA", new DateTime(1996, 1, 1));
            Article[] mas1 = InitOneDimen(nrow, ncolumn, article);
            Article [,] mas2 = InitTwoDimens(nrow, ncolumn, article);
            Article [][] mas3 = InitJagged(nrow, ncolumn, article);
            TestTime(mas1, okabeRentaro);
            TestTime(mas2, okabeRentaro);
            TestTime(mas3, okabeRentaro);

        }

        static Article[] InitOneDimen(int vert, int horiz, Article article)//одномерный
        {
            Article[] mas = new Article[vert * horiz];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = article;
            }
            return mas;
        }

        static Article[,] InitTwoDimens(int vert, int horiz, Article article)//двумерный
        {
            Article[,] mas = new Article[vert, horiz];
            for (int i = 0; i < vert; i++)
            {
                for (int j = 0; j < horiz; j++)
                {
                    mas[i, j] = article;
                }
            }
            return mas;
        }
        static Article[][] InitJagged(int nrow, int ncolumn, Article article)//ступенчатый
        {
            Article[][] mas = new Article[nrow][];
            for (int i = 0; i < nrow; i++)
            {
                mas[i] = new Article[ncolumn];
            }
            for (int i = 0; i < nrow; i++)
            {
                for (int j = 0; j < ncolumn; j++)
                {
                    mas[i][j] = article;
                }
            }

            return mas;
        }
        static void TestTime(Article[][] mas, Person pers)
        {
            int timer = Environment.TickCount;
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas[i].GetLength(0); j++)
                {
                    mas[i][j].Autor = pers;
                }
            }
            timer = Environment.TickCount - timer;
            Console.WriteLine("Для ступечатого массива млс : " + timer);
        }
        static void TestTime(Article[] mas, Person pers)
        {
            int timer = Environment.TickCount;
            for (int i = 0; i < mas.Count(); i++)
            {
                mas[i].Autor = pers;
            }
            timer = Environment.TickCount - timer;
            Console.WriteLine("Для одномерного массива млс : " + timer);
        }
        static void TestTime(Article[,] mas, Person pers)
        {
            int timer = Environment.TickCount;
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    mas[i,j].Autor = pers;
                }
            }
            timer = Environment.TickCount - timer;
            Console.WriteLine("Для двумерного массива млс : " + timer);
        }
    }
}
