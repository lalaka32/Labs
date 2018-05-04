using System;
using System.Collections;
using System.Collections.Generic;

namespace OOP_3
{
    class Program
    {
        static void Main(string[] args)
        {
            ResearchTeamCollection a = new ResearchTeamCollection();

            List<Person> per = new List<Person>();
            Person per1 = new Person();
            per1.Name = "Kevin";
            per1.Surname= "Lewin";
            per1.DateOfBorn = DateTime.MinValue;
            per.Add(per1);

            List<Paper> doc = new List<Paper>();
            Paper doc1 = new Paper();
            doc1.Autor = per[0];
            doc1.NameOfPublication = "Some research";
            doc1.Date = DateTime.Now;
            doc.Add(doc1);

            List<Paper> docs2 = new List<Paper>();
            Paper doc2 = new Paper();
            doc2.Autor = per[0];
            doc2.NameOfPublication = "Some research";
            doc2.Date = DateTime.Now;
            docs2.Add(doc1);
            docs2.Add(doc2);

            ResearchTeam rt1 = new ResearchTeam();
            rt1.Name = "Workers";
            rt1.RegNumber = 1;
            foreach (Paper item in docs2)
            {
                rt1.AddPapers(item);
            }
            
            rt1.Persons = per;

            ResearchTeam rt2 = new ResearchTeam();
            rt2.Name = "Josefs";
            rt2.RegNumber = 2;
            rt2.LengthOfResearch = TimeFrame.TwoYears;
            
            foreach (Paper item in doc)
            {
                rt2.AddPapers(item);
            }
            rt2.Persons = per;

            List<ResearchTeam> t = new List<ResearchTeam> { rt1, rt2 };
            a.AddDefaults(t);

            a.RnameSort();
            Console.WriteLine("Name Sort");
            Console.WriteLine(a.ToString());
            a.RnumSort();
            Console.WriteLine("Registration Number Sort:");
            Console.WriteLine(a.ToString());
            a.DocsSort();
            Console.WriteLine("Docs Sort:");
            Console.WriteLine(a.ToString());
            Console.WriteLine("Min registration number:");
            Console.WriteLine(a.MinRegNum);
            Console.WriteLine("After time Sort:");
            foreach (ResearchTeam h in a.ResLogs)
            {
                Console.WriteLine(h.ToString());
            }
            Console.WriteLine("Group Sort:");
            foreach (ResearchTeam h1 in a.NGroup(1))
            {
                Console.WriteLine(h1.ToString());
            }
            TestCollections test = new TestCollections(1000);
            Console.WriteLine("Search Time:");
            Console.WriteLine(test.GetTime());
            Console.ReadLine();

        }
        #region Four

        private static void forLabFour()
        {
            Team team3 = new Team("1", "1", 1);
            Team team4 = (Team)team3.DeepCopy();
            Console.WriteLine("До:");
            Console.WriteLine(team3.ToString() + " " + team3.GetHashCode());
            Console.WriteLine(team4.ToString() + " " + team4.GetHashCode());
            team4.RegNumber = 2;
            team4.Name = "2";
            Console.WriteLine("После:");
            Console.WriteLine(team3.ToString() + " " + team3.GetHashCode());
            Console.WriteLine(team4.ToString() + " " + team4.GetHashCode());
            try
            {
                team3.RegNumber = -1;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Wrong numb");
            }

            ResearchTeam research = new ResearchTeam("Team1", "BRU", 1, "Math", TimeFrame.Long);

            Person per1 = new Person("Ikar", "Duran", DateTime.Today);
            Person per2 = new Person("PersonWhithoutPaper", "Ivanov", DateTime.Today);
            DateTime time = new DateTime(1999, 01, 01);
            Paper[] papers = {
            new Paper("pap1", per1, DateTime.Now),
            new Paper("pap2", per1, time),
            new Paper("pap3", per1, time) };
            List<Paper> arrayPaper = new List<Paper>(papers);//here
            research.Persons.Add(per1);
            research.Persons.Add(per2);
            research.Papers = arrayPaper;
            Console.WriteLine("Данные ResearchTeam: {0}", research.ToString());
            Console.WriteLine("Значение свойства Team для объекта типа ResearchTeam: {0}", research.Team.ToString());
            ResearchTeam research1 = (ResearchTeam)research.DeepCopy();
            research1.Papers[0] = null;
            Console.WriteLine("После присвоения null для копии:");
            Console.WriteLine(((Paper)research.Papers[0]).ToString());
            Console.WriteLine("список участников проекта, которые не имеют публикаций:");
            foreach (string item in research)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("вывести список всех публикаций, вышедших за последние два года:");
            foreach (string item in research.Publications(2016))
            {
                Console.WriteLine(item);//here
            }
            Console.Read();
        } 
        #endregion
    }
}