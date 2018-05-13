using System;

namespace OOP_3
{
    public class Paper
    {
        public string NameOfPublication { get; set; }
        public Person Autor { get; set; }
        public DateTime Date { get; set; }
        public Paper(string nameOfPublication , Person autor,DateTime date)
        {
            NameOfPublication = nameOfPublication;
            Autor = autor;
            Date = date;
        }
        public Paper()
        {
            NameOfPublication = "";
            Autor = new Person();
            Date = new DateTime();
        }
        public override string ToString()
        {
            return NameOfPublication + " " + Autor + " " + Date.Day + "." + Date.Month + "." + Date.Year;
        }
        public virtual object DeepCopy()
        {
            return MemberwiseClone();
        }
    }
}
