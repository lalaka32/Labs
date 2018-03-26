using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{
    enum Freq
    {
        Weekly, Monthly, Yearly
    }

    class Program
    {


        static void Main(string[] args)
        {
            Magazine magazine1 = new Magazine("Grognak the Barbarian", Freq.Monthly, 3,
                new DateTime(2070, 10, 14), 2);
            Console.WriteLine(magazine1.ToShortString());
            Console.WriteLine("Значение индексатора при Weekly: " + magazine1[Freq.Weekly]);
            Console.WriteLine("Значение индексатора при Monthly: " + magazine1[Freq.Monthly]);
            Console.WriteLine("Значение индексатора при Yearly: " + magazine1[Freq.Yearly]);
            //Присваиваю значения через св-ва:
            Person ella = new Person("Эллочка", "Людоедка", new DateTime(1999, 3, 5));
            Person ella2 = new Person("Эллочка", "НеЛюдоедка", new DateTime(1999, 3, 5));
            Article article1 = new Article(ella, "Вкуснейшие блюда!!!", 3.5);
            Article article2 = new Article(ella2, "Квантовый регулятор", 8.2);
            Article[] articles = new Article[]{article1, article2};
            magazine1.Articles = articles;
            magazine1.DateofExit = new DateTime(2071, 1, 2);
            magazine1.Name = "Журнал близняшек";
            Console.WriteLine(magazine1.ToString());
            TestMassOnTime.Test(article2);
            Console.Read();

        }
    }
}