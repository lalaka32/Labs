using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string result { get; private set; }

        private void button1_Click(object sender, EventArgs e)
        {
            string result = "";
            double a;
            double b;
            double c;
            if (!double.TryParse(textBox1.Text,out a))
            {
                a = 0;
            }
            if (!double.TryParse(textBox2.Text, out b))
            {
                b = 0;
            }
            if (!double.TryParse(textBox3.Text, out c))
            {
                c = 0;
            }

            Сone cone = new Сone(c,b,a);

            result += String.Format("Radius: {0}, Height: {1}, Density: {2} ",c,b,a);
            if (checkBox2.CheckState == CheckState.Checked)
            {
                result += String.Format("Volume: {0} ", cone.Volume());
            }
            if (checkBox3.CheckState==CheckState.Checked)
            {
                result += String.Format("Mass: {0} ",cone.Mass());
            }
            
            this.result = result;
            Close();
        }

    }
}
