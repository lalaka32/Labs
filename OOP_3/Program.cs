using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Person per1 = new Person("Ikar", "Kawka", DateTime.Now);
            per1.DateOfBornInt = 2017;
            Console.WriteLine(per1.DateOfBornInt+per1.ToString());

            TestMassOnTime.Test();
            
            Console.Read();

        }
    }
}