using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOP_3
{
    class Person
    {
       
        private DateTime dateOfBorn;
        public string Name { get; set; }
        public string Surname { get; set; }

        public DateTime DateOfBorn
        {
            get { return dateOfBorn; }
            set { dateOfBorn = value; }
        }
        public int DateOfBornInt
        {
            get { return dateOfBorn.Year; }
            set {dateOfBorn= new DateTime( value,dateOfBorn.Month,dateOfBorn.Day); }
        }
        
        public Person(string name, string surname, DateTime dateOfBorn)
        {
            this.Name = name;
            this.Surname = surname;
            this.dateOfBorn = dateOfBorn;
        }
        public Person()
        {
            Name = "";
            Surname = "";
            dateOfBorn = new DateTime();
        }
        public override string ToString()
        {
            return Name + " " + Surname + " " + dateOfBorn.Day + "." + dateOfBorn.Month + "." + dateOfBorn.Year;
        }
        public string ToShortString()
        {
            return Name + " " + Surname ;
        }

    }
}
