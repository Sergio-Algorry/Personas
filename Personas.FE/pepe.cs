using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personas.FE
{
    public partial class pepe : Form
    {
        public int PropiedadEntera { get; set; }
        public Personas.BE.Personas Pepito { get; set; }


        private string dummy;
        private DataTable DT;

        public pepe(string arg, DataTable dt)
        {
            InitializeComponent();
            dummy = arg;
            DT = dt;    

            textBox1.Text = dummy;

        }

        private void pepe_Load(object sender, EventArgs e)
        {
            label1.Text = PropiedadEntera.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = DT.Rows.Count.ToString(); 
        }
    }
}
