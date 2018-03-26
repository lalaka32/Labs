using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{
    class Paper
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

        

        
    }
}
