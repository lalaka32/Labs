using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Сone
    {
        double radius;
        double height;
        double density;

        public Сone(double radus=0, double height=0, double density=0)
        {
            this.radius = radus;
            this.height = height;
            this.density = density;
        }
        public double Volume()
        {
            return (height*Math.PI*Math.Pow(radius,2)) / 3;
        }
        public double Mass()
        {
            return Volume() * density;
        }
    }
}
