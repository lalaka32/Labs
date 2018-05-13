using System;

namespace OOP_3
{
    public class Person
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
        public Person() { }
        public override string ToString()
        {
            return Name + " " + Surname + " " + dateOfBorn.Day + "." + dateOfBorn.Month + "." + dateOfBorn.Year;
        }
        public string ToShortString()
        {
            return Name + " " + Surname ;
        }
        public override bool Equals(object obj)
        {
            if (obj is Person)
            {
                return this == (Person)obj;

            }
            return false;
        }
        
        static public bool operator ==(Person obj1, Person obj2)
        {
            if (obj1 is Person && obj2 is Person)
            {
                return obj1.Name == obj2.Name && obj1.Surname == obj2.Surname && obj1.DateOfBorn == obj2.DateOfBorn; 
            }
            return false;
        }
        static public bool operator !=(Person obj1, Person obj2)
        {
            return !(obj1==obj2);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode()*dateOfBorn.GetHashCode()*Surname.GetHashCode();
        }
        public virtual object DeepCopy()
        {
            return MemberwiseClone();

        }
        
    }
}
