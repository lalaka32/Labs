using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{
    class Article
    {
        public string NameOfPublication { get; set; }
        public Person Autor { get; set; }
        public double Rate{ get; set; }
        public Article(Person autor, string nameOfPublication, double rate)
        {
            NameOfPublication = nameOfPublication;
            Autor = autor;
            Rate = rate;
        }
        public Article()
        {
            NameOfPublication = "";
            Autor = new Person();
            Rate = 0;
        }
        public override string ToString()
        {
            return NameOfPublication + " " + Autor + " " + Rate;
        }

        

        
    }
}
