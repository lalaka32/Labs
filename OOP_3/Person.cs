using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOP_3
{
    class Person
    {
       
        DateTime dateOfBorn;
        string name, surname;

        public DateTime DateOfBorn
        {
            get { return dateOfBorn; }
            set { dateOfBorn = value; }
        }
        public int YearOfBornInt
        {
            get { return dateOfBorn.Year; }
            set {dateOfBorn = new DateTime(value, dateOfBorn.Month, dateOfBorn.Day); }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public Person(string name, string surname, DateTime dateOfBorn)
        {
            this.name = name;
            this.surname = surname;
            this.dateOfBorn = dateOfBorn;
        }
        public Person()
        {
            name = "";
            surname = "";
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
