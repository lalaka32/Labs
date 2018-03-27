using System;

namespace OOP_3
{
    class Program
    {
        static void Main(string[] args)
        {
            ResearchTeam research = new ResearchTeam("math", "bru", 1, TimeFrame.Long);
            Console.WriteLine( research.ToShortString());

            Console.WriteLine("Year {0}, TwoYear {1}, Long {2}",research[TimeFrame.Year],research[TimeFrame.TwoYear],research[TimeFrame.Long]);
            
            Person per1 = new Person("Ikar", "Duran", DateTime.Now);
            DateTime time = new DateTime(1999, 01, 01);
            Paper[] team = { new Paper("pap1", per1, DateTime.Now), new Paper("pap2", per1, time), new Paper("pap3", per1, time) };
            research.Papers = team;
            research.Subject = "oop";
            research.Organization = "ГВУПО БРУ";
            research.Number = 2;
            research.LengthOfResearch = TimeFrame.Year;
            Console.WriteLine(research.ToString());

            Console.WriteLine("LastPaper: {0}",research.LastPaper.NameOfPublication);

            Paper[] team1 = { new Paper("pop4", per1, time), new Paper("pop5", per1, time), new Paper("pop6", per1, time) };
            research.AddPapers(team1);
            
            Console.WriteLine(research.ToString());
            
            TestMassOnTime.Test();
            Console.Read();

        }
    }
}