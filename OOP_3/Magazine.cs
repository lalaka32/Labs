using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{
    class Magazine
    {
        string name;
        Freq freq;
        int number;
        DateTime dateofexit;
        int edition;
        Article[] articles;
        public Magazine(string name, Freq freq, int number, DateTime dateofexit, int edition)
        {
            this.name = name;
            this.freq = freq;
            this.number = number;
            this.dateofexit = dateofexit;
            this.edition = edition;
        }
        public Magazine()
        {
            name = "";
            freq = Freq.Weekly;
            edition = 0;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Freq Freq
        {
            get { return freq; }
            set { freq = value; }
        }

        public DateTime DateofExit
        {
            get { return dateofexit; }
            set { dateofexit = value; }
        }

        public int Edition
        {
            get { return edition; }
            set { edition = value; }
        }
        public Article[] Articles
        {
            get { return articles; }
            set { articles = value ; }
        }
        public double AverageValue
        {
            get
            {
                double sum = 0;
                if (articles != null)
                {
                    foreach (var item in articles)
                    {
                        sum += item.Rate;
                    }
                    return sum / articles.Count();
                }
                else return sum;
            }
        }
        public bool this[Freq freq] => freq == this.freq;
        // аналог public bool this[Freq freq] { get { return freq == this.freq; } }

            void testMethod(params Article[] args)
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("Пустой массив!");
                }
                else
                {
                    List<Article> listofarticles = articles.ToList();
                    listofarticles.AddRange(args);
                    articles = listofarticles.ToArray();
                }
            }
        public override string ToString()
        {
            string str = "";
            foreach (var item in articles)
            {
                str += item.NameOfPublication + " ";
            }
            return "Имена статей: " + str + ", " + "Имя журнала: " + name + ", " + 
                "Частота издания: " + freq + ", " + "Номер " + number + ", " + "Тираж " + 
                edition + ", " + "Дата: " + dateofexit.Day + "." + dateofexit.Month + "." + 
                dateofexit.Year;
        }
        public virtual string ToShortString()
        {
            return "Средний рейтинг статей: " + AverageValue + ", " + "Имя журнала: " + name + ", " + "Частота издания: " + freq
                + ", " + "Номер " + number + ", " + "Тираж " + edition + ", "
                + "Дата: " + dateofexit.Day + "." + dateofexit.Month + "." + dateofexit.Year;
        }


    }
}
